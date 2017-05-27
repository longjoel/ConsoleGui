using System;
using ConsoleGui.Dialogs;
using ConsoleGui.Controls;
using ConsoleGui.Drawing;

namespace ConsoleGui.Samples
{
	/// <summary>
	/// The main form for the Console Gui Sample Program.
	/// </summary>
	public class MainForm:Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Samples.MainForm"/> class.
		/// </summary>
		public MainForm () : base ()
		{

		}

		/// <summary>
		/// Setup the initialization of the form. We do this in OnInitialize instead of the constructor
		/// because when the form is first constructed, it does not have a region. It only has a region
		/// when it has been shown as a form or as a dialog.
		/// 
		/// This is a good place to setup the controls using the layout engine. You do not actually have
		/// to use the layout engine if you don't want to. But it can be very handy to relatively position
		/// your controls is a grid based layout.
		/// </summary>
		public override void OnInitialize ()
		{
			// The layout engine is a completely optional component to allow for simple setup of 
			// controls. You could generate the regions by hand, but you typically have no idea 
			// how much room you actually have.
			var layout = new ConsoleGui.Drawing.TableLayoutEngine (this.Region.Interior, 2, 6);

			// Here I am creating a simple header for the top of the screen.
			var lblHeader = new Label {

				// Set the text allignment to the bottom of the label
				TextAllignment = TextAllignment.Bottom,

				// Set the text field to indicate what is being set.
				Text = "ConsoleGui Samples Demo. Press `Esc` to quit.",

				// Use the layout engine to figure out how where to draw the thing.
				Region = layout.GetRegion (0, 0, 2, 1)
			};

			// Add the control to the built in control collection.
			this.Controls.Add (lblHeader);

			// Demonstrate a simple read only multi textbox
			var roTextInstructions = new ReadOnlyTextbox {

				// Scroll bar indicates where in the text box you are.
				ScrollbarVisible = true,

				// Again, use the layout engine to get the region to draw it in
				Region = layout.GetRegion (0, 1, 2, 2),

				// Display some text.
				Text = string.Join ("\n",
					"Instructions:",
					"Use Tab to cycle between fields. Press `Esc` to exit.",
					"For a read only text box press up or down to scroll. Not all controls will be scrollable.",
					"This one should be though.",
					"", "", "",
					"There we are!")
			};

			this.Controls.Add (roTextInstructions);

			// Add a very simple button to demonstrate opening a new dialog.
			var showDialogButton = new Button {
				TextAllignment = TextAllignment.Center,
				Text = "Show a yes or no dialog.",
				Region = layout.GetRegion (0, 3, 1, 1),
				OnClick = () => {
					new Dialogs.YesNoDialog ("Show a simple dialog.").ShowDialog ();
				},
			};

			this.Controls.Add (showDialogButton);

			var testTextbox = new Textbox{
				Region = layout.GetRegion(0,4,2,2)};

			this.Controls.Add (testTextbox);

			base.OnInitialize ();
		}


	}
}

