using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleSample.Cells;
using SimpleTables;

namespace SimpleSample
{
	public static class App
	{

		static Thread MainThread;
		public static void Initialize ()
		{
			MainThread = Thread.CurrentThread;
			RegisterCells ();
		}

		static void RegisterCells ()
		{
			CellRegistrar.Register<Song, SongCell> ();
		}


		public static Action<string, string> AlertFunction;

		public static void ShowAlert (string title, string message)
		{
			RunOnMainThread (() => AlertFunction (title, message));
		}

		public static Action<Action> Invoker;

		public static void RunOnMainThread (Action action)
		{
			if (Thread.CurrentThread == MainThread)
				action ();
			else
				Invoker (action);
		}

		public static Action<string> OnShowSpinner;

		public static void ShowSpinner (string title)
		{
			OnShowSpinner?.InvokeOnMainThread (title);
		}

		public static Action OnDismissSpinner;

		public static void DismissSpinner ()
		{
			OnDismissSpinner?.InvokeOnMainThread ();
		}
	}
}

