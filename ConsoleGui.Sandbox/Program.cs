﻿using System;

namespace ConsoleGui.Sandbox
{
	class MainClass
	{
		public static void TestConsoleDrawingContext(){
			var dc = new Drawing.ConsoleDrawingContext ();

			dc.DrawThickBorder (new ConsoleGui.Drawing.Rect (0, 0, 16, 16));

			Console.ReadLine ();

			dc.DrawString (0, 0, "Simple Text");

			dc.DrawString (0, 1, " Advanced Text", 40, 1);

			Console.ReadLine ();

			Console.Clear ();

			dc.DrawText(new ConsoleGui.Drawing.Rect(0,0,40,18), string.Join("\n",
				"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
				" Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
				" when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
				" It has survived not only five centuries, but also the ",
				"leap into electronic typesetting, remaining essentially unchanged. ",
				"It was popularised in the 1960s with the release of Letraset ",
				"sheets containing Lorem Ipsum passages, and more recently ",
				"with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."));

			dc.DrawText(new ConsoleGui.Drawing.Rect(42,0,79,18), string.Join("\n",
				"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
				" Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
				" when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
				" It has survived not only five centuries, but also the ",
				"leap into electronic typesetting, remaining essentially unchanged. ",
				"It was popularised in the 1960s with the release of Letraset ",
				"sheets containing Lorem Ipsum passages, and more recently ",
				"with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."), false);

			Console.ReadLine ();

		}

		public static void Testlayout(){
			var lm = new Drawing.LayoutEngine (new ConsoleGui.Drawing.Rect (
				         0, 0, Console.BufferWidth - 1, Console.BufferHeight - 1));

			lm.Rows = new System.Collections.Generic.List<ConsoleGui.Drawing.LayoutRow>(){
				new ConsoleGui.Drawing.LayoutRow(){Columns = 3},
				new ConsoleGui.Drawing.LayoutRow(){Columns = 5}};

			var dc = new Drawing.ConsoleDrawingContext ();
			dc.DrawThinBorder (lm.GetRegion (0, 0));
			dc.DrawThinBorder (lm.GetRegion (0, 1));
			dc.DrawThinBorder (lm.GetRegion (0, 2));

			dc.DrawThinBorder (lm.GetRegion (1, 0));
			dc.DrawThinBorder (lm.GetRegion (1, 2));
			dc.DrawThinBorder (lm.GetRegion (1, 4));


		}

		public static void Main (string[] args)
		{

			Console.Clear ();

			Testlayout ();

			Console.ReadLine ();
//			var app = new Application(new MainForm());
//			app.Run ();

		}
	}
}
