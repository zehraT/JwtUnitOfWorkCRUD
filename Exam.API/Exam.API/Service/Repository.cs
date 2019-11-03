using Exam.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Exam.API.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _repository;
        public Repository(DataContext dataContext)
        {
            _repository = dataContext.Set<T>();
        }
        public T Add(T entity)
        {
            _repository.Add(entity);

            return entity;
        }

        public bool Delete(int id)
        {
            var result = false;

            var entity = Get(id);

            if (entity != null)
            {
                _repository.Remove(entity);
                result = true;
            }

            return result;
        }

        public T Get(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public T Update(T entity)
        {
            _repository.Update(entity);
            return entity;
        }
        
    }
}
