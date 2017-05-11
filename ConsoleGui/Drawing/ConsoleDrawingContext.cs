using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
				DrawString (region.Left + 1, region.Top, titleText, region.Right - 1);
			}

		}

		public void FillRectangle (ConsoleGui.Drawing.Rect region)
		{
			for (int y = region.Top; y <= region.Bottom; y++) {
				Console.SetCursorPosition (region.Left, y);
				Console.Write (" ".PadRight (region.Right - region.Left));
			}
		}

		public void DrawString (int left, int top, string text, int right = -1, int offset = 0, int cursorLeft = -1, bool isOverwrite = false)
		{
			
			Console.SetCursorPosition (left, top);

			if (right == -1) {
				Console.Write (string.Concat(text.Skip (offset)));
			} else {
				Console.Write (string.Concat(text.Skip (offset).Take (right - left)));
			}
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
			var lines = new List<string> ();

			var textRegion = new Rect (region.Left, region.Top, region.Right, region.Bottom);

			// draw the border if available.
			// if there is a border, shrink the text region to make room.
			if (border) {
				textRegion.Left += 1;
				textRegion.Right -= 1;
				textRegion.Top += 1;
				textRegion.Bottom -= 1;

				DrawString (region.Left, region.Top, "┌");
				DrawString (region.Right, region.Top, "┐");
				DrawString (region.Left, region.Bottom, "└");
				DrawString (region.Right, region.Bottom, "┘");

				DrawString (region.Left + 1, region.Top, string.Concat(Enumerable.Repeat ('─', region.Right - region.Left - 1)));
				DrawString (region.Left + 1, region.Bottom, string.Concat(Enumerable.Repeat ('─', region.Right - region.Left - 1)));

				for (int y = region.Top + 1; y <= region.Bottom - 1; y++) {
					DrawString (region.Left, y, "│");
					DrawString (region.Right, y, "│");

				}

			}

			// Clear out whatever got left behind
			FillRectangle (textRegion);

			var splitParagraphs = text.Split ('\n');

			foreach (var p in splitParagraphs) {

				var splitText = p.Split (' ');

				var sb = new StringBuilder ();
				for (int i = 0; i < splitText.Length; i++) {
					if (sb.Length + splitText [i].Length <= textRegion.Right - textRegion.Left -1) {
						sb.Append (splitText [i]); 
						sb.Append (" ");
					} else {
						lines.Add (sb.ToString ());
						sb = new StringBuilder ();
						sb.Append (splitText [i]); 
						sb.Append (" ");
					}
				}
				if (sb.ToString ().Length > 0) {
					lines.Add (sb.ToString ());
				}
				sb.AppendLine ();
			}

			// scroll the text.
			var actualLines = lines.Skip (lineOffset).Take (textRegion.Bottom - textRegion.Top+1).ToList ();

			// draw the text line by line.
			for (int i = 0; i < actualLines.Count; i++) {
				DrawString (textRegion.Left, textRegion.Top + i, actualLines [i], textRegion.Right);
			}

			// if a scroll bar is needed, draw it. The scroll bar sits on the right part of the window.
			if (drawScrollbarIfNeeded && lines.Count > textRegion.Bottom - textRegion.Top) {
				if (!border) {
					DrawString (region.Right, region.Bottom, "┴");
					DrawString (region.Right, region.Top, "┬");

					for (int y = region.Top + 1; y <= region.Bottom - 1; y++) {
						DrawString (region.Right, y, "│");
					}
				}

				var cursorY = textRegion.Top + (int)( ((double)lineOffset / (double)lines.Count) * (double)(textRegion.Bottom-textRegion.Top));
			
				DrawString (region.Right, cursorY, "█");
			}

		}

	}
}

