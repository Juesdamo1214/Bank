using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class QueriesController : ControllerBase
    {
        IQueries _queriesService;

        public QueriesController(IQueries queriesService)
        {
            _queriesService = queriesService;
        }

        public ActionResult Get()
        {
            return Ok(_queriesService.GetAllAccounts());
        }
    }
}
