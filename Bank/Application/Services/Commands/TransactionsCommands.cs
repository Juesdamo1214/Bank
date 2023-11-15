using Application.Context;
using Application.Interface.Repository;
using Domain.Enum;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class TransactionsCommands : ICommandsRepository<Transaction>
    {
        BankContext context;

        public TransactionsCommands(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void create(Transaction transaction)
        {
            var account = context.BankAccounts.Find(transaction.IdAccount);
            if (account != null)
            {
                if (transaction.Type == TransferType.Deposit)
                {
                    account.Balance += transaction.Value;
                    context.SaveChanges();
                }
                if (transaction.Type == TransferType.Retirement)
                {
                    account.Balance -= transaction.Value;
                    context.SaveChanges();
                }
            }
        }

        public void delete(Guid id)
        {
            var transaction = context.Transactions.Find(id);
            var account = context.BankAccounts.Find(transaction.IdAccount);
            if (transaction != null)
            {
                if(transaction.Type == TransferType.Deposit)
                {
                    account.Balance -= transaction.Value;
                    context.Remove(transaction);
                    context.SaveChanges();
                }
                if(transaction.Type == TransferType.Retirement)
                {
                    account.Balance += transaction.Value;
                    context.Remove(transaction);
                    context.SaveChanges();
                }
            }
        }

        public void update(Guid id, Transaction command)
        {
            var transaction = context.Transactions.Find(id);
            var account = context.BankAccounts.Find(transaction.IdAccount);

            if (transaction != null)
            {
                if( command.Type == TransferType.Deposit)
                {
                    transaction.Value = command.Value;
                    transaction.Type = command.Type;
                    account.Balance += transaction.Value;
                    context.SaveChanges();
                }
                if (command.Type == TransferType.Retirement)
                {
                    transaction.Value = command.Value;
                    transaction.Type = command.Type;
                    account.Balance -= transaction.Value;
                    context.SaveChanges();
                }
            }
        }
    }
}
