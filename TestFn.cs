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

    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public static class TestFn
    {
        [FunctionName(nameof(TestFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] Person person,
            ILogger log)
        {
            log.LogInformation($"{nameof(TestFn)} processed a request.");

            log.LogInformation($"Name: {person.firstName} {person.lastName}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Hello, {person.firstName}");
        }
    }
}
