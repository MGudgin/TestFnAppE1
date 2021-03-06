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

    public static class TestDualBindingFn
    {
        [FunctionName(nameof(TestDualBindingFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] Person person,
            HttpRequest httpRequest,
            ILogger log)
        {
            log.LogInformation($"{nameof(TestDualBindingFn)} processed a request.");

            log.LogInformation($"Name: {person.firstName} {person.lastName}");

            log.LogInformation($"HTTPS: {httpRequest.IsHttps}");

            string body = await httpRequest.ReadAsStringAsync();

            log.LogInformation($"Body: {body}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Hello, {person.firstName}");
        }
    }
}
