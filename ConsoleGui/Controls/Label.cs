using System;

namespace ConsoleGui.Controls
{
	/// <summary>
	/// Simple Basic Label
	/// </summary>
	public class Label:Control
	{
		private string _text;
		private int _scrollPosition;
		public string Text{get{ return _text;} 
			set{_text = value; Invaldate (); }}

		public Label ()
		{
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			if (IsFocus) {
				context.DrawText (this.Region, _text, true, true, _scrollPosition,true);	
			} else {
				context.DrawText (this.Region, _text, false, true, _scrollPosition, false);
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

