using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGui.Internals
{
	internal class WindowManager
	{
		private static readonly Lazy<WindowManager> lazy =
			new Lazy<WindowManager> (() => new WindowManager ());

		public static WindowManager Instance { get { return lazy.Value; } }

		public List<Form> Forms { get; private set; }

		private WindowManager(){
			Forms = new List<Form> ();
		}

		public void Push(Form form){
			Forms.Add (form);
			form.Initialize ();
			form.Invalidate ();
		}

		public void Close(Form form){
			Forms.Remove (form);
			Forms.ForEach (f => f.Invalidate ());
		}

		public void Pop(){
			if (Forms.Any ()) {
				Forms.RemoveAt (Forms.Count - 1);
			}

			if (Forms.Any ()) {
				Forms.Last ().Invalidate ();
			}
		}
	}
}

