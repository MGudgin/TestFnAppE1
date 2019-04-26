// Copyright (C) Microsoft Corporation. All rights reserved.

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
    using System.Net.Http;

    public static class LevelCompleteUntypedRequestMessageGenericFn
    {
        [FunctionName(nameof(LevelCompleteUntypedRequestMessageGenericFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage httpReq,
            ILogger log)
        {
            log.LogInformation($"{nameof(LevelCompleteUntypedRequestMessageGenericFn)} processed a request.");

            FunctionExecutionContext<LevelComplete> req = await httpReq.Content.ReadAsAsync<FunctionExecutionContext<LevelComplete>>();

            log.LogInformation($"Level: {req.FunctionParameter.level} Points: {req.FunctionParameter.points}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Congrats on completing level {req.FunctionParameter.level}");
        }
    }
}