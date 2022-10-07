using RoyalVilla.Core.Contracts.Villas;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Infrastructures.DAL.EF.Common;

namespace RoyalVilla.Infrastructures.DAL.EF.Villas;

public sealed class VillaRepository : BaseRepository<Villa>, IVillaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VillaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Villa> UpdateAsync(Villa entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _dbContext.Villas.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
