using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_NUnit_Framework.Drivers
{
    internal class RestSharpManager
    {
        static RestResponse response = new RestResponse();
        static RestRequest request = null;
        static RestClient client = null;

        public static string base_url = "";

        public static void InitializeEndpoint(string api_url)
        {
            base_url = api_url;
            client = new RestClient(base_url);
        }

        public static void SetQueryParam(string queryParam, string queryParamValue)
        {
            request.AddQueryParameter(queryParam, queryParamValue);
        }

        public static void MakeGETRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Get);
            response = client.Execute<RestResponse>(request);
        }
        public static void MakeDELETERequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Delete);
            response = client.Execute<RestResponse>(request);
        }

        public static void MakePOSTRequest(string endpoint, string body)
        {
            request = new RestRequest(endpoint, Method.Post);
            //request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            request.AddJsonBody(body);
            response = client.Execute<RestResponse>(request);
        }
        public static void MakePUTRequest(string endpoint, string body)
        {
            request = new RestRequest(endpoint, Method.Put);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            response = client.Execute<RestResponse>(request);
        }

        public static void VerifyResponseCode(int responseCode)
        {
            int actualResponseCode = (int)(HttpStatusCode)response.StatusCode;
            ClassicAssert.AreEqual(actualResponseCode, responseCode);
        }

        public static void ClearRequest()
        {
            request = null;
        }
    }
}