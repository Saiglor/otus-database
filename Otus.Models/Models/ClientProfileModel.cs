using System;
using System.Collections.Generic;

namespace Otus.Models.Models
{
    public class ClientProfileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCompany { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<ItemModel> Items { get; set; }
    }
}