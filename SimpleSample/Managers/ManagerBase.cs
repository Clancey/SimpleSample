using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSample.Managers
{
	public class ManagerBase<T>  where T : new()
	{
		public static T Shared { get; set; } = new T();
	}
}