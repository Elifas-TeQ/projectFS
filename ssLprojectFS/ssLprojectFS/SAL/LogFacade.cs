using System.Linq;
using System.Collections.Generic;

namespace ssLprojectFS
{
	public class LogFacade : ILogFacade
	{
		private readonly IService service;

		public LogFacade(IService service)
		{
			this.service = service;
		}

		public List<MobileLogShortModel> GetLogsList()
		{
			return this.service
				       .GetLogsList()
				       .Result
				       .Select((item) => new MobileLogShortModel()
			{
				Id = item.Id,
				Date = item.Date
			}).ToList();
		}

		public MobileLogModel GetLogDetailsById(int id)
		{
			return this.service
				       .GetLogsList()
				       .Result
				       .FirstOrDefault(item => item.Id == id);
		}
	}
}
