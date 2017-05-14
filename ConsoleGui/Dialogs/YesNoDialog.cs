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
			this.Region = new ConsoleGui.Drawing.Rect (
				(int)((double)Console.BufferWidth * .25),
				(int)((double)Console.BufferHeight * .25),
				(int)((double)Console.BufferWidth * .75),
				(int)((double)Console.BufferHeight * .75));

			MessageLabel = new ConsoleGui.Controls.Label (){
				Region = new ConsoleGui.Drawing.Rect(Region.Left+1, Region.Top+1, Region.Right-1, Region.Bottom-2),
				Text = message
			};

			YesButton = new ConsoleGui.Controls.Button () {
				Text = "Yes",
				Region = new ConsoleGui.Drawing.Rect (Region.Left + 1, Region.Bottom-1, Region.Left+7, Region.Bottom - 1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.Yes;
					Close();
				})
			};

			NoButton = new ConsoleGui.Controls.Button () {
				Text = "No",
				Region = new ConsoleGui.Drawing.Rect (YesButton.Region.Right + 1, Region.Bottom - 1, Region.Right+4, Region.Bottom - 1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.Yes;
					Close();
				})
			};

			this.Controls.Add (MessageLabel);
			this.Controls.Add (YesButton);
			this.Controls.Add (NoButton);
		}


	}
}

