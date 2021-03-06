﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleGui
{
    public class Application
    {
        private static bool _isExiting;
        public static void Exit() { _isExiting = true; }

        public Interfaces.Drawing.IDrawingContext _drawingContext;

        public Application(Form mainForm)
        {
            Console.CursorVisible = false;
            _isExiting = false;
            _drawingContext = new Drawing.ConsoleDrawingContext();

            mainForm.ShowForm();
        }

        public void Run()
        {

            while (!_isExiting)
            {

                if (Console.KeyAvailable)
                {
                    var kInfo = Console.ReadKey(true);

                    // universal exit key. Can exit any form.
                    if (kInfo.Key == ConsoleKey.Escape)
                    {
                        Internals.WindowManager.Instance.Pop();
                    }

                    if (Internals.WindowManager.Instance.Forms.Any())
                    {
                        Internals.WindowManager.Instance.Forms.Last().HandleInput(kInfo);
                    }
                    else
                    {
                        break;
                    }


                }


                var areDirty = false;
                for (int i = 0; i < Internals.WindowManager.Instance.Forms.Count(); i++)
                {
                    if (Internals.WindowManager.Instance.Forms[i].IsInvalid)
                    {
                        areDirty = true;
                    }

                    if (areDirty)
                    {
                        _drawingContext.FillRectangle(Internals.WindowManager.Instance.Forms[i].Region);
                        Internals.WindowManager.Instance.Forms[i].HandleRepaint(_drawingContext);
                        Internals.WindowManager.Instance.Forms[i].IsInvalid = false;
                    }
                }

                _isExiting = !Internals.WindowManager.Instance.Forms.Any();

            }
        }
    }
}

