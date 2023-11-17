using Application.Interface;
using Application.Interface.Repository;
using Application.Services.Querie;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("queries")]
    public class QueriesController : ControllerBase
    {
        private readonly BankAccountQuieres _queriesBankAccount;
        private readonly TransactionQueries _queriesTransactionAccount;
        private readonly ITransactionQueries<Transaction> _transactionquerie;

        public QueriesController(BankAccountQuieres queriesBankAccount, TransactionQueries querieTransactionAccount, ITransactionQueries<Transaction> transactionquerie)
        {
            _queriesBankAccount = queriesBankAccount;
            _queriesTransactionAccount = querieTransactionAccount;
            _transactionquerie = transactionquerie;
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
            return Ok(_queriesTransactionAccount.GetAll());
        }

        [HttpGet("transactions/{id}")]
        public ActionResult GetTransactionById(Guid id)
        {
            return Ok(_queriesTransactionAccount.GetById(id));
        }

        [HttpGet("transactions/accounts/{id}")]
        public ActionResult GetTransactionsByAccount(Guid id) 
        {
            return Ok(_transactionquerie.TransactionAccountOwner(id));
        }
    }
}
