using System;
using ConsoleGui.Drawing;
using ConsoleGui.Controls;

namespace ConsoleGui.Samples
{
	public class TextBoxForm:Form
	{
		private Textbox _textEntry;
		private Button _exitButton;

		public TextBoxForm ()
		{
		}

		public override void OnInitialize ()
		{
			var le = new TableLayoutEngine (this.Region.Interior, 3, 5);

			_textEntry = new Textbox{
				Region = le.GetRegion(0,0,3,4),
				Text = "This is a sample textbox.\n Use the arrow keys to navigate, and tab to switch out."
			};

			this.Controls.Add(_textEntry);

			_exitButton = new Button{ 
				OnClick = ()=>{this.Close();},
				Text = "Close",
				Region = le.GetRegion(2, 4),
				TextAllignment = TextAllignment.Center
			};

			this.Controls.Add (_exitButton);

			base.OnInitialize ();
		}
	}
}

