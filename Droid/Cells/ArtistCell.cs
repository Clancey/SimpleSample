using System;
using SimpleTables.Cells;
using SimpleTables;
namespace SimpleSample.Cells
{
	public class ArtistCell : StringCell, IBindingCell
	{
		public ArtistCell () : base ("")
		{
		}
		object bindingContext;

		public object BindingContext {
			get {
				return bindingContext;
			}

			set {
				bindingContext = value;
				var artist = value as Artist;
				if (artist == null)
					return;
				Caption = artist.Name;
			}
		}
	}
}

