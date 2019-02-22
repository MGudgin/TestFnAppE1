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

    public class LevelCompleteResult 
    {
        public string SomeMessage { get;set;}
        public int SomeLevel { get;set;}
    }

    public static class LevelCompleteFnTypedResult
    {
        [FunctionName(nameof(LevelCompleteFnTypedResult))]
        public static async Task<LevelCompleteResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] LevelCompleteRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(LevelCompleteFn)} processed a request.");

            log.LogInformation($"Level: {req.FunctionParameter.level} Points: {req.FunctionParameter.points}");

            await Task.Delay(50); // Simulate some async work

            return new LevelCompleteResult
            {
                SomeMessage = "Congrats on completing a level",
                SomeLevel = req.FunctionParameter.level
            };
        }
    }
}
