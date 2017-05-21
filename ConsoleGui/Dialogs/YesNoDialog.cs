using System;

namespace ConsoleGui.Dialogs
{
	public class YesNoDialog:Form
	{
		public YesNoDialogResult? Result { get; set; }
		public Controls.Label MessageLabel { get; set; }
		public Controls.Button YesButton { get; set; }
		public Controls.Button NoButton { get; set; }

		public YesNoDialog (string message)
		{
			// Dialog windows set their own region.
			this.Region = new ConsoleGui.Drawing.Rect (
				(int)((double)Console.BufferWidth * .25),
				(int)((double)Console.BufferHeight * .25),
				(int)((double)Console.BufferWidth * .75),
				(int)((double)Console.BufferHeight * .75));

			// Layout engine for children controls.
			this.LayoutEngine = new ConsoleGui.Drawing.TableLayoutEngine (new Drawing.Rect(
				this.Region.Left+1, 
				this.Region.Top+1, 
				this.Region.Right-1, 
				this.Region.Bottom-1));

			this.LayoutEngine.LayoutRows = 5;
			this.LayoutEngine.LayoutCols = 1;


			MessageLabel = new ConsoleGui.Controls.Label (){
				Region = LayoutEngine.GetRegion(0,0,3,1),
				Text = message,
				ScrollbarVisible = true
			};

			YesButton = new ConsoleGui.Controls.Button () {
				Text = "Yes",
				Region = LayoutEngine.GetRegion(3,0,1,1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.Yes;
					Close();
				})
			};

			NoButton = new ConsoleGui.Controls.Button () {
				Text = "No",
				Region = LayoutEngine.GetRegion(4,0,1,1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.No;
					Close();
				})
			};

			this.Controls.Add (MessageLabel);
			this.Controls.Add (YesButton);
			this.Controls.Add (NoButton);
		}


	}
}

