using System;

namespace ConsoleGui.Dialogs
{
	public class YesNoDialog:Form
	{
		public YesNoDialogResult? Result { get; set; }
		public ConsoleGui.Controls.ReadOnlyTextbox MessageLabel { get; set; }
		public ConsoleGui.Controls.Button YesButton { get; set; }
		public ConsoleGui.Controls.Button NoButton { get; set; }

		private string _message;
		public YesNoDialog (string message)
		{
			_message = message;

		}

		public override void OnInitialize ()
		{

			// Layout engine for children controls.
			var le = new ConsoleGui.Drawing.TableLayoutEngine (this.Region.Interior, 2,5);


			MessageLabel = new ConsoleGui.Controls.ReadOnlyTextbox (){
				Region = le.GetRegion(0,0,2,4),
				Text = _message,
				ScrollbarVisible = true
			};

			YesButton = new ConsoleGui.Controls.Button () {
				Text = "Yes",
				Region = le.GetRegion(0,4,1,1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.Yes;
					Close();
				})
			};

			NoButton = new ConsoleGui.Controls.Button () {
				Text = "No",
				Region = le.GetRegion(1,4,1,1),
				OnClick = new Action (() => {
					Result = YesNoDialogResult.No;
					Close();
				})
			};

			this.Controls.Add (MessageLabel);
			this.Controls.Add (YesButton);
			this.Controls.Add (NoButton);
			base.OnInitialize ();
		}


	}
}

