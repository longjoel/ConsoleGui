using System;

namespace ConsoleGui
{
	public class Form
	{
		public bool IsInvalid { get; set; }

		public Form ()
		{
			IsInvalid = true;
		}

		public void Invaldate(){
			IsInvalid = true;
		}
	}
}

