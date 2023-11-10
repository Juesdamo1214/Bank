using Application.Context;
using Application.Interface;
using Domain.Models;

namespace Application.Services.Queries
{
    public class GetBankAccountById
    {
        BankContext context;

        public GetBankAccountById(BankContext dbcontext)
        {
            context = dbcontext;
        }
        public BankAccount GetByIdAccount(Guid id) 
        {
            return context.BankAccounts.FirstOrDefault(account => account.IdAccount == id);
        }
    }
}
