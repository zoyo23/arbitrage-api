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

        [DisableConcurrentExecution(timeoutInSeconds: int.MaxValue)]
        public void RunBackground()
        {
            var contador = 0;

            while (contador <= 100)
            {
                Console.WriteLine("{0,-20} | {1, 4} | {2, 15} | {3, 10} | {4, 20}", DateTime.Now, contador, "Execução Tarefa em segundo plano", Thread.CurrentThread.Name, Environment.MachineName);
                contador++;
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }

        }
    }
}
