using System;
using System.Collections.Generic;

namespace ConsoleGui
{
	/// <summary>
	/// The form can be considered to be a specific screen in a given ui. A form is Composed of a collection of child controls.
	/// </summary>
	public abstract class Form
	{
		/// <summary>
		/// Gets or sets the region.
		/// </summary>
		/// <value>The region.</value>
		public Drawing.Rect Region { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is invalid.
		/// </summary>
		/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
		public bool IsInvalid { get; set; }

		/// <summary>
		/// Gets or sets the controls.
		/// </summary>
		/// <value>The controls.</value>
		public List<Control> Controls{ get; set; }

		public Control ControlWithFocus { get; private set; }

		private int _controlFocusedIndex;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Form"/> class.
		/// </summary>
		public Form ()
		{
			IsInvalid = true;
			Controls = new List<Control> ();
			_controlFocusedIndex = -1;
		}

		/// <summary>
		/// Invaldate this Form, indicating that this form is due to be redrawn.
		/// </summary>
		public void Invaldate ()
		{
			IsInvalid = true;
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		/// <param name="keyInfo">Key info.</param>
		public virtual void HandleInput (ConsoleKeyInfo keyInfo)
		{
			// by default the tab key is going to switch the active control.
			if(keyInfo.Key == ConsoleKey.Tab){
				if (_controlFocusedIndex != -1) {
					Controls [_controlFocusedIndex].IsFocus = false;
					Controls [_controlFocusedIndex].Invaldate();
				}

				// if the shift modifier is used, go back up one line instead of down.
				if (keyInfo.Modifiers.HasFlag( ConsoleModifiers.Shift)) {
					_controlFocusedIndex -= 1;
					if (_controlFocusedIndex < 0 ) {
						_controlFocusedIndex = Controls.Count-1;
					}
				} else {
					_controlFocusedIndex += 1;
					if (_controlFocusedIndex >= Controls.Count) {
						_controlFocusedIndex = 0;
					}
				}

				Controls [_controlFocusedIndex].IsFocus = true;
				Controls [_controlFocusedIndex].Invaldate ();

			}
			
		}

		/// <summary>
		/// Handles the repaint.
		/// </summary>
		/// <param name="context">Context.</param>
		public virtual void HandleRepaint (Interfaces.Drawing.IDrawingContext context)
		{
			foreach (var c in Controls) {
				if (c.IsInvalid) {
					c.HandleRepaint (context);
				}
			}
			IsInvalid = false;
		}
	}
}

