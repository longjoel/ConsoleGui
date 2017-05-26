using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGui.Controls
{
	public class Textbox:Control
	{
		private List<string> _lines;
		public string Text { get { return string.Join ("\n", _lines); } set { _lines = value.Split ('\n'); Invalidate ();} }

		private int _cursorRow;
		public int CursorRow { get{return _cursorRow; } set{_cursorRow = value; Invalidate (); } }

		private int _cursorCol;
		public int CursorCol { get{return _cursorCol; } set{_cursorCol = value; Invalidate (); } }

		public Textbox ()
		{
			_lines = new List<string> ();
			_lines.Add ("");

			_cursorCol = 0;
			_cursorRow = 0;
		}

		public override void HandleInput (ConsoleKeyInfo keyInfo)
		{
			switch (keyInfo.Key) {

			// Handle the cursor movement keys.
			case ConsoleKey.UpArrow:
				if (_cursorRow > 0) {
					_cursorRow--;
				}
				break;
			case ConsoleKey.DownArrow:
				if (_cursorRow < _lines.Count()-1) {
					_cursorRow++;
				}
				break;
			case ConsoleKey.LeftArrow:
				if (_cursorCol > 0) {
					_cursorCol--;
				}
				break;

			case ConsoleKey.RightArrow:
				if (_cursorCol < _lines [_cursorRow].Length - 1) {
					_cursorCol++;
				}
				break;

				// Some additional fudging may be necessary.
			case ConsoleKey.Enter:
				var currentLine = _lines [_cursorRow];
				var newCurrentLine = string.Concat (_lines.Take (_cursorCol));
				var newNextLine = string.Concat (_lines.Skip (_cursorCol));
				_lines [_cursorRow] = newCurrentLine;
				_lines.Insert (_cursorRow + 1, newNextLine);
				_cursorRow++;
				break;

			case ConsoleKey.Backspace:
				break;

			case ConsoleKey.Delete:
				break;

			case ConsoleKey.Home:
				break;

			case ConsoleKey.End:
				break;

			case ConsoleKey.PageUp:
				break;

			case ConsoleKey.PageDown:
				break;

			case ConsoleKey.Tab:
				break;

				// It's not one of the control chars we care about, so insert it.
			default:


				if (Char.IsLetterOrDigit(keyInfo.KeyChar) 
					|| Char.IsPunctuation(keyInfo.KeyChar)) {
					_lines [_cursorRow].Insert (_cursorCol + 1, keyInfo.KeyChar.ToString ());
				}


				break;
			}


			// bound checking.
			if (_cursorCol > _lines [_cursorRow].Length)
				_cursorCol = _lines [_cursorRow].Length;
			

			base.HandleInput (keyInfo);
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			base.HandleRepaint (context);
		}
	}
}

