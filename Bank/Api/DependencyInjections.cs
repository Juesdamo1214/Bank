using Application.Interface.Repository;
using Application.Interface;
using Application.Services.Commands;
using Application.Services.Querie;
using Domain.Models;

namespace Api
{
    public class DependencyInjections
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IQueriesRepository<BankAccount>, BankAccountQuieres>();
            services.AddScoped<ICommandsRepository<BankAccount>, BankAccountCommands>();
            //builder.Services.AddScoped<IQueriesRepository<Transaction>, TransactionQueries>();
            services.AddScoped<ICommandsRepository<Transaction>, TransactionsCommands>();
            services.AddScoped<ITransactionQueries, TransactionQueries>();
        }
    }
}
