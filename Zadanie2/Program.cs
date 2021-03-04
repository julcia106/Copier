using System;
using Zadanie1;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            MultifunctionalDevice device = new MultifunctionalDevice();

            device.PowerOn();
            Console.WriteLine(device.GetState());

            IDocument doc1 = new PDFDocument("aaa.pdf");
            device.Print(in doc1);

            IDocument doc2, doc3, doc4, doc5;
            device.Scan(out doc2, IDocument.FormatType.JPG);
            device.Scan(out doc3, IDocument.FormatType.TXT);
            device.Scan(out doc4, IDocument.FormatType.PDF);
            device.Scan(out doc5);

            device.Send(doc1, "asd@e-fax.com.pl");

        }
    }
}
