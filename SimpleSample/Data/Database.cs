using System;
using System.IO;
using SimpleDatabase;

namespace SimpleSample.Data
{
	public class Database : SimpleDatabaseConnection
	{
		public static Database Main { get; set; } = new Database ();
		static string dbPath => Path.Combine (Locations.LibDir, "db.db");

		public Database () : base (dbPath)
		{
			CreateTables (
				typeof (Song)
			);
		}
	}
}

