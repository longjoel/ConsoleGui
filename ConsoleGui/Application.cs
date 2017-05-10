using System;
using System.Collections.Generic;

namespace ConsoleGui
{
	public class Application
	{
		private static bool _isExiting;
		public static void Exit (){_isExiting = true;}

		public Interfaces.Drawing.IDrawingContext _drawingContext;

		public Application (Form mainForm)
		{
			_isExiting = false;
			_drawingContext = new Drawing.ConsoleDrawingContext ();
			Internals.WindowManager.Instance.Push (mainForm);
		}

		public void Run(){

			while (!_isExiting) {
			
			
			
			}
		}
	}
}

