using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        protected IDevice.State state = IDevice.State.on;
        public IDevice.State GetState() => state;
        public int Counter { get; private set; } = 0;
        public int PrintCounter { get; private set; } = 0;

         public void PowerOff()
         {
            state = IDevice.State.off;
         }

        public void PowerOn()
        {
            state = IDevice.State.on;
        }

        public void Print(in IDocument doc1)
        {
            if (GetState() == IDevice.State.on)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine(dateTime.ToString() + " Print: " + doc1.GetFileName());
                PrintCounter++;
            }
            else
                throw new Exception("The copier is turned off.");
        }
    }
}
