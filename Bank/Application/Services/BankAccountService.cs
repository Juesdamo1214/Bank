//using Application.Context;
//using Domain.Models;

//namespace Application.Services
//{
//    public class BankAccountService
//    {
//        BankContext context;

//        public BankAccountService(BankContext dbcontext)
//        {
//            context = dbcontext;
//        }

//        public IEnumerable<BankAccount> BankAccountGetAll()
//        {
//            return context.BankAccounts;
//        }
//        public BankAccount GetBankAccountById(Guid id)
//        {
//            return context.BankAccounts.FirstOrDefault(account => account.IdAccount == id);
//        }
//        public void CreateBankAccount(BankAccount bankAccount)
//        {
//            context.BankAccounts.Add(bankAccount);
//            context.SaveChanges();
//        }
//        public void UpdateBankAccount(Guid id,BankAccount bankAccount) 
//        {
//            var actualAccount = context.BankAccounts.Find(id);

//            if (actualAccount != null)
//            {

//            }
//        }
//    }
//}
