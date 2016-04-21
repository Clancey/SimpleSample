using System;
using SimpleTables;
using SimpleSample.Managers;
namespace SimpleSample
{
	public class SongViewModel : BaseTableViewModel<Song>
	{
		public SongViewModel ()
		{
			Title = "Songs";
		}
		public override void SetupEvents ()
		{
			base.SetupEvents ();
			NotificationManager.Shared.SongDatabaseUpdated += Shared_SongDatabaseUpdated;
		}

		public override void ClearEvents ()
		{
			base.ClearEvents ();
			NotificationManager.Shared.SongDatabaseUpdated -= Shared_SongDatabaseUpdated;
		}

		void Shared_SongDatabaseUpdated (object sender, EventArgs e)
		{
			ReloadData ();
		}
	}
}

