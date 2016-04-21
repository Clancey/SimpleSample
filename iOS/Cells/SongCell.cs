using System;
using SimpleTables;
using UIKit;

namespace SimpleSample.Cells
{
	public class SongCell : IBindingCell
	{
		public SongCell ()
		{
		}

		WeakReference binding;
		public object BindingContext {
			get { return binding?.Target; }

			set { binding = new WeakReference (value); }
		}

		public UITableViewCell GetCell (UITableView tv)
		{
			const string songCell = "SongCell";
			var cell = tv.DequeueReusableCell (songCell) ?? new UITableViewCell (UITableViewCellStyle.Subtitle, songCell);

			var song = BindingContext as Song;
			cell.TextLabel.Text = song?.Title ?? "Error";
			cell.DetailTextLabel.Text = song?.Artist ?? "Error";
			return cell;

		}
	}
}

