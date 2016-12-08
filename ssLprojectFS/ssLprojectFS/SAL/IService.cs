using System.Threading.Tasks;
using System.Collections.Generic;

namespace ssLprojectFS
{
	public interface IService
	{
		Task<List<MobileLogModel>> GetLogsList();
	}
}
