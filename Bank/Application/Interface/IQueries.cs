using Domain.Models;

namespace Application.Interface
{
    public interface IQueries
    {
        IEnumerable<BankAccount> GetAllAccounts();
        BankAccount GetByIdAccount(Guid id);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetByIdTransaction(Guid id);
        IEnumerable<Transaction> TransactionAccountGetById(Guid id);
    }
}
