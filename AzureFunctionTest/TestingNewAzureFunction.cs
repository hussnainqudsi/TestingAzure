using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionTest
{
    public class TestingNewAzureFunction
    {
        [FunctionName("TestingNewAzureFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ExecutionContext context,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            Student st;
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
           
            
                st = new Student()
                {
                    Class = "16",
                    Name = "Hussnain Qudsi",
                    RollNumber = "F16-BSCS-078"
                };
            
            dynamic data = JsonConvert.DeserializeObject(requestBody);
          

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(st);
        }
    }
}
