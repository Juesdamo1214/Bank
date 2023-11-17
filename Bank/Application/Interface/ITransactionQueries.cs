namespace Application.Interface
{
    public interface ITransactionQueries<T>
    {
        IEnumerable<T> TransactionAccountOwner(Guid id);
    }
}
