using System;

namespace ConsoleGui.Drawing
{
	public class ConsoleDrawingContext:Interfaces.Drawing.IDrawingContext
	{
		public ConsoleDrawingContext ()
		{
		}


		public void SetForegroundColor (ConsoleColor c)
		{
		}


		public void SetBackgroundColor (ConsoleColor c)
		{
		}

		public void DrawBorder (ConsoleGui.Drawing.Rect region, string titleText = null, string statusText = null)
		{
		}

		public void FillRectangle (ConsoleGui.Drawing.Rect region)
		{
		}

		public void DrawString (int top, int left, string text, int right = -1, int offset = 0, int cursorLeft = -1, bool isOverwrite = false)
		{
			
		}

		public void DrawText (ConsoleGui.Drawing.Rect region, 
		                      string text, 
		                      bool border = true,
		                      bool wordWrap = true,
		                      int lineOffset = 0,
		                      bool drawScrollbarIfNeeded = true,
		                      int cursorLeft = -1,
		                      int cursorTop = -1,
		                      bool isOverwrite = false)
		{
		}

	}
}

