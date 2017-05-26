using System;

namespace ConsoleGui.Samples
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var app = new Application (new MainForm ());
			app.Run ();
		}
	}
}
