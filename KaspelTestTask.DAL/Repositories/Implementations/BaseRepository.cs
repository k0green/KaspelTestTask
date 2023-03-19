using KaspelTestTask.DAL.Data;
using KaspelTestTask.DAL.Data.Entities;
using KaspelTestTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaspelTestTask.DAL.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;
    protected DbSet<T> _dbSet;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public virtual async Task<T> GetByIdAsync(long id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<List<T>> GetAllAsync() 
        => await _dbSet.ToListAsync();

    public virtual async Task AddAsync(T model)
    {
        await _dbSet.AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T model)
    {
        _dbSet.Update(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T model)
    {
        _dbSet.Remove(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteByIdAsync(long id)
    {
        await DeleteAsync(await GetByIdAsync(id));
        await _dbContext.SaveChangesAsync();
    }
}