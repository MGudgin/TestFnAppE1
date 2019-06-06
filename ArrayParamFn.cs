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

    public static class ArrayParamFn
    {
        [FunctionName("ArrayParamFn")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] FunctionExecutionContext<string[]> req,
            ILogger log)
        {
            log.LogInformation($"{nameof(ArrayParamFn)} processed a request.");

            log.LogInformation($"Parameter: {req.FunctionParameter}");

            await Task.Delay(50); // Simulate some async work

            return req.FunctionParameter;
        }
    }
}
