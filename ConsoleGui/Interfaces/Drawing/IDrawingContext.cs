using System;

namespace ConsoleGui.Interfaces.Drawing
{
	public interface IDrawingContext
	{
		/// <summary>
		/// Sets the color of the foreground.
		/// </summary>
		/// <param name="c">Color of foreground.</param>
		void SetForegroundColor (ConsoleColor c);

		/// <summary>
		/// Sets the color of the background.
		/// </summary>
		/// <param name="c">Color of the background.</param>
		void SetBackgroundColor (ConsoleColor c);

	
		/// <summary>
		/// Draws a double lined border around a given region with the options for title text and status text at the bottom.
		/// </summary>
		/// <param name="region">Region.</param>
		/// <param name="titleText">Title text.</param>
		/// <param name="statusText">Status text.</param>
		void DrawBorder (ConsoleGui.Drawing.Rect region, string titleText = null, string statusText = null);

		void FillRectangle (ConsoleGui.Drawing.Rect region);

		/// <summary>
		/// Draw a string starting from the top left moving right, optionally with a right param that indicates
		/// how far a string can go before getting clipped, and an offset which can be used for scolling text.
		/// It can also draw a blinking cursor (insert or overwrite) if a cursor index is passed in.
		/// </summary>
		/// <param name="top">Top.</param>
		/// <param name="left">Left.</param>
		/// <param name="text">Text.</param>
		/// <param name="right">Right.</param>
		/// <param name="offset">Offset.</param>
		/// <param name="cursorLeft">Cursor left.</param>
		/// <param name="isOverwrite">If set to <c>true</c> is overwrite.</param>
		void DrawString(int left, int top, string text, int right = -1, int offset = 0, int cursorLeft = -1, bool isOverwrite = false);

		/// <summary>
		/// Draws the text.
		/// </summary>
		/// <param name="region">Region.</param>
		/// <param name="text">Text.</param>
		/// <param name="border">If set to <c>true</c> border.</param>
		/// <param name="wordWrap">If set to <c>true</c> word wrap.</param>
		/// <param name="lineOffset">Line offset.</param>
		/// <param name="drawScrollbarIfNeeded">If set to <c>true</c> draw scrollbar if needed.</param>
		/// <param name="cursorLeft">Cursor left.</param>
		/// <param name="cursorTop">Cursor top.</param>
		/// <param name="isOverwrite">If set to <c>true</c> is overwrite.</param>
		void DrawText (ConsoleGui.Drawing.Rect region, 
			string text, 
			bool border = true,
			bool wordWrap = true,
			int lineOffset = 0,
			bool drawScrollbarIfNeeded = true,
			int cursorLeft = -1,
			int cursorTop = -1,
			bool isOverwrite = false
			);
	}
}

