namespace PlayFab.CloudScript
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;

    public static class ExecuteFunction
    {
        /// <summary>
        /// A local implementation of the ExecuteFunction feature. Provides the ability to execute an Azure Function with a local URL with respect to the host
        /// of the application this function is running in.
        /// </summary>
        /// <param name="httpRequest">The HTTP request</param>
        /// <param name="log">A logger object</param>
        /// <returns>The function execution result(s)</returns>
        [FunctionName("ExecuteFunction")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger log)
        {
            await Task.Delay(100);

            return new HttpResponseMessage
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
