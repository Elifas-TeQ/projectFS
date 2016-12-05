using System.Collections.Generic;

namespace ssLprojectFS
{
	public interface IPersonFacade
	{
		List<PersonName> GetPersonsList();
		Person GetPersonInfoById(int id);
	}
}