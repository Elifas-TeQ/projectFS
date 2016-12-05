using System.Collections.Generic;
using ssLprojectFS;

[assembly: Xamarin.Forms.Dependency(typeof(PersonFacade))]
namespace ssLprojectFS
{
	public class PersonFacade : IPersonFacade
	{
		public List<PersonName> GetPersonsList()
		{
			var list = new List<PersonName>();

			//zaglushka
			//begin
			for (int i = 0; i < 100; i++)
			{
				list.Add(new PersonName() { Id = i, Name = $"person#{i}" });
			}
			//end

			return list;
		}

		public Person GetPersonInfoById(int id)
		{
			Person person;

			//zaglushka
			//begin
			person = new Person() { Id = id, Name = $"person#{id}", Age = 18 + id, Biography = "some comment" };
			//end

			return person;
		}
	}
}
