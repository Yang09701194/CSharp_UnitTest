using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitTestPractice
{
	public class GithubFetcher : IFetcher
	{


		public string GetData()
		{


			//可以直接不進行https憑證檢查的部分  避免https連線錯誤 
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			//設定 TLS協定 20200428
			ServicePointManager.SecurityProtocol =
				SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
				SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			//https://api.github.com/
			string baseUri = @"https://api.github.com/";
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(baseUri);
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.3");
			HttpResponseMessage response = client.GetAsync(baseUri).Result;
			string result = response.Content.ReadAsStringAsync().Result;

			JObject jObj = JObject.Parse(result);
			string current_user_url = (string)jObj["current_user_url"];

			return current_user_url;
		}



	}
}
