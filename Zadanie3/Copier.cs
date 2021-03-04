using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        private Printer InternalPrinter = new Printer();
        private Scanner InternalScanner = new Scanner();
        private MultidimensionalDevice InternalMultiDevice = new MultidimensionalDevice();

        List<IDevice> baseDevices;

        public Copier()
        {
            baseDevices.Add(new Printer());
            baseDevices.Add(new Scanner());
            baseDevices.Add(new MultidimensionalDevice());

            for (int i = 0; i < baseDevices.Count; i++)
            {
                baseDevices[i].PowerOn();
            }
        }

        class Car
        {
            List<wheels> wheels; //kompozycja
            public Car()
            {
                wheels[0] // powołuje do życia 4 koła
            }

        } 
        
        class Car //agregacja
        {
            List<wheels> & wheels;
            public Car(List<wheels> wheels)
            {
                this.wheels = wheels;
            }

        }


        public new int Counter { get; private set; } = 0;
    
        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            InternalScanner.PowerOn();

            if (GetState() == IDevice.State.on)
            {

                InternalScanner.Scan(out document, formatType);
            }
            else
                throw new Exception("The copier is turned off.");
        }

        public void Scan (out IDocument document)
        {
            InternalScanner.PowerOn();

            if (GetState() == IDevice.State.on)
            {
                InternalScanner.Scan(out document);
            }
            else
                throw new Exception("The copier is turned off.");
        }
        public void Print(in IDocument document)
        {
            InternalPrinter.PowerOn();

            if (GetState() == IDevice.State.on)
            {
                InternalPrinter.Print(document);
            }
            else
                throw new Exception("The copier is turned off.");
        }

        public void ScanAndPrint()
        {
            InternalPrinter.PowerOn();
            InternalScanner.PowerOn();

            IDocument doc;
            InternalScanner.Scan(out doc);
            InternalPrinter.Print(doc);
        }

        public void Send(in IDocument document, string nameOfDevice)
        {
            InternalMultiDevice.PowerOn();

            InternalMultiDevice.Send(document, nameOfDevice);
        }
    }
}
