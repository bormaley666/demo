namespace Demo.Application;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
