namespace Online_Learning_Platform.Repository
{
    using System.Collections.Generic;

    namespace Online_Learning_Platform.Repository
    {
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Add(T entity);
            void Update(T entity);
            void Delete(int id);
            void Save();
        }
    }

}
