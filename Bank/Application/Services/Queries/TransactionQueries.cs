using Application.Context;
using Application.Interface;
using Domain.Models;

namespace Application.Services.Querie
{
    public class TransactionQueries : ITransactionQueries
    {
        BankContext context;

        public TransactionQueries(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public Transaction GetById(Guid id)
        {
            return context.Transactions.FirstOrDefault(account => account.IdTransaction == id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.Transactions;
        }
        public IEnumerable<Transaction> TransactionAccountOwner(Guid id)
        {
            var listTransaction = context.Transactions.Where(item => item.IdAccount == id);
            return listTransaction.ToList();
        }
    }
}
