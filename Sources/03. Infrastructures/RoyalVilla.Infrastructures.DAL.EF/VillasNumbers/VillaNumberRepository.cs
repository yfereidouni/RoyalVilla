using Microsoft.EntityFrameworkCore;
using RoyalVilla.Core.Contracts.VillasNumbers;
using RoyalVilla.Core.Entities.VillasNumbers;
using RoyalVilla.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.VillasNumbers;

public sealed class VillaNumberRepository : BaseRepository<VillaNumber>, IVillaNumberRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VillaNumberRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _dbContext.VillasNumbers.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}