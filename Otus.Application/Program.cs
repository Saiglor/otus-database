using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Otus.Models.Models;
using Otus.PostgreSql;

namespace Otus.Application
{
    public class Program
    {
        public static void Main()
        {
            using var db = new ApplicationContext(GetConnectionString());

            WriterUsers(db);
            Console.WriteLine();
            WriteItemTypes(db);
            Console.WriteLine();
            WriteItems(db);

            try
            {
                var newItem = ReadNewItem();
                db.Items.Add(newItem);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Успешно!");
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            return config.GetConnectionString("PostgreSqlDatabase");
        }

        private static void WriterUsers(ApplicationContext db)
        {
            var users = db.ClientProfiles.ToList();

            Console.WriteLine(
                $"|{"Id",37}|{"Name",20}|{"Email",20}|{"PhoneNumber",15}|{"IsCompany",10}|{"RegistrationDate",20}|");

            foreach (var user in users)
            {
                Console.WriteLine(user.GetString());
            }
        }

        private static void WriteItemTypes(ApplicationContext db)
        {
            var types = db.ItemTypes.ToList();

            Console.WriteLine(
                $"|{"Id",37}|{"ParentItemTypeId",37}|{"Name",20}|");

            foreach (var type in types)
            {
                Console.WriteLine(type.GetString());
            }
        }

        private static void WriteItems(ApplicationContext db)
        {
            var items = db.Items.ToList();

            Console.WriteLine(
                $"|{"Id",37}|{"Title",20}|{"Description",35}|{"Price",8}|{"SellerId",37}|{"ItemTypeId",37}|" +
                $"{"PublicationDate",20}|{"NumberOfViews",14}|{"IsClose",10}|");
            
            foreach (var item in items)
            {
                Console.WriteLine(item.GetString());
            }
        }

        private static ItemModel ReadNewItem()
        {
            var newItem = new ItemModel();
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var properties = typeof(ItemModel).GetProperties(bindingFlags).Where(t => !t.GetAccessors()[0].IsVirtual);
            Console.WriteLine("Добавить новое объявление:");
            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
                var val = Console.ReadLine();
                
                while (string.IsNullOrEmpty(val))
                {
                    Console.WriteLine(prop.Name);
                    val = Console.ReadLine();
                }

                switch (prop.PropertyType)
                {
                    case var t when t == typeof(Guid):
                        prop.SetValue(newItem, Guid.Parse(val));
                        break;
                    case var t when t == typeof(string):
                        prop.SetValue(newItem, val);
                        break;
                    case var t when t == typeof(int):
                        prop.SetValue(newItem, int.Parse(val));
                        break;
                    case var t when t == typeof(bool):
                        prop.SetValue(newItem, bool.Parse(val));
                        break;
                    case var t when t == typeof(DateTime):
                        prop.SetValue(newItem, DateTime.ParseExact(val, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
                        break;
                }
            }

            return newItem;
        }
    }
}