namespace MvcMovie.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int obj);
        void Save();
    }
}
