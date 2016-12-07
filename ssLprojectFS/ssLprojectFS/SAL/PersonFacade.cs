using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ssLprojectFS;
using System.Collections;

[assembly: Xamarin.Forms.Dependency(typeof(PersonFacade))]
namespace ssLprojectFS
{
	public class PersonFacade : IPersonFacade
	{
		public List<MobileLogShortModel> GetPersonsList()
		{
			var responseList = this.GetPersonsListFromSmw();
			return responseList.Result
				               .Select((item) => new MobileLogShortModel()
			{
				Id = item.Id,
				Date = item.Date
			}).ToList();
		}

		public MobileLogModel GetPersonInfoById(int id)
		{
			var responseList = this.GetPersonsListFromSmw();
			return responseList.Result
				               .FirstOrDefault(item => item.Id == id);
		}

		private async Task<List<MobileLogModel>> GetPersonsListFromSmw()
		{
			var path = @"http://10.129.132.116:8082/api/log/";
			var uri = new Uri(path);

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
