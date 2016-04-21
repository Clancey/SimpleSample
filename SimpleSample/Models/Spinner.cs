using System;
namespace SimpleSample
{
	public class Spinner : IDisposable
	{
		public Spinner (string title)
		{
			App.ShowSpinner (title);
		}

		public void Dispose ()
		{
			App.DismissSpinner ();
		}
	}
}

