using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalVilla.Core.Entities.Villas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.VillasNumbers;

public sealed class VillaNumberConfiguration : IEntityTypeConfiguration<VillaNumber>
{
    public void Configure(EntityTypeBuilder<VillaNumber> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.SpecialDetails).HasMaxLength(50);
    }
}
