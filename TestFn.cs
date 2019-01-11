namespace PlayFab.CloudScript
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class Person
    {
        public string firstName;
        public string lastName;
    }

    public static class TestFn
    {
        [FunctionName("TestFn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] Person person,
            ILogger log)
        {
            log.LogInformation("LevelComplete processed a request.");

            log.LogInformation($"Name: {person.firstName} {person.lastName}");

            await Task.Delay(50); // Simulate some async work

            return(ActionResult)new OkObjectResult($"Hello, {person.firstName}");
        }
    }
}
