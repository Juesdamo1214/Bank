using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Commands
{
    public class CommandsControllers : Controller
    {
        ICommands _commands;

        public CommandsControllers(ICommands commands)
        {
            _commands = commands;
        }

        //public ActionResult post([FromBody] BankAccount bankAccount)
        //{

        //}
    }
}
