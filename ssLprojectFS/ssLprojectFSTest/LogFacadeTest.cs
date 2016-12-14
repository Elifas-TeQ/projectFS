using Moq;
using GenFu;
using System.Linq;
using ssLprojectFS;
using NUnit.Framework;
using System.Collections.Generic;

namespace ssLprojectFSTest
{
	[TestFixture]
	public class LogFacadeTest
	{
		[Test]
		public void GetLogsListReturnsListOfMobileLogsShortModel()
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
		}

		[Test]
		[TestCase(0, 20)]
		public void GetNextPartOfLogsListTakesZeroAsIndexAndTwentyAsCountReturnsPartOfFirstTwentyElementsFromListOfLogsShortModel(int index, int count)
		{
			//Arrange
			List<MobileLogModel> list = A.ListOf<MobileLogModel>(27);
			List<MobileLogShortModel> expected = list.Select((item) => new MobileLogShortModel
			{
				Id = item.Id,
				Date = item.Date
			})
			                                         .ToList()
													 .GetRange(index, count);

			var mockService = new Mock<IService>();
			mockService.Setup(x => x.GetLogsList())
					   .ReturnsAsync(list)
					   .Verifiable();

			var logFacade = new LogFacade(mockService.Object);

			//Act
			var actual = logFacade.GetNextPartOfLogsList(index, count);

			//Assert
			mockService.VerifyAll();
			Assert.AreEqual(expected.Count, actual.ToList().Count);
		}

		[Test]
		[TestCase(20, 20)]
		public void GetNextPartOfLogsListTakesTwentyAsIndexAndTwentyAsCountReturnsTheLastPartOfSevenElementsFromListOfLogsShortModel(int index, int count)
		{
			//Arrange
			List<MobileLogModel> list = A.ListOf<MobileLogModel>(27);
			List<MobileLogShortModel> expected = list.Select((item) => new MobileLogShortModel
			{
				Id = item.Id,
				Date = item.Date
			})
													 .ToList()
			                                         .GetRange(index, list.Count - index);

			var mockService = new Mock<IService>();
			mockService.Setup(x => x.GetLogsList())
					   .ReturnsAsync(list)
					   .Verifiable();

			var logFacade = new LogFacade(mockService.Object);

			//Act
			var actual = logFacade.GetNextPartOfLogsList(index, count);

			//Assert
			mockService.VerifyAll();
			Assert.AreEqual(expected.Count, actual.ToList().Count);
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
			           .ReturnsAsync(list)
					   .Verifiable();

			var logFacade = new LogFacade(mockService.Object);

			//Act
			var actual = logFacade.GetLogDetailsById(id);

			//Assert
			mockService.VerifyAll();
			Assert.AreEqual(expected.Id, actual.Id);
		}
	}
}
