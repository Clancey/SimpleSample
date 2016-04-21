
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SimpleSample.Data
{
	public static class Settings
	{
		static ISettings AppSettings { get; } = CrossSettings.Current;

		public static bool IsFirstRun {
			get { return GetBool (true); }
			set { SetBool( value); }
		}


		#region Convenience Methods
		static string GetString (string defaultValue = "", [CallerMemberName] string memberName = "")
		{
			return AppSettings.GetValueOrDefault (memberName, defaultValue);
		}

		static void SetString (string value, [CallerMemberName] string memberName = "")
		{
			AppSettings.AddOrUpdateValue<string> (memberName, value);
		}
		static int GetInt (int defaultValue = 0, [CallerMemberName] string memberName = "")
		{
			return AppSettings.GetValueOrDefault (memberName, defaultValue);
		}

		static void SetInt (int value, [CallerMemberName] string memberName = "")
		{
			AppSettings.AddOrUpdateValue<int> (memberName, value);
		}

		static long GetLong (long defaultValue = 0, [CallerMemberName] string memberName = "")
		{
			return AppSettings.GetValueOrDefault (memberName, defaultValue);
		}

		static void SetLong (long value, [CallerMemberName] string memberName = "")
		{
			AppSettings.AddOrUpdateValue<long> (memberName, value);
		}

		static bool GetBool (bool defaultValue = false, [CallerMemberName] string memberName = "")
		{
			return AppSettings.GetValueOrDefault (memberName, defaultValue);
		}

		static void SetBool (bool value, [CallerMemberName] string memberName = "")
		{
			AppSettings.AddOrUpdateValue<bool> (memberName, value);
		}


		static T Get<T> (T defaultValue, [CallerMemberName] string memberName = "")
		{
			return AppSettings.GetValueOrDefault (memberName, defaultValue);
		}

		static void Set<T> (T value, [CallerMemberName] string memberName = "")
		{
			AppSettings.AddOrUpdateValue<T> (memberName, value);
		}

		#endregion


	}
}