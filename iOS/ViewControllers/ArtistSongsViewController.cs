using System;
namespace SimpleSample.iOS
{
	public class ArtistSongsViewController : BaseModelViewController<ArtistSongViewModel, Song>
	{
		public ArtistSongsViewController ()
		{
			Model = new ArtistSongViewModel ();
		}
		public Artist Artist {
			get { return Model.Artist; }
			set { Model.Artist = value; }
		}
	}
}

