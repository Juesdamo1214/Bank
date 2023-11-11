using Domain.Models;

namespace Application.Interface
{
    public interface ICommands
    {
        void BankAccountCreate(BankAccount bankAccount);
        void BankAccountUpdate(Guid id, BankAccount bankAccount);
        void BankAccountDelete(Guid id);
        void AccountTransaction(Guid id, Transaction transaction);

    }
}
