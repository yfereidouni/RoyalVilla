using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalVilla.Core.Entities.VillasNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.VillasNumbers;

public sealed class VillaNumberConfiguration : IEntityTypeConfiguration<VillaNumber>
{
    public void Configure(EntityTypeBuilder<VillaNumber> builder)
    {
        //builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.SpecialDetails).HasMaxLength(50);

        builder.HasData(
            new VillaNumber
            {
                VillaNo = 101,
                VillaId = 1,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 102,
                VillaId = 1,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 103,
                VillaId = 1,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 201,
                VillaId = 2,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 202,
                VillaId = 2,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 301,
                VillaId = 3,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 401,
                VillaId = 4,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new VillaNumber
            {
                VillaNo = 501,
                VillaId = 5,
                SpecialDetails = "this is a dummy text.",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
            );
    }
}
