using System;
using SimpleTables;
using SimpleSample.Data;
namespace SimpleSample
{
	public class BaseTableViewModel<T> : TableViewModel<T> where T : new()
	{
		public string Title { get; set; }
		public BaseTableViewModel ()
		{
			
		}

		public override string HeaderForSection (int section)
		{
			return Database.Main.SectionHeader<T> (section);
		}

		public override T ItemFor (int section, int row)
		{
			return Database.Main.ObjectForRow<T> (section, row);
		}

		public override int NumberOfSections ()
		{
			return Database.Main.NumberOfSections<T> ();
		}

		public override int RowsInSection (int section)
		{
			var rows = Database.Main.RowsInSection<T> (section);
			return rows;
		}
		public override string [] SectionIndexTitles ()
		{
			return Database.Main.QuickJump<T> ();
		}

		public virtual void SetupEvents ()
		{
			
		}
	}
}

