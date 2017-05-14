using System;
using ConsoleGui.Drawing;

namespace ConsoleGui.Controls
{
	/// <summary>
	/// Simple Basic Label
	/// </summary>
	public class Label:Control
	{
		private string _text;
		private int _scrollPosition;

		public string Text {
			get{ return _text; } 
			set {
				_text = value;
				Invaldate ();
			}
		}

		private bool _scrollbarVisible;

		public bool ScrollbarVisible {
			get{ return _scrollbarVisible; }
			set {
				_scrollbarVisible = true;
				Invaldate ();
			}
		}

		public Label ()
		{
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			var subRegion = new Rect (Region.Left + 1, Region.Top + 1, Region.Right - 1, Region.Bottom - 2);

			if (IsFocus) {

				context.DrawThinBorder (Region);
				context.DrawText (subRegion, _text, false, true, _scrollPosition, _scrollbarVisible);	
			} else {
				context.DrawText (subRegion, _text, false, true, _scrollPosition, _scrollbarVisible);
			}
				
			base.HandleRepaint (context);
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		/// <param name="keyInfo">Key info.</param>
		public override void HandleInput (ConsoleKeyInfo keyInfo)
		{
			var totalLines = Drawing.ConsoleDrawingContext.CalculateTextLines (Region, _text, true, true);

			if (totalLines.Count > (Region.Bottom - Region.Top)) {
				switch (keyInfo.Key) {
				case ConsoleKey.UpArrow:
					if (_scrollPosition > 0) {
						_scrollPosition--;
						Invaldate ();
					}
					break;
				case ConsoleKey.DownArrow:
					if (_scrollPosition < totalLines.Count - 1) {
						_scrollPosition++;
						Invaldate ();
					}
					break;
				}
			}


			base.HandleInput (keyInfo);
		}


	}
}

