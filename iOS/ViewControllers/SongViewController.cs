using System;
using System.Threading.Tasks;
using SimpleSample.Managers;

namespace SimpleSample.iOS
{
	public class SongViewController : BaseModelViewController<SongViewModel,Song>
	{
		public SongViewController ()
		{
			Model = new SongViewModel ();
		}
		public override async Task<bool> Refresh ()
		{
			try {
				await SyncManager.Shared.Sync ();
				return true;
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}
			return false;
		}
	}
}

