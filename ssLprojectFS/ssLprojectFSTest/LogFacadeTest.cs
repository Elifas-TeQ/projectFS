using Moq;
using GenFu;
using System.Linq;
using ssLprojectFS;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ssLprojectFSTest
{
	[TestFixture]
	public class LogFacadeTest
	{
		[Test]
		public void GetLogsListReturnsListOfLogsShort()
		{
			//Arrange
			List<MobileLogModel> list = A.ListOf<MobileLogModel>(100);
			List<MobileLogShortModel> expected = list.Select((item) => new MobileLogShortModel()
			{
				Id = item.Id,
				Date = item.Date
			}).ToList();

			var mockService = new Mock<IService>();
			mockService.Setup(x => x.GetLogsList())
			           .ReturnsAsync(list)
					   .Verifiable();

			var logFacade = new LogFacade(mockService.Object);

			//Act
			var actual = logFacade.GetLogsList();

			//Assert
			mockService.VerifyAll();
			Assert.AreEqual(expected.ToList()[0].Id, actual.ToList()[0].Id);
			Assert.AreEqual(expected.ToList()[0].Date, actual.ToList()[0].Date);
		}

		[Test]
		[TestCase(13)]
		public void GetLogDetailsByIdTakesThirteenReturnsMobileLogModelWithTakenId(int id)
		{
			//Arrange
			var expected = new MobileLogModel()
			{
				Id = id,
				ApplicationName = "application name",
				Version = "1.0.0.24"
			};
			List<MobileLogModel> list = A.ListOf<MobileLogModel>(100);
			list.Add(expected);
			list.Reverse();

			var mockService = new Mock<IService>();
			mockService.Setup(x => x.GetLogsList())
			           .Returns(Task.FromResult(list))
					   .Verifiable();

			var logFacade = new LogFacade(mockService.Object);

			//Act
			var actual = logFacade.GetLogDetailsById(id);

			//Assert
			mockService.VerifyAll();
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.ApplicationName, actual.ApplicationName);
			Assert.AreEqual(expected.Version, actual.Version);
		}
	}
}
