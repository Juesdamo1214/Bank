using Application.Context;
using Application.Interface.Repository;
using Domain.Models;

namespace Application.Services.Querie
{
    public class BankAccountQuieres : IQueriesRepository<BankAccount>
    {
        BankContext context;

        public BankAccountQuieres(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public BankAccount GetById(Guid id)
        {
            return context.BankAccounts.FirstOrDefault(account => account.IdAccount == id);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return context.BankAccounts;
        }
    }
}
