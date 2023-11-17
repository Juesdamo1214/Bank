using Application.Context;
using Application.Interface.Repository;
using Domain.Enum;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services.Commands
{
    public class TransactionsCommands
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public TransactionsCommands(IRepository<Transaction> transactionRepository, IRepository<BankAccount> bankAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public void create(Transaction transaction)
        {
            var account = _bankAccountRepository.GetById(transaction.IdAccount);
            if (account != null)
            {
                if(transaction.Type == TransferType.Deposit)
                {
                    account.Balance += transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Add(transaction);
                }
                if (transaction.Type == TransferType.Retirement)
                {
                    account.Balance -= transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Add(transaction);
                }
            }
        }

        public void delete(Guid id)
        {
            var transaction = _transactionRepository.GetById(id);
            var account = _bankAccountRepository.GetById(transaction.IdAccount);

            if (transaction != null)
            {
                if (transaction.Type == TransferType.Deposit)
                {
                    account.Balance -= transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Delete(transaction);
                }
                if (transaction.Type == TransferType.Retirement)
                {
                    account.Balance += transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Delete(transaction);
                }
            }
        }

        public void update(Guid id, Transaction command)
        {
            var transaction = _transactionRepository.GetById(id);
            var account = _bankAccountRepository.GetById(transaction.IdAccount);

            if (transaction != null)
            {
                if(transaction.Type == TransferType.Deposit)
                {
                        account.Balance -= transaction.Value;
                        transaction.Value = command.Value;
                        account.Balance += transaction.Value;
                        _bankAccountRepository.Update(account);
                        _transactionRepository.Update(transaction);
                        
                }
                if (transaction.Type == TransferType.Retirement)
                {
                    account.Balance += transaction.Value;
                    transaction.Value = command.Value;
                    account.Balance -= transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Update(transaction);
                }
            }
        }
    }
}
