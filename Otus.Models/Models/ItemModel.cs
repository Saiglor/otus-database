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

        public string GetString()
        {
            return
                $"|{Id,37}|{Title,20}|{Description,35}|{Price,8}|{SellerId,37}|{ItemTypeId,37}|{PublicationDate,20}|{NumberOfViews,14}|{IsClose,10}|";
        }
    }
}