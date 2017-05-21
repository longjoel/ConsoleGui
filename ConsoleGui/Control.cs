using System;

namespace ConsoleGui
{
	public abstract class Control
	{
		public Drawing.Rect Region { get; set; }

		public bool CanHaveFocus { get; set; }
		public bool HasFocus { get; set; }
		public bool IsInvalid { get; set; }

		Form ParentForm { get; set; }

		public Control ()
		{
			CanHaveFocus = false;
		}

		/// <summary>
		/// Invaldate this Form, indicating that this form is due to be redrawn.
		/// </summary>
		public void Invalidate(){
			IsInvalid = true;
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		/// <param name="keyInfo">Key info.</param>
		public virtual void HandleInput (ConsoleKeyInfo keyInfo){

		}

		/// <summary>
		/// Handles the repaint.
		/// </summary>
		/// <param name="context">Context.</param>
		public virtual void HandleRepaint (Interfaces.Drawing.IDrawingContext context){
			IsInvalid = false;

		}
	}
}

