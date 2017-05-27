using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleGui.Drawing
{
	public class ConsoleDrawingContext:Interfaces.Drawing.IDrawingContext
	{
		public const string BeginFormattedTextInverted = "\x1b[7m";
		public const string BeginFormattedTextBlink = "\x1b[5m";
		public const string EndFormattedText = "\x1b[0m";

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

		public void DrawThickBorder (ConsoleGui.Drawing.Rect region, string titleText = null, string statusText = null)
		{
			DrawString (region.Left, region.Top, "╔");
			DrawString (region.Right, region.Top, "╗");
			DrawString (region.Left, region.Bottom, "╚");
			DrawString (region.Right, region.Bottom, "╝");

			DrawString (region.Left + 1, region.Top, string.Concat (Enumerable.Repeat ('═', region.Right - region.Left - 1)));
			DrawString (region.Left + 1, region.Bottom, string.Concat (Enumerable.Repeat ('═', region.Right - region.Left - 1)));

			for (int y = region.Top + 1; y <= region.Bottom - 1; y++) {
				DrawString (region.Left, y, "║");
				DrawString (region.Right, y, "║");

			}


			if (titleText != null) {
				DrawString (region.Left + 1, region.Top, titleText, region.Right - 1);
			}

			if (statusText != null) {
				DrawString (region.Left + 1, region.Bottom, titleText, region.Right - 1);
			}

		}

		public void DrawThinBorder (ConsoleGui.Drawing.Rect region, string titleText = null, string statusText = null)
		{
			DrawString (region.Left, region.Top, "┌");
			DrawString (region.Right, region.Top, "┐");
			DrawString (region.Left, region.Bottom, "└");
			DrawString (region.Right, region.Bottom, "┘");

			DrawString (region.Left + 1, region.Top, string.Concat (Enumerable.Repeat ('─', region.Right - region.Left - 1)));
			DrawString (region.Left + 1, region.Bottom, string.Concat (Enumerable.Repeat ('─', region.Right - region.Left - 1)));

			for (int y = region.Top + 1; y <= region.Bottom - 1; y++) {
				DrawString (region.Left, y, "│");
				DrawString (region.Right, y, "│");

			}

			if (statusText != null) {
				DrawString (region.Left + 1, region.Bottom, titleText, region.Right - 1);
			}

		}

		public void FillRectangle (ConsoleGui.Drawing.Rect region)
		{
			for (int y = region.Top; y <= region.Bottom; y++) {
				Console.SetCursorPosition (region.Left, y);
				Console.Write (" ".PadRight (region.Right - region.Left));
			}
		}

		public string Blink (string text)
		{
			return  BeginFormattedTextBlink + text + EndFormattedText;

		}

		public string Invert (string text)
		{
			return  BeginFormattedTextInverted + text + EndFormattedText;
		}

		public string StripDrawingChars (string text)
		{
			return text
				.Replace (BeginFormattedTextInverted, "")
				.Replace (EndFormattedText, "");
		}

		/// <summary>
		/// Draws the string alligned.
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="region">Region.</param>
		/// <param name="allignment">Allignment.</param>
		public void DrawStringAlligned (
			string text, 
			ConsoleGui.Drawing.Rect region, 
			ConsoleGui.Drawing.TextAllignment allignment)
		{
			

			var strippedTextLength = StripDrawingChars (text).Length;

			var clippedText = string.Concat (text.Take ((region.Right - region.Left) + (text.Length - strippedTextLength)));

			var center = region.Left + (region.Right - region.Left) / 2;
			center = center - strippedTextLength / 2;

			var middle = region.Top + (region.Bottom - region.Top) / 2;

			switch (allignment) {

			case TextAllignment.UpperLeft:
				DrawString (region.Left, region.Top, clippedText);
				break;
			
			case TextAllignment.LowerLeft:
				DrawString (region.Left, region.Bottom, clippedText);
				break;
			
			case TextAllignment.Left:
				DrawString (region.Left, middle, clippedText);
				break;
			
			case TextAllignment.Top:
				DrawString (center, region.Top, clippedText);
				break;


			case TextAllignment.Center:
				DrawString (center, middle, clippedText);
				break;

			case TextAllignment.Bottom:
				DrawString (center, region.Bottom, clippedText);
				break;

			case TextAllignment.UpperRight:
				DrawString (region.Right - clippedText.Length, region.Top, clippedText);
				break;

			case TextAllignment.Right:
				DrawString (region.Right - clippedText.Length, middle, clippedText);
				break;

			case TextAllignment.LowerRight:
				DrawString (region.Right - clippedText.Length, region.Bottom, clippedText);
				break;

			}
		}


		public void DrawString (
			int left, 
			int top, 
			string text, 
			int right = -1, 
			int offset = 0, 
			int cursorLeft = -1, 
			bool isOverwrite = false)
		{
			Console.SetCursorPosition (left, top);

			if (right == -1) {
				Console.Write (string.Concat (text.Skip (offset)));
			} else {
				Console.Write (string.Concat (text.Skip (offset).Take (right - left)));
			}
		}

		public void DrawText (
			ConsoleGui.Drawing.Rect region, 
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

				DrawThinBorder (region);
			}

			// Clear out whatever got left behind
			FillRectangle (textRegion);

			var splitParagraphs = text.Split ('\n');

			foreach (var p in splitParagraphs) {

				var splitText = p.Split (' ');

				var sb = new StringBuilder ();
				for (int i = 0; i < splitText.Length; i++) {
					if (sb.Length + StripDrawingChars( splitText [i]).Length <= textRegion.Right - textRegion.Left - 1) {
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
			var actualLines = lines.Skip (lineOffset).Take (textRegion.Bottom - textRegion.Top + 1).ToList ();

			var cursorRowOffset = cursorTop - lineOffset;

			// draw the text line by line.
			for (int i = 0; i < actualLines.Count; i++) {
				if (i == cursorRowOffset) {

					var tmpCursorCol = cursorLeft;
					if (tmpCursorCol < 0)
						tmpCursorCol = 0;



					var preCursor = string.Concat (actualLines [i].Take (tmpCursorCol ));
					var blinkCursor = Invert (actualLines [i] [tmpCursorCol].ToString ());
					var postCursor = string.Concat (actualLines [i].Skip (tmpCursorCol + 1));

					DrawString (
						textRegion.Left, 
						textRegion.Top + i, 
						preCursor + blinkCursor + postCursor, 
						textRegion.Right);
				} else {
					DrawString (textRegion.Left, 
						textRegion.Top + i, 
						actualLines [i], 
						textRegion.Right);
				}
			}

			// if a scroll bar is needed, draw it. The scroll bar sits on the right part of the window.
			if (drawScrollbarIfNeeded && lines.Count > textRegion.Bottom - textRegion.Top) {
				if (!border) {
					for (int y = region.Top; y <= region.Bottom; y++) {
						DrawString (region.Right, y, "│");
					}
				}

				var cursorY = textRegion.Top + (int)(((double)lineOffset / (double)lines.Count) * (double)(textRegion.Bottom - textRegion.Top));
			
				DrawString (region.Right, cursorY, "█");
			}

		}

		/// <summary>
		/// Calculates the text lines. Figure out how many lines a string will take up when conformed to a single text window.
		/// </summary>
		/// <returns>The text lines.</returns>
		/// <param name="region">Region.</param>
		/// <param name="text">Text.</param>
		/// <param name="border">If set to <c>true</c> border.</param>
		/// <param name="wordwrap">If set to <c>true</c> wordwrap.</param>
		public static List<string> CalculateTextLines (ConsoleGui.Drawing.Rect region,
		                                               string text, 
		                                               bool border = true, 
		                                               bool wordwrap = true)
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

			}

			var splitParagraphs = text.Split ('\n');

			foreach (var p in splitParagraphs) {

				var splitText = p.Split (' ');

				var sb = new StringBuilder ();
				for (int i = 0; i < splitText.Length; i++) {
					if (sb.Length + splitText [i].Length <= textRegion.Right - textRegion.Left - 1) {
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

			return lines;

		}

	}
}

