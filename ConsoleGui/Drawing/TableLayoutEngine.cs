using System;
using System.Collections.Generic;

namespace ConsoleGui.Drawing
{
	/// <summary>
	/// Table layout engine.
	/// </summary>
	public class TableLayoutEngine
	{
		/// <summary>
		/// Gets the region.
		/// </summary>
		/// <value>The region.</value>
		public Rect Region{ get; private set; }

		/// <summary>
		/// Gets the layout rows.
		/// </summary>
		/// <value>The layout rows.</value>
		public int LayoutRows { get; private set; }

		/// <summary>
		/// Gets the layout cols.
		/// </summary>
		/// <value>The layout cols.</value>
		public int LayoutCols { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Drawing.TableLayoutEngine"/> class.
		/// </summary>
		/// <param name="region">Region.</param>
		/// <param name="numCols">Number cols.</param>
		/// <param name="numRows">Number rows.</param>
		public TableLayoutEngine (Rect region, int numCols, int numRows)
		{
			Region = region;
			LayoutRows = numRows;
			LayoutCols = numCols;
		}

		/// <summary>
		/// Gets the region.
		/// </summary>
		/// <returns>The region.</returns>
		/// <param name="col">Col.</param>
		/// <param name="row">Row.</param>
		/// <param name="colSpan">Col span.</param>
		/// <param name="rowSpan">Row span.</param>
		public Rect GetRegion (int col, int row, int colSpan = 1, int rowSpan = 1)
		{
			int left = Region.Left + (int)(((double)col / (double)LayoutCols)
			           * (double)(Region.Right - Region.Left));
				
			if (col != 0)
				left++;

			int right = Region.Left + (int)(((double)(col + colSpan) / (double)LayoutCols)
			            * (double)(Region.Right - Region.Left));
			
			int top = Region.Top + (int)(((double)row / (double)LayoutRows)
			          * (double)(Region.Bottom - Region.Top));
			
			if (row != 0)
				top++;

			int bottom = Region.Top + (int)(((double)(row + rowSpan) / (double)LayoutRows)
			             * (double)(Region.Bottom - Region.Top));
			
			return new Rect (left, top, right, bottom);
		}

	}
}

