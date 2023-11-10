using Application.Context;

namespace Application.Services
{
    public class BankAccountService
    {
        BankContext context;

        public BankAccountService(BankContext dbcontext)
        {
            context = dbcontext;
        }
    }
}
