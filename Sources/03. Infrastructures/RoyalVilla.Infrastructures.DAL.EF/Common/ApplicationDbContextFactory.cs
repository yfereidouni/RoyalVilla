using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.Common;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        builder.UseSqlServer("Server =.,1433;Database=RoyalVilla_DB;User Id=dbuser;Password=1qaz!QAZ;MultipleActiveResultSets=True;TrustServerCertificate=True;");

        return new ApplicationDbContext(builder.Options);
    }
}