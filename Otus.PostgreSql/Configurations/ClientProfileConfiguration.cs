using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Models.Models;

namespace Otus.PostgreSql.Configurations
{
    public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfileModel>
    {
        public void Configure(EntityTypeBuilder<ClientProfileModel> builder)
        {
            builder.ToTable("client_profile");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Email).HasColumnName("email");
            builder.Property(t => t.PhoneNumber).HasColumnName("phone_number");
            builder.Property(t => t.IsCompany).HasColumnName("is_company");
            builder.Property(t => t.RegistrationDate).HasColumnName("registration_date");
        }
    }
}