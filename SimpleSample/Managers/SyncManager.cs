using System;
using System.Linq;
using System.Threading.Tasks;
using SimpleSample.Data;

namespace SimpleSample.Managers
{
	public class SyncManager : ManagerBase<SyncManager>
	{
		public SyncManager ()
		{
			
		}
		MyApi api = new MyApi ();

		Task syncTask;
		public Task Sync ()
		{
			if (syncTask?.IsCompleted ?? true)
				syncTask = Task.Run (sync);
			return syncTask;
		}

		async Task sync ()
		{
			//Only show the spinner if its the first run
			Spinner spinner = Settings.IsFirstRun ? new Spinner ("Loading") : null;
			try {
				
				var songs = await api.GetSongs ().ConfigureAwait (false);
				songs.ForEach (song => {
					song.TitleNorm = song.Title?.Trim ().ToLower () ?? "Unknown Title";
					song.IndexCharacter = song.TitleNorm.FirstOrDefault ().ToString ().ToUpper ();
				});
				var artists = songs.Select (x => x.Artist).Distinct ().Select (x => {
					var artist = new Artist {
						Name = x,
						NameNorm = x?.Trim ().ToLower () ?? "Unknown Artist",
					};
					artist.IndexCharacter = artist.NameNorm.FirstOrDefault ().ToString ().ToUpper ();
					return artist;
				});
				Database.Main.InsertOrReplaceAll (artists);
				Database.Main.InsertOrReplaceAll (songs);
				Database.Main.ClearMemory ();
				Settings.IsFirstRun = false;
				NotificationManager.Shared.ProcSongDatabaseUpdated ();

			} catch (Exception ex) {
				//TODO: Log this exceptions
				Console.WriteLine (ex);
			} finally {
				//Kill the spinenr if it exists
				spinner?.Dispose ();
			}
		}
	}
}

