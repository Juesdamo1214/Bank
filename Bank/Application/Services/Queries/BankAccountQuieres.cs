using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services.Querie
{
    public class BankAccountQuieres 
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public BankAccountQuieres(IRepository<BankAccount> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public BankAccount GetById(Guid id)
        {
            return _bankAccountRepository.GetById(id);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _bankAccountRepository.GetAll();
        }
    }
}
