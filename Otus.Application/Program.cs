using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
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
    }
}