using System.Collections.Generic;

namespace ssLprojectFS
{
	public interface ILogFacade
	{
		List<MobileLogShortModel> GetLogsList();
		MobileLogModel GetLogDetailsById(int id);
	}
}