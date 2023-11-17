using Application.Context;
using Application.Interface;
using Domain.Models;
using Infrastructure.Repository;
using System.Security.AccessControl;

namespace Application.Services.Querie
{
    public class TransactionQueries : ITransactionQueries<Transaction>
    {
        private readonly IRepository<Transaction> _repository;
        public TransactionQueries(IRepository<Transaction> repository)
        {
            _repository = repository;
        }

        public Transaction GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Transaction> TransactionAccountOwner(Guid id)
        {
            var transactionsList = _repository.GetAll();
            var listTransaction = transactionsList.Where(item => item.IdAccount == id);
            return listTransaction;
        }
    }
}
