using Domain.Models;
using Application.Repository;
using Application.Services.Resources;

namespace Application.Services.Commands
{
    public class BankAccountCommands 
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public BankAccountCommands(IRepository<BankAccount> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public string Create(BankAccount command)
        {
            var account = _bankAccountRepository.GetById(command.IdAccount);
            if (account != null) return Resource.CuentaExiste;
            _bankAccountRepository.Add(command);
            return Resource.CuentaCreada;
        }

        public void delete(Guid id)
        {
            var account = _bankAccountRepository.GetById(id);
            if (account != null)
            {
                _bankAccountRepository.Delete(account);
            }
        }

        public void update(Guid id, BankAccount command)
        {
            var account = _bankAccountRepository.GetById(id);
            if(account != null)
            {
                account.Owner = command.Owner;
                _bankAccountRepository.Update(account);
            }

        }
    }
}
