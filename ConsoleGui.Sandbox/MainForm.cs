using System;

namespace ConsoleGui.Sandbox
{
	public class MainForm:Form
	{
		ConsoleGui.Drawing.ReadOnlyTextbox HelloLabel { get; set; }
		ConsoleGui.Drawing.CheckboxList CheckboxList {get;set;}
		public MainForm ()
		{
			this.Region = new ConsoleGui.Drawing.Rect (
				0, 0,
				Console.BufferWidth - 1, Console.BufferHeight - 1);

			var le = new Drawing.TableLayoutEngine (this.Region.Interior);
			le.LayoutCols = 1;
			le.LayoutRows = 5;

			this.HelloLabel = new ConsoleGui.Drawing.ReadOnlyTextbox () {
				Text = "Hello!",
				Region = le.GetRegion(0,0,1,1)
			};

			this.CheckboxList = new ConsoleGui.Drawing.CheckboxList (){
				Region = le.GetRegion(1,0,4,1),
			Text = "Pick Some Items"};
			this.CheckboxList.Add (new ConsoleGui.Drawing.CheckBoxItem (){Text = "Item1" });
			this.CheckboxList.Add (new ConsoleGui.Drawing.CheckBoxItem (){Text = "Item2" });
			this.CheckboxList.Add (new ConsoleGui.Drawing.CheckBoxItem (){Text = "Item3" });
			this.CheckboxList.Add (new ConsoleGui.Drawing.CheckBoxItem (){Text = "Item4" });

			this.Controls.Add (HelloLabel);
			this.Controls.Add (CheckboxList);
		}


	}
}

