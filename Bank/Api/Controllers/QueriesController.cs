using Application.Interface;
using Application.Interface.Repository;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("queries")]
    public class QueriesController : ControllerBase
    {
        IQueriesRepository<BankAccount> _queriesBankAccount;
        IQueriesRepository<Transaction> _queriesTransaction;
        ITransactionQueries _querieTransactionAccount;
        public QueriesController(IQueriesRepository<Transaction> queriesTransaction, IQueriesRepository<BankAccount> queriesBankAccount, ITransactionQueries querieTransactionAccount)
        {
            _queriesTransaction = queriesTransaction;
            _queriesBankAccount = queriesBankAccount;
            _querieTransactionAccount = querieTransactionAccount;
        }

        [HttpGet("accounts")]
        public ActionResult GetAccounts()
        {
            return Ok(_queriesBankAccount.GetAll());
        }

        [HttpGet("accounts/{id}")]
        public ActionResult GetAccountById(Guid id)
        {
            return Ok(_queriesBankAccount.GetById(id));
        }

        [HttpGet("transactions")]
        public ActionResult GetAllTransaction()
        {
            return Ok(_queriesTransaction.GetAll());
        }

        [HttpGet("transactions/{id}")]
        public ActionResult GetTransactionById(Guid id)
        {
            return Ok(_queriesTransaction.GetById(id));
        }

        [HttpGet("transactions/accounts/{id}")]
        public ActionResult GetTransactionsByAccount(Guid id) 
        {
            return Ok(_querieTransactionAccount.TransactionAccountOwner(id));
        }
    }
}
