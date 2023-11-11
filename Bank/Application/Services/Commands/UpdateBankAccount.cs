using Application.Context;
using Domain.Models;

namespace Application.Services.Commands
{
    public class UpdateBankAccount
    {
        BankContext context;

        public UpdateBankAccount(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void BankAccountUpdate(Guid id, BankAccount bankAccount)
        {
            var accountActual = context.BankAccounts.Find(id);

            if (accountActual != null) 
            {
                accountActual.Holder = bankAccount.Holder;

                context.SaveChanges();
            }
        }
    }
}
