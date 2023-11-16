using Application.Interface.Repository;
using Application.Interface;
using Application.Services.Commands;
using Application.Services.Querie;
using Domain.Models;

namespace Api
{
    public static class DependencyInjections
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IQueriesRepository<BankAccount>, BankAccountQuieres>();
            builder.Services.AddScoped<ICommandsRepository<BankAccount>, BankAccountCommands>();
            //builder.Services.AddScoped<IQueriesRepository<Transaction>, TransactionQueries>();
            builder.Services.AddScoped<ICommandsRepository<Transaction>, TransactionsCommands>();
            builder.Services.AddScoped<ITransactionQueries, TransactionQueries>();
        }
    }
}
