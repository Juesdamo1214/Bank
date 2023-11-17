using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services.Commands
{
    public class BankAccountCommands 
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public BankAccountCommands(IRepository<BankAccount> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task create(BankAccount command)
        {
            _bankAccountRepository.Add(command);
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
