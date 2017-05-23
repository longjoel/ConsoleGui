using System;

namespace ConsoleGui.Sandbox
{
	public class GridTest:Form
	{
		public GridTest ()
		{
		}



		public override void HandleRepaint (ConsoleGui.Interfaces.Drawing.IDrawingContext context)
		{
			var le = new Drawing.TableLayoutEngine (this.Region.Interior);

			le.LayoutRows = 3;
			le.LayoutCols = 3;

			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					int k = i * 3 + j;
					context.DrawThinBorder (le.GetRegion (i, j));
					context.DrawStringAlligned ("Text", le.GetRegion (i, j).Interior, (Drawing.TextAllignment)k);
				}
			}

			base.HandleRepaint (context);
		}
	}
}

