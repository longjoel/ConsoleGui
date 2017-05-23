using System;

namespace ConsoleGui.Drawing
{
	public class Rect
	{
		public int Top { get; set; }

		public int Bottom { get; set; }

		public int Left { get; set; }

		public int Right { get; set; }

		/// <summary>
		/// The interior region of the form.
		/// </summary>
		/// <value>The interior.</value>
		public Drawing.Rect Interior { 
			get { 
				return new Drawing.Rect (
					Left + 1, 
					Top + 1, 
					Right - 1, 
					Bottom - 1); 
			} 
		}

		public Rect (int left, int top, int right, int bottom)
		{
			Top = top;
			Bottom = bottom;
			Left = left;
			Right = right;
		}

		public Rect () : this (0, 0, 0, 0)
		{
		}
	}
}

