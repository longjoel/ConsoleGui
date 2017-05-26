using System;

namespace ConsoleGui.Controls
{
	public class CheckBoxItem
	{
		private bool _isChecked;
		private string _text;

		public CheckboxList Parent { get; set; }

		public bool IsChecked {
			get{ return _isChecked; }
			set {
				_isChecked = value;
				Parent?.Invalidate ();
			}
		}

		public string Text {
			get{ return _text; }
			set {
				_text = value;
				Parent?.Invalidate ();
			}
		}
	}
}

