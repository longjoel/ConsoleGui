using System;
using ConsoleGui.Drawing;

namespace ConsoleGui.Controls
{
	/// <summary>
	/// Simple Basic Label
	/// </summary>
	public class ReadOnlyTextbox:Control
	{
		private string _text;
		private int _scrollPosition;

		public string Text {
			get{ return _text; } 
			set {
				_text = value;
				Invalidate ();

				this.CanHaveFocus = ConsoleDrawingContext.CalculateTextLines(this.Region.Interior, _text).Count > (this.Region.Interior.Bottom - this.Region.Interior.Top);
			}
		}

		private bool _scrollbarVisible;

		public bool ScrollbarVisible {
			get{ return _scrollbarVisible; }
			set {
				_scrollbarVisible = true;
				Invalidate ();
			}
		}

		public ReadOnlyTextbox ()
		{
			CanHaveFocus = true;
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			var subRegion = Region.Interior;

			if (HasFocus) {
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
						Invalidate ();
					}
					break;
				case ConsoleKey.DownArrow:
					if (_scrollPosition < totalLines.Count - 1) {
						_scrollPosition++;
						Invalidate ();
					}
					break;
				}
			}


			base.HandleInput (keyInfo);
		}


	}
}

