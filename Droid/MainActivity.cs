using Android.App;
using Android.Widget;
using Android.OS;
using SimpleSample.Managers;

namespace SimpleSample.Droid
{
	[Activity (Label = "SimpleSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		int baseFragment;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetupApp ();

			SetContentView (Resource.Layout.Main);
			//Retain fragments so don't set home if state is stored.
			if (FragmentManager.BackStackEntryCount == 0) {
				SwitchScreens (new SongFragment(), false, true);
			}
			SyncManager.Shared.Sync ();
		}

		AlertDialog spinnerDialog;
		void SetupApp ()
		{
			App.Initialize ();
			App.AlertFunction = (title, message) => {
				Toast.MakeText (this, $"{title} - {message}", ToastLength.Long).Show ();
			};
			App.Invoker = this.RunOnUiThread;
			App.OnShowSpinner = (text) => {
				if (spinnerDialog != null)
					spinnerDialog.Dismiss ();
				spinnerDialog = new ProgressDialog.Builder (this).SetMessage (text).SetCancelable (false).Show ();
			};
			App.OnDismissSpinner = () => {
				spinnerDialog?.Dismiss ();
				spinnerDialog = null;
			};
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutInt ("baseFragment", baseFragment);
		}

		protected override void OnRestoreInstanceState (Bundle savedInstanceState)
		{
			base.OnRestoreInstanceState (savedInstanceState);
			baseFragment = savedInstanceState.GetInt ("baseFragment");
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();
			SetupActionBar (FragmentManager.BackStackEntryCount != 0);
		}

		public int SwitchScreens (Fragment fragment, bool animated = true, bool isRoot = false)
		{
			var transaction = FragmentManager.BeginTransaction ();

			if (animated) {
				int animIn, animOut;
				GetAnimationsForFragment (fragment, out animIn, out animOut);
				transaction.SetCustomAnimations (animIn, animOut);
			}
			transaction.Replace (Resource.Id.contentArea, fragment);
			if (!isRoot)
				transaction.AddToBackStack (null);

			SetupActionBar (!isRoot);

			return transaction.Commit ();
		}
		public void SetupActionBar (bool showUp = false)
		{
			this.ActionBar.SetDisplayHomeAsUpEnabled (showUp);
			//this.ActionBar.SetDisplayShowHomeEnabled (showUp);
		}
		void GetAnimationsForFragment (Fragment fragment, out int animIn, out int animOut)
		{
			animIn = Resource.Animation.enter;
			animOut = Resource.Animation.exit;

		}

	}
}


