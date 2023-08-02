namespace GenericService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T entity);

        bool Update(T model);

        T GetById(int id);

        IEnumerable<T> GetAll();

        bool Delete(T model);
    }
}
