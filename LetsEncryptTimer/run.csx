#r "Newtonsoft.Json"

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;

public static async Task Run(TimerInfo myTimer, ILogger log)
{
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    var userName = "AZURE_FUNCTION_DEPLOYMENT_USERNAME";
    var userPWD = "AZURE_FUNCTION_DEPLOYMENT_PASSWORD";
    var client = new HttpClient();
    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{userPWD}")));
 
    var body = new {
        AzureEnvironment = new {
            //AzureWebSitesDefaultDomainName = "string", //Defaults to azurewebsites.net
            //ServicePlanResourceGroupName = "string", //Defaults to ResourceGroupName
            //SiteSlotName = "string", //Not required if site slots isn't used
            WebAppName = "APPSERVICE_APPNAME",
            //AuthenticationEndpoint = "string", //Defaults to https://login.windows.net/
            ClientId = "AD_APPLICATION_ID",
            ClientSecret = "AD_APPLICATION_SECRET",
            //ManagementEndpoint = "string", //Defaults to https://management.azure.com
            ResourceGroupName = "RESOURCE_GROUP", //Resource group of the web app 
            SubscriptionId = "SUBSCRIPTION_ID",
            Tenant = "AD_DIRECTORY_ID", //Azure AD tenant ID 
            //TokenAudience = "string" //Defaults to https://management.core.windows.net/
            },
        AcmeConfig = new {
            RegistrationEmail = "YOUR_EMAIL",
            Host = "BASE_URL",
            AlternateNames =  new string[
            ]{"OTHER_URLS"},
            RSAKeyLength = 2048,
            PFXPassword = "RANDOM_PASSWORD", //Replace with your own 
            UseProduction = true //Replace with true if you want production certificate from Lets Encrypt 
        },
        CertificateSettings = new {
            UseIPBasedSSL = false
        },
        AuthorizationChallengeProviderConfig = new {
            DisableWebConfigUpdate = false
        }
    };
 
    var res = await client.PostAsync("https://FUNCTION_APP_NAME.scm.azurewebsites.net/letsencrypt/api/certificates/challengeprovider/http/kudu/certificateinstall/azurewebapp?api-version=2017-09-01",
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
 
    log.LogInformation(await res.Content.ReadAsStringAsync());
} 