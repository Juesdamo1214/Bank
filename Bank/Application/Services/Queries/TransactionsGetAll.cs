using Application.Context;
using Domain.Models;

namespace Application.Services.Queries
{
    public class TransactionsGetAll
    {
        BankContext context;

        public TransactionsGetAll(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return context.Transactions;
        }
    }
}
