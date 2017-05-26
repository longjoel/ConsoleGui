using System;

namespace ConsoleGui.Dialogs
{
	public class YesNoDialog:Form
	{
		public YesNoDialogResult? Result { get; set; }
		public ConsoleGui.Drawing.ReadOnlyTextbox MessageLabel { get; set; }
		public ConsoleGui.Drawing.Button YesButton { get; set; }
		public ConsoleGui.Drawing.Button NoButton { get; set; }

		public YesNoDialog (string message)
		{
			
			// Layout engine for children controls.
			this.LayoutEngine = new ConsoleGui.Drawing.TableLayoutEngine (this.Region.Interior);

			this.LayoutEngine.LayoutRows = 5;
			this.LayoutEngine.LayoutCols = 2;


			MessageLabel = new ConsoleGui.Drawing.ReadOnlyTextbox (){
				Region = LayoutEngine.GetRegion(0,0,4,2),
				Text = message,
				ScrollbarVisible = true
			};

			YesButton = new ConsoleGui.Drawing.Button () {
				Text = "Yes",
				Region = LayoutEngine.GetRegion(4,0,1,1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.Yes;
					Close();
				})
			};

			NoButton = new ConsoleGui.Drawing.Button () {
				Text = "No",
				Region = LayoutEngine.GetRegion(4,1,1,1),
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

