using Application.Context;
using Domain.Models;

namespace Application.Services.Queries
{
    public class GetByIdTransactionAccount
    {
        BankContext context;
        
        public GetByIdTransactionAccount(BankContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Transaction> TransactionAccountGetById(Guid id)
        {
            var listTransaction = context.Transactions.Where(item => item.IdAccount == id);
            return listTransaction.ToList();
        }
    }
}
