using System;
using System.Collections.Generic;

namespace Otus.Models.Models
{
    public class ItemTypeModel
    {
        public Guid Id { get; set; }
        public Guid? ParentItemTypeId { get; set; }
        public string Name { get; set; }

        public virtual ItemTypeModel ParentItemType { get; set; }

        public virtual ICollection<ItemModel> Items { get; set; }
        public virtual ICollection<ItemTypeModel> ChildItemTypes { get; set; }

        public string GetString()
        {
            return $"|{Id,37}|{ParentItemTypeId,37}|{Name,20}|";
        }
    }
}