using System;
using ConsoleGui.Drawing;
using ConsoleGui.Controls;

namespace ConsoleGui.Samples
{
	/// <summary>
	/// Sample form showing off a textbox.
	/// </summary>
	public class TextBoxForm:Form
	{
		/// <summary>
		/// The text entry.
		/// </summary>
		private Textbox _textEntry;

		/// <summary>
		/// The exit button.
		/// </summary>
		private Button _exitButton;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Samples.TextBoxForm"/> class.
		/// </summary>
		public TextBoxForm ()
		{
		}

		/// <summary>
		/// Callback to initialize the form.
		/// </summary>
		public override void OnInitialize ()
		{
			// Create the layout engine using the interior of this control with 3 columns and 4 rows.
			var le = new TableLayoutEngine (this.Region.Interior, 3, 5);

			// Create a new textbox.
			_textEntry = new Textbox{
				// Use the layout engine to create a region taking up the top 4/5ths of the form.
				Region = le.GetRegion(0,0,3,4),
				// Set the text.
				Text = "This is a sample textbox.\n Use the arrow keys to navigate, and tab to switch out."
			};

			// Add this control to the form.
			this.Controls.Add(_textEntry);

			// Create a button that will let you close the form.
			_exitButton = new Button{ 
				// A simple callback to close this form.
				OnClick = ()=>{this.Close();},
				// The text of the button.
				Text = "Close",
				// The region for the button, on the bottom of the form, 2nd column in, 4th row down.
				Region = le.GetRegion(2, 4),
				// Center the text in the middle of the button.
				TextAllignment = TextAllignment.Center
			};

			// Add this control to the form.
			this.Controls.Add (_exitButton);

			// Finish initializing the form.
			base.OnInitialize ();
		}
	}
}

