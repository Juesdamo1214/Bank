using Application.Context;
using Application.Interface;
using Domain.Models;

namespace Application.Services.Queries
{
    public class BankAccountGetAll
    {
        BankContext context;
        
        public BankAccountGetAll(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return context.BankAccounts;
        }
    }
}
