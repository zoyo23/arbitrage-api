using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Arbitrage.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {

            RecurringJob.AddOrUpdate("Teste", () => RunBackground(), "*/5 * * * * *");

            return Ok("Funfando! :P");
        }

        public void RunBackground()
        {
            Console.WriteLine($"$ Teste de Background Task...");
        }
    }
}
