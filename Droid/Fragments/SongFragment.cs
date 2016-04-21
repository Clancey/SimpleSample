using System;
namespace SimpleSample.Droid
{
	public class SongFragment : BaseModelFragment<SongViewModel,Song>
	{
		public SongFragment ()
		{
			Model = new SongViewModel ();
		}
	}
}

