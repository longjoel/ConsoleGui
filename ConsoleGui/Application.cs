using System;
using System.Collections.Generic;
using System.Linq;

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
			
				if (Console.KeyAvailable) {
					var kInfo = Console.ReadKey (true);

					// universal exit key. Can exit any form.
					if (kInfo.Key == ConsoleKey.Escape) {
						Internals.WindowManager.Instance.Pop ();
					}

					if (Internals.WindowManager.Instance.Forms.Any ()) {
						Internals.WindowManager.Instance.Forms.Last ().HandleInput (kInfo);
					} else {
						break;
					}
				}
			
			}
		}
	}
}

