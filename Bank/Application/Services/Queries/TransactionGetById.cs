using Application.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
    public class TransactionGetById
    {
        BankContext context;

        public TransactionGetById(BankContext dbcontext)
        {
            context = dbcontext;
        }
        public Transaction GetByIdTransaction(Guid id)
        {
            return context.Transactions.FirstOrDefault(transaction => transaction.IdTransaction == id);
        }
    }
}
