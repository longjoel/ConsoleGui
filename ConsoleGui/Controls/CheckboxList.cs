using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ConsoleGui.Controls
{
	public class CheckboxList:Control
	{
		private  List<CheckBoxItem> _checkboxItems;

		private string _text;


		public string Text {
			get{ return _text; }
			set {
				_text = value;
				Invalidate ();
			}
		}

		private int _cursorPosition;


		public CheckboxList ()
		{
			_checkboxItems = new List<CheckBoxItem> ();
			_cursorPosition = -1;

		}

		public void Add (CheckBoxItem item)
		{
			item.Parent = this;
			_checkboxItems.Add (item);
			Invalidate ();
		}

		public void Remove (CheckBoxItem item)
		{
			_checkboxItems.Remove (item);
			Invalidate ();
		}

		public CheckBoxItem this [int index] {
			get {
				return _checkboxItems [index];
			}
		}

		public int Count { get { return _checkboxItems.Count; } }

		public override void HandleInput (ConsoleKeyInfo keyInfo)
		{
			
			base.HandleInput (keyInfo);
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			if (HasFocus) {
				context.DrawThinBorder (Region, Text);
			} 

			var sbMenuUptions = new StringBuilder ();

			for (int i = 0; i < _checkboxItems.Count; i++) {
				var option = _checkboxItems [i];
				var c = " ";

				if (i == _cursorPosition) {
					c = "█";
				} else if (option.IsChecked) {
					c = "✓"; // Is this terminal friendly?
				}
				sbMenuUptions.AppendLine ($"[{c}] {option.Text}");		

			}

		
			context.DrawText(new ConsoleGui.Drawing.Rect(Region.Left+1, Region.Top+1, Region.Right+1, Region.Bottom+1), sbMenuUptions.ToString(), false, false, _cursorPosition);

			base.HandleRepaint (context);
		}
	}
}

