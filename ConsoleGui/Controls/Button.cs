using System;

namespace ConsoleGui.Controls
{
	public class Button:Control
	{
		public Action OnClick{ get; set; }

		private string _text;

		public string Text {
			get{ return _text; }
			set {
				_text = value;
				Invaldate ();
			}
		}

		public Button ()
		{
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
			if (IsFocus) {
				context.DrawString (Region.Left, Region.Top, "<" + _text + ">", Region.Right);		
			} else {
				context.DrawString (Region.Left, Region.Top, "[" + _text + "]", Region.Right);		
			}

			base.HandleRepaint (context);
		}
	}
}

