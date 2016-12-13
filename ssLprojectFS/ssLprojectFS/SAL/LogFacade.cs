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

		public IEnumerable<MobileLogShortModel> GetLogsList()
		{
			return this.service
					   .GetLogsList()
					   .Result
					   .Select((item) => new MobileLogShortModel
					   {
						   Id = item.Id,
						   Date = item.Date
					   });
		}

		public IEnumerable<MobileLogShortModel> GetNextPartOfLogsList(int index, int count)
		{
			List<MobileLogModel> list = this.service
			                                .GetLogsList()
			                                .Result
			                                .ToList();
			
			return list.GetRange(index, index + count > list.Count ? list.Count - index : count)
					   .Select((item) => new MobileLogShortModel
					   {
						   Id = item.Id,
						   Date = item.Date
					   });
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
