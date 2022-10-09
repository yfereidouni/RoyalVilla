using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalVilla.Core.Entities.LocalUsers;
using RoyalVilla.Core.Entities.Villas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.LocalUsers;

public sealed class LocalUserConfiguration : IEntityTypeConfiguration<LocalUser>
{
    public void Configure(EntityTypeBuilder<LocalUser> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.HasData(
            new LocalUser
            {
                Id = 1,
                Name = "Yasser",
                UserName = "admin",
                Password = "admin",
                Role = "admin"
            },
            new LocalUser
            {
                Id = 2,
                Name = "Majid",
                UserName = "user",
                Password = "user",
                Role = "user"
            }
        );
    }
}
