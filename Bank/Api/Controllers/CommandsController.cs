using Api.Controllers._Resource;
using Application.Interface;
using Application.Interface.Repository;
using Application.Services.Commands;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("commands")]
    public class CommandsController : ControllerBase
    {
        private readonly BankAccountCommands _commandsBankAccount;
        private readonly TransactionsCommands _commandsTransaction;

        public CommandsController(BankAccountCommands commandsBankAccount, TransactionsCommands commandsTransaction)
        {
            _commandsBankAccount = commandsBankAccount;
            _commandsTransaction = commandsTransaction;
        }

        [HttpPost("account")]
        public IActionResult CreateAccount([FromBody] BankAccount bankAccount)
        {
            _commandsBankAccount.create(bankAccount);
            return Ok();
        }

        [HttpPut("account/{id}")]
        public IActionResult UpdateAccount(Guid id, [FromBody] BankAccount bankAccount)
        {
            _commandsBankAccount.update(id, bankAccount);
            return Ok();
        }

        [HttpDelete("account/{id}")]

        public IActionResult DeleteAccount(Guid id)
        {
            _commandsBankAccount.delete(id);
            return Ok();
        }

        [HttpPost("transaction")]
        public IActionResult CreateTransaction([FromBody] Transaction transaction)
        {
            var validation = _commandsTransaction.Create(transaction);
            if( validation == Resource.ExitoTransacion) return Ok(validation);
            return BadRequest(validation);
        }

        [HttpPut("transaction/{id}")]
        public IActionResult UpdateTransaction(Guid id, [FromBody] Transaction transaction)
        {
            _commandsTransaction.update(id, transaction);
            return Ok();
        }

        [HttpDelete("transaction/{id}")]

        public IActionResult DeleteTransaction(Guid id)
        {
            _commandsTransaction.delete(id);
            return Ok();
        }



    }

}
