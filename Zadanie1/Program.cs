using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            xerox.PowerOn();
            xerox.PowerOff();
            xerox.PowerOn();

            Console.WriteLine(xerox.GetState());

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2, doc3, doc4, doc5;
            xerox.Scan(out doc2, IDocument.FormatType.JPG);
            xerox.Scan(out doc3, IDocument.FormatType.TXT);
            xerox.Scan(out doc4, IDocument.FormatType.PDF);
            xerox.Scan(out doc5);

            Console.WriteLine("Scan and print: ");
            xerox.ScanAndPrint();
            Console.WriteLine("Counter: " + xerox.Counter);
            Console.WriteLine("Print Counter: " + xerox.PrintCounter);
            Console.WriteLine("Scan Counter: " + xerox.ScanCounter);

            
        }
    }
}
