using Application.Services.Resources;
using Domain.Enum;
using Domain.Models;
using Application.Repository;

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

        public string Create(Transaction transaction)
        {
            var account = _bankAccountRepository.GetById(transaction.IdAccount);
            if (account == null) return Resource.Cuenta;
            if(transaction.Type == TransferType.Deposit)
            {
                account.Balance += transaction.Value;
                _bankAccountRepository.Update(account);
                _transactionRepository.Add(transaction);
                return Resource.ExitoTransacion;
            }
            if (transaction.Type == TransferType.Retirement)
            {
                if(account.Balance >=  transaction.Value) 
                {
                    account.Balance -= transaction.Value;
                    _bankAccountRepository.Update(account);
                    _transactionRepository.Add(transaction);
                    return Resource.ExitoTransacion;
                }
                return Resource.BalanceMenor;
            }
            return Resource.Tipo;
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
