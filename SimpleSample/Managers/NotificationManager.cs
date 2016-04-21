using System;
using System.Collections.Generic;
using System.Text;
using SimpleTables;

namespace SimpleSample.Managers
{
	internal class NotificationManager : ManagerBase<NotificationManager>
	{
		public event EventHandler SongDatabaseUpdated;
		public void ProcSongDatabaseUpdated()
		{
			SongDatabaseUpdated?.InvokeOnMainThread(this);
		}
	}
}