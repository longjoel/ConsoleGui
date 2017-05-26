using System;

namespace ConsoleGui.Controls
{
	public class Label:Control
	{

		private string _text;
		private Drawing.TextAllignment _textAllignment;

		public string Text { 
			get { 
				return _text;
			} 
			set {
				_text = value;
				Invalidate ();
			}
		}

		public Drawing.TextAllignment TextAllignment {
			get{ 
				return _textAllignment;
			}
			set{
				_textAllignment = value;
				Invalidate ();
			}

		}

		public Label ()
		{
			CanHaveFocus = false;
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			context.DrawStringAlligned (Text, Region, TextAllignment);
			base.HandleRepaint (context);
		}
	}
}

