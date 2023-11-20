﻿using Application.Interface;
using Application.Repository;
using Domain.Models;

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
