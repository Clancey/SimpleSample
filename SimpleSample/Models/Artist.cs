using System;
using SimpleDatabase;
using SQLite;

namespace SimpleSample
{
	public class Artist
	{
		[PrimaryKey]
		public string Name { get; set; }

		[OrderBy]
		public string NameNorm { get; set; }

		[GroupBy]
		public string IndexCharacter { get; set; }
	}
}

