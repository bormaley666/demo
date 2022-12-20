using Demo.Application;

namespace Demo.DataLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataDbContext _db;

    public UnitOfWork(DataDbContext db)
    {
        _db = db;
    }

    public Task<int> SaveChangesAsync()
    {
        return _db.SaveChangesAsync();
    }
}
