using System;
using System.Collections.Generic;

namespace ConsoleGui.Drawing
{


	public class LayoutRow
	{
		public int Columns { get; set; }
	}

	public class TableLayoutEngine
	{
		private Rect _region;

		public int LayoutRows { get; set; }

		public int LayoutCols { get; set; }

		public TableLayoutEngine (Rect region)
		{
			_region = region;

		}

		public Rect GetRegion (int row, int col, int rowSpan = 1, int colSpan = 1)
		{
			int left = _region.Left + (int)(((double)col / (double)LayoutCols)
			           * (double)(_region.Right - _region.Left));
				
			if (col != 0)
				left++;

			int right = _region.Left + (int)(((double)(col + colSpan) / (double)LayoutCols)
			            * (double)(_region.Right - _region.Left));
			
			int top = _region.Top + (int)(((double)row / (double)LayoutRows)
			          * (double)(_region.Bottom - _region.Top));
			
			if (top != 0)
				top++;

			int bottom = _region.Top + (int)(((double)(row + rowSpan) / (double)LayoutRows)
			             * (double)(_region.Bottom - _region.Top));
			
			return new Rect (left, top, right, bottom);
		}

	}
}

