using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Microsoft.Extensions.Configuration.Json;
using RestSharp_NUnit_Framework.Configuration;
using RestSharp_NUnit_Framework.Drivers;
using RestSharp_NUnit_Framework.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
