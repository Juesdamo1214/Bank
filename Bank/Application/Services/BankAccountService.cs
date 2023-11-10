using Application.Context;
using Domain.Models;

namespace Application.Services
{
    public class BankAccountService
    {
        BankContext context;

        public BankAccountService(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return context.BankAccounts;
        }
    }
}
