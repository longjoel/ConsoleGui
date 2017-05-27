using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGui.Controls
{
	public class Textbox:Control
	{
		private List<string> _lines;

		public string Text { 
			get { return string.Join ("\n", _lines); } 
			set {
				_lines = value.Split ('\n').ToList ();
				Invalidate ();
			} 
		}

		private int _cursorRow;

		public int CursorRow { 
			get{ return _cursorRow; } 
			set {
				_cursorRow = value;
				Invalidate ();
			} 
		}

		private int _cursorCol;

		public int CursorCol {
			get{ return _cursorCol; }
			set {
				_cursorCol = value;
				Invalidate ();
			}
		}

		public Textbox ()
		{
			_lines = new List<string> ();
			_lines.Add ("");

			_cursorCol = 0;
			_cursorRow = 0;

			CanHaveFocus = true;

		}


		public override void HandleInput (ConsoleKeyInfo keyInfo)
		{

			var pageHeight = Region.Interior.Bottom - Region.Interior.Top;

			switch (keyInfo.Key) {

			// Handle the cursor movement keys.
			case ConsoleKey.UpArrow:
				if (_cursorRow > 0) {
					_cursorRow--;
				}
				break;
			case ConsoleKey.DownArrow:
				if (_cursorRow < _lines.Count () - 1) {
					_cursorRow++;
				}
				break;
			case ConsoleKey.LeftArrow:
				if (_cursorCol > 0) {
					_cursorCol--;
				}
				break;

			case ConsoleKey.RightArrow:
				if (_cursorCol < _lines [_cursorRow].Length ) {
					_cursorCol++;
				}
				break;

			// Some additional fudging may be necessary.
			case ConsoleKey.Enter:
				var currentLine = _lines [_cursorRow];
				var newCurrentLine = string.Concat (_lines[_cursorRow].Take (_cursorCol));
				var newNextLine = string.Concat (_lines[_cursorRow].Skip (_cursorCol));
				_lines [_cursorRow] = newCurrentLine;
				_lines.Insert (_cursorRow + 1, newNextLine);
				_cursorRow++;
				break;

			case ConsoleKey.Backspace:
				if (_cursorCol > 0) {
					_lines [CursorRow] = _lines [CursorRow].Remove (_cursorCol - 1,1);
					_cursorCol--;
				}
				break;

			case ConsoleKey.Delete:
				if (_cursorCol < _lines [CursorRow].Length - 1) {
					_lines [CursorRow]=_lines [CursorRow].Remove (_cursorCol,1);
				}

				break;

			case ConsoleKey.Home:
				_cursorRow = 0;
				break;

			case ConsoleKey.End:
				_cursorRow = _lines.Count - 1;
				break;

			case ConsoleKey.PageUp:
				_cursorRow -= pageHeight;

				if (_cursorRow < 0)
					_cursorRow = 0;

				break;

			case ConsoleKey.PageDown:
				_cursorRow += pageHeight;

				if (_cursorRow > _lines.Count - 1) {
					_cursorRow = _lines.Count - 1;
				}
				break;

				// catch tab so it doesn't get added as part of the text.
			case ConsoleKey.Tab:
				break;

			// It's not one of the control chars we care about, so insert it.
			default:

				if (Char.IsLetterOrDigit (keyInfo.KeyChar)
				    || Char.IsPunctuation (keyInfo.KeyChar)
					|| Char.IsWhiteSpace (keyInfo.KeyChar)) {
					if (_cursorCol < _lines [_cursorRow].Length) {
						_lines [_cursorRow]= _lines [_cursorRow].Insert (_cursorCol , keyInfo.KeyChar.ToString ());
					} else {
						_lines [_cursorRow] += keyInfo.KeyChar.ToString ();

					}

					_cursorCol++;
				}

				break;
			}



			// bound checking.
			if (_cursorCol > _lines [_cursorRow].Length) {
				_cursorCol = _lines [_cursorRow].Length;
			}

			// Something happened, redraw.
			Invalidate ();

			base.HandleInput (keyInfo);
		}

		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			context.FillRectangle (Region);
			context.DrawThinBorder (Region);
			var halfHeight = ((Region.Interior.Bottom - Region.Interior.Top) / 2);
			//var width = (Region.Interior.Right - Region.Interior.Left);

			int screenLineIndex = 0;
			for (int i = -halfHeight; i < halfHeight; i++) {
				var rowIndex = _cursorRow + i;

				if (rowIndex >= 0 && rowIndex < _lines.Count) {

					if (rowIndex == _cursorRow) {
						context.DrawString (Region.Interior.Left, Region.Interior.Top +screenLineIndex, _lines [rowIndex], Region.Interior.Right, 0, _cursorCol);

					} else {
						context.DrawString (Region.Interior.Left, Region.Interior.Top +screenLineIndex, _lines [rowIndex], Region.Interior.Right);
					}


					screenLineIndex += 1;
				}

			}

			base.HandleRepaint (context);
		}
	}
}

