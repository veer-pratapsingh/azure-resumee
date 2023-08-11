using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Company.Function
{
    public class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Function, "get","post", Route = null)] HttpRequest req,
    [CosmosDBTrigger(databaseName:"AzureResume", containerName:"Counter", Id = "1", PartitionKey = "1")] Counter counter,
    out Counter updatedCounter,
    ILogger log)
{
    log.LogInformation("C# HTTP Trigger function processed a request.");

    updatedCounter = counter;
    updatedCounter.Count +=1;

    var jsonToReturn = JsonConvert.SerializeObject(counter);

    return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
    {
        Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")

    };

           

        
        }
        
        
        
        
        
        }}
