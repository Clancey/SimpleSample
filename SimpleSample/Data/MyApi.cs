using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAuth;
namespace SimpleSample
{
	public class MyApi : Api
	{
		public MyApi () : base("MyApi", new ModernHttpClient.NativeMessageHandler())
		{
			
		}

		public Task<List<Song>> GetSongs ()
		{
			//TODO: Idealy you would make this so it only does changed data since last sync
			const string url = "https://dl.dropboxusercontent.com/s/cv75h76pv9su7l4/songs-small.json";
			return Get<List<Song>> (url);
		}
	}
}

