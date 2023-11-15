namespace Application.Interface.Repository
{
    public interface IQueriesRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
