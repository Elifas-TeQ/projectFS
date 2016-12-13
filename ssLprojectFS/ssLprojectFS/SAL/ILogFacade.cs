using System.Collections.Generic;

namespace ssLprojectFS
{
	public interface ILogFacade
	{
		IEnumerable<MobileLogShortModel> GetLogsList();
		IEnumerable<MobileLogShortModel> GetNextPartOfLogsList(int index, int count);
		MobileLogModel GetLogDetailsById(int id);
	}
}