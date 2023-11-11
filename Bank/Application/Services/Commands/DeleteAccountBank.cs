using Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class DeleteAccountBank
    {
        BankContext context;

        public DeleteAccountBank(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void BankAccountDelete(Guid id)
        {
            var accountActual = context.BankAccounts.Find(id);
            var transactions = context.Transactions.Where(item => item.IdAccount == id);
            
            if(accountActual != null)
            {
                context.Remove(accountActual);
                context.Remove(transactions);
                context.SaveChanges();
            }
        }
    }
}
