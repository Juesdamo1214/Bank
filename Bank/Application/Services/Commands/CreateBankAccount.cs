using Application.Context;
using Application.Interface;
using Domain.Models;

namespace Application.Services.Commands
{
    public class CreateBankAccount 
    {
        BankContext context;

        public CreateBankAccount(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void BankAccountCreate(BankAccount bankAccount)
        {
            context.Add(bankAccount);
            context.SaveChanges();
        }
    }
}
