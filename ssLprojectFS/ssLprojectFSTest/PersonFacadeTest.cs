using System;
using System.Collections.Generic;
using ssLprojectFS;
using NUnit.Framework;
using Moq;

namespace ssLprojectFSTest
{
	[TestFixture]
	public class PersonFacadeTest
	{
		[Test]
		public void GetPersonsListReturnsListOfPersonNames()
		{
			var expected = new List<PersonName>();
			for (int i = 0; i < 100; i++)
			{
				expected.Add(new PersonName() { Id = i, Name = $"person#{i}" });
			}

			var personFacade = new PersonFacade();

			//Act
			List<PersonName> actual = personFacade.GetPersonsList();

			//Assert
			CollectionAssert.AreEqual(expected, actual); // false - objects are not similar...
		}
	}
}
