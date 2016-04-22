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
		public object BindingContext { get; set; }
		public override UIKit.UITableViewCell GetCell (UIKit.UITableView tv)
		{
			var cell = base.GetCell (tv);
			cell.TextLabel.Text = (BindingContext as Artist)?.Name ?? "Unknown Artist";
			return cell;
		}
	}
}

