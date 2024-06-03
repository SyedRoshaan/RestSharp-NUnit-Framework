using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp_NUnit_Framework.Configuration;
using RestSharp_NUnit_Framework.Drivers;
using RestSharp_NUnit_Framework.model;
using RestSharp_NUnit_Framework.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_NUnit_Framework.Tests
{
    [TestFixture]
    internal class APIAutomation
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            string parentDirectory = PathFinder.GetPath();
            ConfigManager config = new ConfigManager();
            ConfigurationBuilder configbuilder = new ConfigurationBuilder();
            configbuilder.AddJsonFile(parentDirectory + "\\RestSharp-NUnit-Framework\\config.json");
            IConfigurationRoot configuration = configbuilder.Build();
            configuration.Bind(config);
            RestSharpManager.InitializeEndpoint(config.ApiBaseURL);
        }

        [Test]
        public void CreateUser()
        {
            string users = @"{
            ""name"": ""John"",
            ""job"": ""Software Engineer""
        }";
            RestSharpManager.MakePOSTRequest("/api/users", users);
            RestSharpManager.VerifyResponseCode(201);

        }

        [Test]
        public void UpdateUser()
        {
            string users = @"{
            ""name"": ""Peter"",
            ""job"": ""Engineer""
        }";
            RestSharpManager.MakePUTRequest("/api/users/2", users);
            RestSharpManager.VerifyResponseCode(200);
        }

        [Test]
        public void GetSingleUser() {
            RestSharpManager.MakeGETRequest("/api/users/2");
            RestSharpManager.VerifyResponseCode(200);
        }

        [Test]
        public void DeleteUser()
        {
            RestSharpManager.MakeDELETERequest("/api/users/2");
            RestSharpManager.VerifyResponseCode(204);
        }
    }
}
