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
    ///internal DbSet<T> DbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        ///this.DbSet = _dbContext.Set<T>();

        //_dbContext.VillasNumbers.Include(u => u.Villa);
    }
    public async Task CreateAsync(T entity)
    {
        ///await DbSet.AddAsync(entity);
        _dbContext.Set<T>().Add(entity);
        await SaveAsync();
    }

    //"Villa,VillaSpecial"
    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        //Query execute here! This is "Deferred execution"
        return await query.ToListAsync();

    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (!tracked)
            query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

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
