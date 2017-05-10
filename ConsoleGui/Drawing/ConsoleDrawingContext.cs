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
			Console.ForegroundColor = c;
		}


		public void SetBackgroundColor (ConsoleColor c)
		{
			Console.BackgroundColor = c;
		}

		public void DrawBorder (ConsoleGui.Drawing.Rect region, string titleText = null, string statusText = null)
		{
			for (int y = region.Top; y <= region.Bottom; y++) {
				for (int x = region.Left; x <= region.Right; x++) {
					if (x == region.Left && y == region.Top) {
						DrawString (x, y, "╔");
					} else if (x == region.Right && y == region.Top) {
						DrawString (x, y, "╗");
					} else if (x == region.Left && y == region.Bottom) {
						DrawString (x, y, "╚");
					} else if (x == region.Right && y == region.Bottom) {
						DrawString (x, y, "╝");
					} else if (y == region.Top || y == region.Bottom) {
						DrawString (x, y, "═");
					} else if (x == region.Left || x == region.Right) {
						DrawString (x, y, "║");
					}
				}
			}

			if (titleText != null) {
			}

		}

		public void FillRectangle (ConsoleGui.Drawing.Rect region)
		{
		}

		public void DrawString (int left, int top, string text, int right = -1, int offset = 0, int cursorLeft = -1, bool isOverwrite = false)
		{
			Console.SetCursorPosition (left, top);
			Console.Write (text);
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

