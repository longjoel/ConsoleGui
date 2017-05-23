using System;

namespace ConsoleGui.Drawing
{
	public class Button:Control
	{
		public Action OnClick{ get; set; }

		private string _text;

		public string Text {
			get{ return _text; }
			set {
				_text = value;
				Invalidate ();
			}
		}

		private TextAllignment _textAllignment;

		public TextAllignment TextAllignment { 
			get { 
				return _textAllignment;
			} 
			set {
				_textAllignment = value;
				Invalidate ();
			}
		}

		public Button ()
		{
			CanHaveFocus = true;
			TextAllignment = TextAllignment.Center;
		}

		public override void HandleInput (ConsoleKeyInfo keyInfo)
		{
			switch (keyInfo.Key) {
			case ConsoleKey.Spacebar:
			case ConsoleKey.Enter:
				OnClick?.Invoke ();
				break;
			}

			base.HandleInput (keyInfo);
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			context.DrawThinBorder (this.Region);
			if (HasFocus) {
				context.DrawStringAlligned(context.Invert("<" + _text + ">"), this.Region.Interior, this.TextAllignment);		
			} else {
				context.DrawStringAlligned("<" + _text + ">", this.Region.Interior, this.TextAllignment);		

						
			}

			base.HandleRepaint (context);
		}
	}
}

