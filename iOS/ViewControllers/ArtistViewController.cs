using System;
namespace SimpleSample.iOS
{
	public class ArtistViewController : BaseModelViewController<ArtistViewModel,Artist>
	{
		public ArtistViewController ()
		{
			Model = new ArtistViewModel ();
		}
		public override void LoadView ()
		{
			base.LoadView ();
			TableView.SectionIndexMinimumDisplayRowCount = 10;
		}
		public override void SetupEvents ()
		{
			base.SetupEvents ();
			Model.ItemSelected += (sender, e) => {
				this.NavigationController.PushViewController (new ArtistSongsViewController { Artist = e.Data },true);
			};
		}
	}
}

