using System;
using SimpleSample.Managers;

namespace SimpleSample
{
	public class ArtistSongViewModel: BaseTableGroupViewModel<Song>
	{
		public ArtistSongViewModel ()
		{
			
		}
		Artist artist;
		public Artist Artist {
			get {
				return artist;
			}

			set {
				artist = value;
				GroupInfo.Filter = "Artist = ?";
				GroupInfo.Params = value.Name;
				GroupInfo.From = "Song";
				Title = value.Name;
			}
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

