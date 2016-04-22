using System;
using SimpleDatabase;
using SimpleSample.Data;

namespace SimpleSample
{
	public class BaseTableGroupViewModel<T> : BaseTableViewModel<T> where T : new()
	{
		GroupInfo groupInfo;
		public GroupInfo GroupInfo {
			get {
				return groupInfo ?? (groupInfo = Database.Main.GetGroupInfo<T> ().Clone ());
			}

			set {
				groupInfo = value;
			}
		}

		public override string HeaderForSection (int section)
		{
			return Database.Main.SectionHeader<T> (GroupInfo, section);
		}

		public override T ItemFor (int section, int row)
		{
			return Database.Main.ObjectForRow<T> (GroupInfo, section, row);
		}

		public override int NumberOfSections ()
		{
			return Database.Main.NumberOfSections<T> (GroupInfo);
		}

		public override int RowsInSection (int section)
		{
			var rows = Database.Main.RowsInSection<T> (GroupInfo, section);
			return rows;
		}
		public override string [] SectionIndexTitles ()
		{
			return Database.Main.QuickJump<T> (GroupInfo);
		}


	}
}

