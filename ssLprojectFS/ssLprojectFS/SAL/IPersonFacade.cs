using System.Collections.Generic;
using System.Threading.Tasks;

namespace ssLprojectFS
{
	public interface IPersonFacade
	{
		List<MobileLogShortModel> GetPersonsList();
		MobileLogModel GetPersonInfoById(int id);
	}
}