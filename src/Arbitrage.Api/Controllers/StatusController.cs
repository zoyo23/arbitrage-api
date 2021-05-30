using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace Arbitrage.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            RecurringJob.RemoveIfExists("Biscoint_Bot");
            RecurringJob.AddOrUpdate("Biscoint_Bot", () => RunBackground(), "* * * * * ");

            return Ok("Funfando! :P");
        }

        [DisableConcurrentExecution(timeoutInSeconds: 10 * 60)]
        public void RunBackground()
        {
            var contador = 0;

            while (contador <= 80)
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} | {contador} -> Teste de Background Task. | Thread {Thread.CurrentThread.Name}");
                contador++;
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }

        }
    }
}
