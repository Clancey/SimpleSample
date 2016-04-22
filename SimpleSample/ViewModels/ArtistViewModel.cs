using System;
using SimpleSample.Managers;
namespace SimpleSample
{
	public class ArtistViewModel: BaseTableViewModel<Artist>
	{
		public ArtistViewModel ()
		{
			Title = "Artists";
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

