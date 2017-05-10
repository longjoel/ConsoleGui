using System;

namespace ConsoleGui.Drawing
{
	public class Rect
	{
		public int Top { get; set; }

		public int Bottom { get; set; }

		public int Left { get; set; }

		public int Right { get; set; }

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

