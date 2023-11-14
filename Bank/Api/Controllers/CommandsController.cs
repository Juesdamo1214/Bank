using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CommandsController : ControllerBase
    {
        ICommands commands;

        public CommandsController(ICommands command)
        {
            commands = command;
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] BankAccount bankAccount)
        {
            commands.BankAccountCreate(bankAccount);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult TransactionAccount(Guid id, [FromBody] Transaction transaction)
        {
            commands.AccountTransaction(id, transaction);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(Guid id, [FromBody] BankAccount bankAccount)
        {
            commands.BankAccountUpdate(id, bankAccount);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteAccount(Guid id)
        {
            commands.BankAccountDelete(id);
            return Ok();
        }
    }

}
