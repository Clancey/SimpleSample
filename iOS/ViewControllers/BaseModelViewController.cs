using System;
using UIKit;
using SimpleTables;
using System.Threading.Tasks;
using Foundation;

namespace SimpleSample.iOS
{
	public class BaseModelViewController<TVM, T> : UITableViewController where TVM : BaseTableViewModel<T> where T : class, new()
	{
		TVM _model;

		public TVM Model {
			get { return _model; }
			set {
				_model = value;
				Title = value?.Title ?? "";
			}
		}
		bool disablePullToRefresh;

		public bool DisablePullToRefresh {
			get {
				return disablePullToRefresh;
			}

			set {
				disablePullToRefresh = value;
				if (disablePullToRefresh) {
					TearDownRefresh ();
					RefreshControl = null;
				}
			}
		}

		public override void LoadView ()
		{
			base.LoadView ();
			if (Model == null)
				throw new Exception ("Model is required.");
			TableView.Source = Model;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Title = Model?.Title ?? "";
			SetupEvents ();
			TableView.ReloadData ();
		}
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			TeardownEvents ();
		}

		public virtual void SetupEvents ()
		{
			Model?.SetupEvents ();
			SetupRefresh ();
		}
		public virtual void TeardownEvents ()
		{
			Model.ClearEvents ();
			TearDownRefresh ();
		}

		void SetupRefresh ()
		{
			if (DisablePullToRefresh)
				return;
			if (RefreshControl == null)
				RefreshControl = new UIRefreshControl ();
			RefreshControl.ValueChanged += RefreshControl_ValueChanged; ;
		}

		async void RefreshControl_ValueChanged (object sender, EventArgs e)
		{
			if (await Refresh ())
				RefreshControl.AttributedTitle = new NSAttributedString (String.Format ("Last Updated" + ":{0:g}", DateTime.Now));
			RefreshControl.EndRefreshing ();
			TableView.ReloadData ();
		}

		void TearDownRefresh ()
		{
			if (RefreshControl != null)
				RefreshControl.ValueChanged -= RefreshControl_ValueChanged;
		}
		public virtual Task<bool> Refresh ()
		{
			return Task.FromResult (true);
		}
	}
}

