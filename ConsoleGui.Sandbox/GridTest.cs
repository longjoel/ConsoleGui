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
			var le = new Drawing.TableLayoutEngine (this.Region.Interior,3,3);

			for (int j = 0; j < 3; j++) {
				for (int i = 0; i < 3; i++) {
					int k = j * 3 + i;
					context.DrawThinBorder (le.GetRegion (i, j));
					context.DrawStringAlligned ("Text", le.GetRegion (i, j).Interior, (Drawing.TextAllignment)k);
				}
			}

			base.HandleRepaint (context);
		}
	}
}

