using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ssLprojectFS
{
	public class Service : IService
	{
		public string Path { get; private set; }

		public Service()
		{
			this.Path = @"http://10.129.132.116:8082/api/log/";
		}

		public async Task<List<MobileLogModel>> GetLogsList()
		{
			var uri = new Uri(this.Path);

			List<MobileLogModel> list = new List<MobileLogModel>();

			var client = new HttpClient();
			var response = await client.GetAsync(uri).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				list = JsonConvert.DeserializeObject<List<MobileLogModel>>(content);
			}
			return list;
		}
	}
}
