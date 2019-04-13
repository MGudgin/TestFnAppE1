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

    public static class TestDualBindingMessageFn
    {
        [FunctionName(nameof(TestDualBindingMessageFn))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] Person person,
            HttpRequestMessage httpRequestMsg, // NOTE: This does not seem to be supported for dual-bindings. We get the following error on host startup;
                                               // Error indexing method 'TestDualBindingMEssageFn.Run'
                                               // Microsoft.Azure.WebJobs.Host: Error indexing method 'TestDualBindingMEssageFn.Run'. Microsoft.Azure.WebJobs.Host: Cannot bind parameter 'httpRequestMsg' to type HttpRequestMessage. Make sure the parameter Type is supported by the binding. If you're using binding extensions (e.g. Azure Storage, ServiceBus, Timers, etc.) make sure you've called the registration method for the extension(s) in your startup code (e.g. builder.AddAzureStorage(), builder.AddServiceBus(), builder.AddTimers(), etc.).
                                               // and the following error on invocation;
                                               // An unhandled host error has occurred.
                                               // Microsoft.Azure.WebJobs.Host: 'TestDualBindingMessageFn' can't be invoked from Azure WebJobs SDK. Is it missing Azure WebJobs SDK attributes?.
            ILogger log)
        {
            log.LogInformation($"{nameof(TestDualBindingMessageFn)} processed a request.");

            log.LogInformation($"Name: {person.firstName} {person.lastName}");

            string body = await httpRequestMsg.Content.ReadAsStringAsync();

            log.LogInformation($"Body: {body}");

            await Task.Delay(50); // Simulate some async work

            return (ActionResult)new OkObjectResult($"Hello, {person.firstName}");
        }
    }
}
