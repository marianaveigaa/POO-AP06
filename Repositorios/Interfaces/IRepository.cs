namespace ConsoleApp.Repositories.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    void Add(T entity);
    T? GetById(Guid id);
    List<T> GetAll();
    void Update(T entity);
    bool Remove(Guid id);
    void SaveChanges();
}