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

    public static class LevelCompleteFn
    {
        [FunctionName("LevelComplete")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] LevelCompleteRequest req,
            ILogger log)
        {
            log.LogInformation("LevelComplete processed a request.");

            log.LogInformation($"Level: {req.level.level} Points: {req.level.points}");

            await Task.Delay(50); // Simulate some async work

            return(ActionResult)new OkObjectResult(string.Empty);
        }
    }
}
