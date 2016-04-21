using System;
using Android.Content;
using Android.Views;
using SimpleTables;
using Android.Widget;
namespace SimpleSample.Cells
{
	public class SongCell : IBindingCell
	{
		WeakReference binding;
		public object BindingContext {
			get { return binding?.Target; }

			set { binding = new WeakReference (value); }
		}

		public View GetCell (View convertView, ViewGroup parent, Context context, LayoutInflater inflator)
		{
			SongCellViewHolder holder = null;
			var view = convertView;

			if (view != null)
				holder = view.Tag as SongCellViewHolder;


			if (holder == null) {
				holder = new SongCellViewHolder ();
				view = inflator.Inflate (Android.Resource.Layout.SimpleListItem2, null);
				holder.Name = view.FindViewById<TextView> (Android.Resource.Id.Text1);
				holder.Description = view.FindViewById<TextView> (Android.Resource.Id.Text2);
				//holder.Image = view.FindViewById<ImageView>(Resource.Id.imageView);
				view.Tag = holder;
			}

			var song = BindingContext as Song;

			holder.Name.Text = song?.Title;
			holder.Description.Text = song?.Artist;

			return view;

		}

		class SongCellViewHolder : Java.Lang.Object
		{
			public TextView Name { get; set; }
			public TextView Description { get; set; }
			public ImageView Image { get; set; }
		}
	}
}

