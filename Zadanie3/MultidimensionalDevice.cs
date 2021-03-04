using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class MultidimensionalDevice : IFax
    {
        public int Counter { get; private set; } = 0;

        protected IDevice.State state = IDevice.State.on;
        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.off;
        }

        public void PowerOn()
        {
            state = IDevice.State.off;
        }

        public void Send(in IDocument document, string nameOfDevice)
        {
            if (GetState() == IDevice.State.on)
            {
                Console.WriteLine("The file named " + document.GetFileName() + "has been sent to the device named: " + nameOfDevice);
            }
            else
                throw new Exception("The multifunctional device is turned off.");
        }
    }
}
