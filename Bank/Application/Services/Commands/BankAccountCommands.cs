using Application.Context;
using Application.Interface.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class BankAccountCommands : ICommandsRepository<BankAccount>
    {
        private readonly BankContext context;

        public BankAccountCommands(BankContext dbcontext)
        {
            context = dbcontext;
        }

        public void create(BankAccount command)
        {
            context.Add(command);
            context.SaveChanges();
        }

        public void delete(Guid id)
        {
            var accountActual = context.BankAccounts.Find(id);
            var transactions = context.Transactions.Where(item => item.IdAccount == id);

            if (accountActual != null)
            {
                context.Remove(accountActual);
                context.Remove(transactions);
                context.SaveChanges();
            }
        }

        public void update(Guid id, BankAccount command)
        {
            var accountActual = context.BankAccounts.Find(id);

            if (accountActual != null)
            {
                accountActual.Owner = command.Owner;

                context.SaveChanges();
            }
        }
    }
}
