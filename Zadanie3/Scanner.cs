using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;

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

        public void Scan(out IDocument document, IDocument.FormatType formatType)
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
        public void Scan(out IDocument doc2)
        {
            IDocument.FormatType formatType = IDocument.FormatType.JPG;
            Scan(out doc2, formatType);
        }

        
    }
}
