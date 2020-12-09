using CachingSample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.DataAccess
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));

            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.Code).HasMaxLength(10);

            builder.HasKey(x => x.Id);
        }
    }
}
