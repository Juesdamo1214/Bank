using Application.Context;
using Domain.Enum;
using Domain.Models;

namespace Application.Services.Commands
{
    public class TransactionAccount
    {
        BankContext context;

        public TransactionAccount(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void AccountTransaction(Guid id, Transaction transaction)
        {
            var account = context.BankAccounts.Find(id);
            if (account == null)
            {
                if (transaction.Type == TransferType.Deposit) account.Balance += transaction.Value;
                if (transaction.Type == TransferType.Retirement) account.Balance -= transaction.Value;
            }

           
            
            
            

        }
    }
}
