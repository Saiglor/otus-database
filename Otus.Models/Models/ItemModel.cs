using System;

namespace Otus.Models.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Guid SellerId { get; set; }
        public Guid ItemTypeId { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfViews { get; set; }
        public bool IsClose { get; set; }

        public virtual ClientProfileModel Seller { get; set; }
        public virtual ItemTypeModel ItemType { get; set; }
    }
}