using System;

namespace ssLprojectFS
{
	public class MobileLogModel
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Message { get; set; }
		public int LogType { get; set; }
		public string Tag { get; set; }
		public string Version { get; set; }
		public string ApplicationName { get; set; }
	}
}
