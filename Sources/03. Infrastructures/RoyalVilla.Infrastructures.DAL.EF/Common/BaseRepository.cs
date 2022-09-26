using Microsoft.EntityFrameworkCore;
using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Infrastructures.DAL.EF.Common;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await SaveAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (filter != null)
            query = query.Where(filter);

        //Query execute here! This is "Deferred execution"
        return await query.ToListAsync();

    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (!tracked)
            query.AsNoTracking();
        
        if (filter != null)
            query = query.Where(filter);

        //Query execute here! This is "Deferred execution"
        return await query.FirstOrDefaultAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
