using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public Copier() { }
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public new int Counter { get; private set; } = 0;

        public new void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public new void PowerOn()   
        {
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
            Counter++;
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

        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.on)
            {
                IDocument doc;
                Scan(out doc);
                Print(doc);
            }
            else
                throw new Exception("The copier is turned off.");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (GetState() == IDevice.State.on)
            {
                DateTime dateTime = DateTime.Now;
                string value = String.Format("{0:D4}", ScanCounter++);

                if (formatType == IDocument.FormatType.TXT)
                {
                    document = new PDFDocument("TXTScan" + value + ".txt");
                    Console.WriteLine(dateTime + " " + document.GetFileName());
                }

                else if (formatType == IDocument.FormatType.PDF)
                {
                    document = new TextDocument("PDFScan" + value + ".pdf");
                    Console.WriteLine(dateTime + " " + document.GetFileName());
                }

                else if (formatType == IDocument.FormatType.JPG)
                {
                    document = new TextDocument("JPGScan" + value + ".jpg");
                    Console.WriteLine(dateTime + " " + document.GetFileName());
                }
                else
                {
                    document = null;
                }
            }
            else
                throw new Exception("The copier is turned off.");
        }
        public void Scan(out IDocument doc2)
        {
            if (GetState() == IDevice.State.on)
            {
                IDocument.FormatType formatType = IDocument.FormatType.JPG;
                Scan(out doc2, formatType );
            }
            else
                throw new Exception("The copier is turned off.");
        }
    }

}
