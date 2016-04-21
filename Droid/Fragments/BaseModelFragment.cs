using System;
using Android.App;
using Android.Content;

namespace SimpleSample.Droid
{
	public class BaseModelFragment<TVM, T> : ListFragment where TVM : BaseTableViewModel<T> where T : class, new()
	{
		TVM _model;

		public TVM Model {
			get { return _model; }
			set {
				_model = value;
			}
		}

		public override void OnCreate (Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			RetainInstance = true;
		}

		public override void OnViewCreated (Android.Views.View view, Android.OS.Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);
			this.ListView.FastScrollEnabled = true;

			if (ListAdapter == null) {
				Model.ListView = ListView;
				ListAdapter = Model;
			}
			this.SetListShown (true);
		}
		public override void OnAttach (Context context)
		{
			base.OnAttach (context);
			Attached ();
		}

		public override void OnAttach (Activity activity)
		{
			base.OnAttach (activity);
			Attached ();
		}

		void Attached ()
		{
			Model.Context = Activity;
			Model.SetupEvents ();
		}

		public override void OnDetach ()
		{
			base.OnDetach ();
			Model.ClearEvents ();
		}

	}
}

