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

    public static class LevelCompleteDualBindingGenericCrashFn
    {
        [FunctionName(nameof(LevelCompleteDualBindingGenericCrashFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] FunctionExecutionContext<LevelComplete> req,
            HttpRequest httpRequest,
            ILogger log)
        {
            log.LogInformation($"{nameof(LevelCompleteDualBindingGenericFn)} processed a request.");

            log.LogInformation($"Level: {req.FunctionParameter.level} Points: {req.FunctionParameter.points}");

            log.LogInformation($"HTTPS: {httpRequest.IsHttps}");

            await Task.Delay(50); // Simulate some async work

            // Crash
            string crash = null;
            log.LogInformation($"String is {crash.Length} characters");

            return (ActionResult)new OkObjectResult($"Congrats on completing level {req.FunctionParameter.level}");
        }
    }
}
