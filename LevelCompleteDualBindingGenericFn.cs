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

    public static class LevelCompleteDualBindingGenericFn
    {
        [FunctionName(nameof(LevelCompleteDualBindingGenericFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] EntityRequest<LevelComplete> req,
            HttpRequest httpRequest,
            ILogger log)
        {
            log.LogInformation($"{nameof(LevelCompleteDualBindingGenericFn)} processed a request.");

            log.LogInformation($"Level: {req.parameter.level} Points: {req.parameter.points}");

            log.LogInformation($"HTTPS: {httpRequest.IsHttps}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Congrats on completing level {req.parameter.level}");
        }
    }
}