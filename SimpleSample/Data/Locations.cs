﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleSample.Data
{
	internal static class Locations
	{
		static Locations()
		{
			Directory.CreateDirectory(Locations.TmpDownloadDir);
			Directory.CreateDirectory(Locations.LibDir);
		}



#if __OSX__
		[System.Runtime.InteropServices.DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
		public static extern IntPtr NSHomeDirectory();

		public static string ContainerDirectory {
			get {
				var val = ((Foundation.NSString)ObjCRuntime.Runtime.GetNSObject(NSHomeDirectory())).ToString ();

				if(val.Contains("Container"))
					return val;
				return Path.Combine (val, "Library/Application Support/gMusic");
			}
		}
		public static string BaseDir = ContainerDirectory;
#else
		public static string BaseDir = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).ToString();
#endif
		

		public static readonly string LibDir = Path.Combine(BaseDir, "Library/");
		public static readonly string TmpDownloadDir = Path.Combine(BaseDir, "tmp/");
		public static readonly string DocumentsDir = Path.Combine(BaseDir, "Documents/");
	}
}