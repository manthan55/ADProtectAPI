using CoreClient.Helpers;
using CoreClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Net;

namespace CoreClient
{
    public class Program
    {
        static readonly IConfiguration configuration;

        static Program()
        {
            HttpClient.DefaultProxy = new WebProxy(new Uri("http://localhost:8866"));
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                configuration = builder.Build();

            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("appsettings.json file not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot load appsetrings.json", ex);
            }
        }

        static void Main()
        {
            AzureAd azureAdConfig = LoadAzureAdConfig();
            IConfidentialClientApplication app = CreateConfidentialClientApp(azureAdConfig);

            List<string> scopes = new List<string>();
            //scopes.Add("https://graph.microsoft.com/.default");
            scopes.Add("api://817d25de-1375-49f3-9960-1a4993475236/.default");

            MsalAuthenticationProvider msalAuthenticationProvider = new MsalAuthenticationProvider(app, scopes.ToArray());

            string token = msalAuthenticationProvider.GetTokenAsync().Result;
            Console.WriteLine(token);
        }

        /*
        private static IConfiguration LoadAppConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

                IConfiguration config = builder.Build();

                return config;

            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("appsettings.json file not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot load appsetrings.json", ex);
            }
        }
        */

        private static AzureAd LoadAzureAdConfig()
        {
            return configuration.GetSection("AzureAd").Get<AzureAd>();
        }

        private static IConfidentialClientApplication CreateConfidentialClientApp(AzureAd azureAdConfig)
        {
            string authority = $"https://login.microsoftonline.com/{azureAdConfig.TenantId}/v2.0";
            return ConfidentialClientApplicationBuilder.Create(azureAdConfig.ClientId)
                                                .WithAuthority(authority)
                                                .WithClientSecret(azureAdConfig.ClientSecret)
                                                .Build();
        }
    }
}


