using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalVilla.Core.Entities.Villas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.Villas;

public sealed class VillaConfiguration : IEntityTypeConfiguration<Villa>
{
    public void Configure(EntityTypeBuilder<Villa> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.HasData(
            new Villa
            {
                Id = 1,
                Name = "Royal Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.",
                ImageUrl = "https://www.dotnetmastery.com/bluevillaimages/villa1.jpg",
                Occupancy = 5,
                Rate = 200,
                Sqft = 550,
                Amenity = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            },
            new Villa
            {
                Id = 2,
                Name = "Peremium Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.",
                ImageUrl = "https://www.dotnetmastery.com/bluevillaimages/villa2.jpg",
                Occupancy = 4,
                Rate = 550,
                Sqft = 900,
                Amenity = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            },
            new Villa
            {
                Id = 3,
                Name = "Luxary Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.",
                ImageUrl = "https://www.dotnetmastery.com/bluevillaimages/villa3.jpg",
                Occupancy = 4,
                Rate = 600,
                Sqft = 1100,
                Amenity = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            },
            new Villa
            {
                Id = 4,
                Name = "Diamond Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.",
                ImageUrl = "https://www.dotnetmastery.com/bluevillaimages/villa4.jpg",
                Occupancy = 3,
                Rate = 800,
                Sqft = 680,
                Amenity = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            },
            new Villa
            {
                Id = 5,
                Name = "Diamond Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque messa auctor sit. Donce ex damilar nur duch calliperist.",
                ImageUrl = "https://www.dotnetmastery.com/bluevillaimages/villa5.jpg",
                Occupancy = 4,
                Rate = 650,
                Sqft = 1100,
                Amenity = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            }
            );
    }
}
