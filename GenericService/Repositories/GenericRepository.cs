using GenericService.Models;
using GenericService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GenericService.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<T> _entity = null;

        public GenericRepository(DatabaseContext databaseContext) 
        {
            _dbContext = databaseContext;
            _entity = _dbContext.Set<T>();
        }
        public bool Add(T model)
        {
            try {
                _entity.Add(model);
                _dbContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool Delete(T model)
        {
            try {
                _entity.Remove(model);
                _dbContext.SaveChanges();

                return true;
            } catch {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public bool Update(T model)
        {
            try {
                _entity.Update(model);
                _dbContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }
}
