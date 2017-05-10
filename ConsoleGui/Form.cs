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

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleGui.Form"/> class.
		/// </summary>
		public Form ()
		{
			IsInvalid = true;
			Controls = new List<Control> ();
		}

		/// <summary>
		/// Invaldate this Form, indicating that this form is due to be redrawn.
		/// </summary>
		public void Invaldate(){
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

