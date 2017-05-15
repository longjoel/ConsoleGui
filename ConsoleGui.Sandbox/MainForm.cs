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

			this.HelloLabel = new ConsoleGui.Controls.Label () {
				Text = "Hello!",
				Region = new ConsoleGui.Drawing.Rect (1, 1, Region.Right - 1, 3)
			};

			this.CheckboxList = new ConsoleGui.Controls.CheckboxList (){
				Region = new ConsoleGui.Drawing.Rect(
					1, 
					this.HelloLabel.Region.Bottom+1, 
					Region.Right-1, 
					this.HelloLabel.Region.Bottom+7),
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

