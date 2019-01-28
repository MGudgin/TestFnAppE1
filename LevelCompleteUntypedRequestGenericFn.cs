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
    using Newtonsoft.Json;

    public static class LevelCompleteUntypedRequestGenericFn
    {
        [FunctionName(nameof(LevelCompleteUntypedRequestGenericFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest httpReq,
            ILogger log)
        {
            log.LogInformation($"{nameof(LevelCompleteUntypedRequestGenericFn)} processed a request.");

            string body = await httpReq.ReadAsStringAsync();
            EntityRequest<LevelComplete> req = JsonConvert.DeserializeObject<EntityRequest<LevelComplete>>(body);

            log.LogInformation($"Level: {req.parameter.level} Points: {req.parameter.points}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Congrats on completing level {req.parameter.level}");
        }
    }
}
