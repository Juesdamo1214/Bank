using Application.Interface;
using Application.Repository;
using Application.Services.Commands;
using Application.Services.Querie;
using Domain.Models;
using Infrastructure;

namespace Api
{
    public static class DependencyInjections
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<BankAccount>, BankRepository<BankAccount>>();
            builder.Services.AddScoped<IRepository<Transaction>, BankRepository<Transaction>>();
            builder.Services.AddScoped<BankAccountQuieres>();
            builder.Services.AddScoped<ITransactionQueries<Transaction>, TransactionQueries>();
            builder.Services.AddScoped<TransactionQueries>();
            builder.Services.AddScoped<BankAccountCommands>();
            builder.Services.AddScoped<TransactionsCommands>();
        }
    }
}
