namespace LogApi.Repositories.IRepositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T item);
        bool Update(string id, T item);
        bool Delete(string id);
    }
}