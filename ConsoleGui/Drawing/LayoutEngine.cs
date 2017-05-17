using System;
using System.Collections.Generic;

namespace ConsoleGui.Drawing
{


	public class LayoutRow
	{
		public int Columns { get; set; }
	}

	public class LayoutEngine
	{
		private Rect _region;

		public List<LayoutRow> Rows { get; set; }

		public LayoutEngine (Rect region)
		{
			_region = region;

		}

		public Rect GetRegion (int row, int col)
		{
			int left = (int)(_region.Left + ((double)(_region.Right - _region.Left) *
			           (double)col / (double)Rows [row].Columns));

			if (col != 0)
				left++;

			int right = (int)(_region.Left + ((double)(_region.Right - _region.Left) *
			            (double)(col + 1) / (double)Rows [row].Columns));

			int top = (int)(_region.Top + ((double)(_region.Bottom - _region.Top)) *
			          ((double)row / (double)Rows.Count));

			if (top != 0)
				top++;

			int bottom = (int)(_region.Top + ((double)(_region.Bottom - _region.Top)) *
			             ((double)(row + 1) / (double)Rows.Count));

			return new Rect (left, top, right, bottom);
		}

	}
}

