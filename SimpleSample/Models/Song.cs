using System;
using SimpleDatabase;
using SQLite;
namespace SimpleSample
{
	public class Song
	{
		public string Artist { get; set; }

		public DateTime Timestamp { get; set; }

		[PrimaryKey]
		public string TrackId { get; set; }

		public string Title { get; set; }

		[OrderBy]
		public string TitleNorm { get; set; }

		[GroupBy]
		public string IndexCharacter { get; set; }
	}
}

