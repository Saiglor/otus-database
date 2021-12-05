using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Models.Models;

namespace Otus.PostgreSql.Configurations
{
    public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemTypeModel>
    {
        public void Configure(EntityTypeBuilder<ItemTypeModel> builder)
        {
            builder.ToTable("item_type");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.ParentItemTypeId).HasColumnName("parent_item_type_id");
            builder.Property(t => t.Name).HasColumnName("name");

            builder.HasOne(t => t.ParentItemType).WithMany(t => t.ChildItemTypes)
                .HasForeignKey(t => t.ParentItemTypeId);
        }
    }
}