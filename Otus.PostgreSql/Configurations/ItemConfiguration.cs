using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Models.Models;

namespace Otus.PostgreSql.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder.ToTable("item");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.Title).HasColumnName("title");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Price).HasColumnName("price");
            builder.Property(t => t.SellerId).HasColumnName("seller_id");
            builder.Property(t => t.ItemTypeId).HasColumnName("item_type_id");
            builder.Property(t => t.PublicationDate).HasColumnName("publication_date");
            builder.Property(t => t.NumberOfViews).HasColumnName("number_of_views");
            builder.Property(t => t.IsClose).HasColumnName("is_close");

            builder.HasOne(t => t.Seller).WithMany(t => t.Items).HasForeignKey(t => t.SellerId);
            builder.HasOne(t => t.ItemType).WithMany(t => t.Items).HasForeignKey(t => t.ItemTypeId);
        }
    }
}