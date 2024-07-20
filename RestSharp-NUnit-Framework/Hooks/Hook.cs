using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp_NUnit_Framework.Configuration;
using RestSharp_NUnit_Framework.Drivers;
using RestSharp_NUnit_Framework.Support;


namespace RestSharp_NUnit_Framework.Hooks
{
    [SetUpFixture]
    internal class Hook
    {
        [OneTimeSetUp]
        public void SetUp() {

            string parentDirectory = PathFinder.GetPath();
            ConfigManager config = new ConfigManager();
            ConfigurationBuilder configbuilder = new ConfigurationBuilder();
            configbuilder.AddJsonFile(parentDirectory + "\\RestSharp-NUnit-Framework\\config.json");
            IConfigurationRoot configuration = configbuilder.Build();
            configuration.Bind(config);
            RestSharpManager.InitializeEndpoint(config.ApiBaseURL);
        }
    }
}
