using System;
using System.Collections.Generic;
using System.Linq;

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


		private bool _isInvalid;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is invalid.
		/// </summary>
		/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
		public bool IsInvalid { get { return _isInvalid || Controls.Any (c => c.IsInvalid); } set { _isInvalid = value; } }

		/// <summary>
		/// Gets or sets the controls.
		/// </summary>
		/// <value>The controls.</value>
		public List<Control> Controls{ get; set; }

		/// <summary>
		/// Gets the control with focus.
		/// </summary>
		/// <value>The control with focus.</value>
		public Control ControlWithFocus { get; private set; }

		/// <summary>
		/// Gets or sets the layout engine.
		/// </summary>
		/// <value>The layout engine.</value>
		public Drawing.TableLayoutEngine LayoutEngine { get; set; }

		private int _controlFocusedIndex;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Form"/> class.
		/// </summary>
		public Form ()
		{
			IsInvalid = true;
			Controls = new List<Control> ();
			//LayoutEngine = new ConsoleGui.Drawing.LayoutEngine ();
			_controlFocusedIndex = -1;
		}

		/// <summary>
		/// Invaldate this Form, indicating that this form is due to be redrawn.
		/// </summary>
		public void Invalidate ()
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
			if (keyInfo.Key == ConsoleKey.Tab) {
				if (_controlFocusedIndex != -1) {
					Controls [_controlFocusedIndex].HasFocus = false;
					Controls [_controlFocusedIndex].Invalidate ();
				}

				do {
					// if the shift modifier is used, go back up one line instead of down.
					if (keyInfo.Modifiers.HasFlag (ConsoleModifiers.Shift)) {
						_controlFocusedIndex -= 1;
						if (_controlFocusedIndex < 0) {
							_controlFocusedIndex = Controls.Count - 1;
						}
					} else {
						_controlFocusedIndex += 1;
						if (_controlFocusedIndex >= Controls.Count) {
							_controlFocusedIndex = 0;
						}
					}
				} while (!Controls [_controlFocusedIndex].CanHaveFocus);
				Controls [_controlFocusedIndex].HasFocus = true;
				Controls [_controlFocusedIndex].Invalidate ();

				Invalidate ();

			} else {
				if (_controlFocusedIndex != -1) {
					Controls [_controlFocusedIndex].HandleInput (keyInfo);
				}
			}
			
		}

		/// <summary>
		/// Shows the form, taking up the entire console area.
		/// </summary>
		public void ShowForm ()
		{
			this.Region = new ConsoleGui.Drawing.Rect (
				0, 
				0, 
				Console.BufferWidth - 1, 
				Console.BufferHeight - 1);

			Internals.WindowManager.Instance.Push (this);
		}

		/// <summary>
		/// Shows form as a dialog, taking up about 80% of screen realestate.
		/// </summary>
		public void ShowDialog ()
		{
			this.Region = new ConsoleGui.Drawing.Rect (
				(int)((double)Console.BufferWidth * .1),
				(int)((double)Console.BufferHeight * .1),
				(int)((double)Console.BufferWidth * .9),
				(int)((double)Console.BufferHeight * .9));

			Internals.WindowManager.Instance.Push (this);
		}

		/// <summary>
		/// Close this instance.
		/// </summary>
		public void Close ()
		{
			HandleClose ();
			Internals.WindowManager.Instance.Close (this);
		}

		/// <summary>
		/// Handles the repaint.
		/// </summary>
		/// <param name="context">Context.</param>
		public virtual void HandleRepaint (Interfaces.Drawing.IDrawingContext context)
		{
			context.DrawThickBorder (Region);
			foreach (var c in Controls) {
				c.HandleRepaint (context);
			}
			IsInvalid = false;
		}

		/// <summary>
		/// Anything that needs to be handled before the window is closed closed.
		/// </summary>
		public virtual void HandleClose (){
		}
	}
}

