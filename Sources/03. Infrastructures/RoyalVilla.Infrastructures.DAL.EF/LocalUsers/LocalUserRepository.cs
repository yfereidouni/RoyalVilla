using RoyalVilla.Core.Contracts.LocalUsers;
using RoyalVilla.Core.Entities.LocalUsers;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.LocalUsers;

public sealed class LocalUserRepository : BaseRepository<LocalUser>, ILocalUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LocalUserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LocalUser> UpdateAsync(LocalUser entity)
    {
        //entity.UpdatedDate = DateTime.Now;
        _dbContext.LocalUsers.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
