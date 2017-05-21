using System;

namespace ConsoleGui.Sandbox
{
	public class MainForm:Form
	{
		Controls.Label HelloLabel { get; set; }
		Controls.CheckboxList CheckboxList {get;set;}
		public MainForm ()
		{
			this.Region = new ConsoleGui.Drawing.Rect (
				0, 0,
				Console.BufferWidth - 1, Console.BufferHeight - 1);

			var le = new Drawing.TableLayoutEngine (this.Region.Interior);
			le.LayoutCols = 1;
			le.LayoutRows = 5;

			this.HelloLabel = new ConsoleGui.Controls.Label () {
				Text = "Hello!",
				Region = le.GetRegion(0,0,1,1)
			};

			this.CheckboxList = new ConsoleGui.Controls.CheckboxList (){
				Region = le.GetRegion(1,0,4,1),
			Text = "Pick Some Items"};
			this.CheckboxList.Add (new ConsoleGui.Controls.CheckBoxItem (){Text = "Item1" });
			this.CheckboxList.Add (new ConsoleGui.Controls.CheckBoxItem (){Text = "Item2" });
			this.CheckboxList.Add (new ConsoleGui.Controls.CheckBoxItem (){Text = "Item3" });
			this.CheckboxList.Add (new ConsoleGui.Controls.CheckBoxItem (){Text = "Item4" });

			this.Controls.Add (HelloLabel);
			this.Controls.Add (CheckboxList);
		}


	}
}

