using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.Data.Domain
{
    public class CountryEntity : Entity, IEntityTypeConfiguration<CountryEntity>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.Property(value => value.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(value => value.Code)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
