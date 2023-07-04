namespace KleineZelfstandige.Repository.Framework
{
    interface IJsonHandler<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Remove(int id);
        bool Update(T item);
    }
}
