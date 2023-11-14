using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class QueriesController : ControllerBase
    {
        IQueries _queriesService;
        public QueriesController(IQueries queriesService)
        {
            _queriesService = queriesService;
        }

        [HttpGet("accounts")]
        public ActionResult GetAccounts()
        {
            return Ok(_queriesService.GetAllAccounts());
        }

        [HttpGet("accounts/{id}")]
        public ActionResult GetAccountById(Guid id)
        {
            return Ok(_queriesService.GetByIdAccount(id));
        }

        [HttpGet("transactions")]
        public ActionResult GetAllTransaction()
        {
            return Ok(_queriesService.GetAllTransactions());
        }

        [HttpGet("transactions/{id}")]
        public ActionResult GetTransactionById(Guid id)
        {
            return Ok(_queriesService.GetByIdTransaction(id));
        }

        [HttpGet("transactions/accounts/{id}")]
        public ActionResult GetTransactionsByAccount(Guid id) 
        {
            return Ok(_queriesService.TransactionAccountGetById(id));
        }
    }
}
