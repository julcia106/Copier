using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ver1UnitTests;
using Zadanie1;
using Zadanie2;

namespace Zadanie2UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void MFD_GetState_StateOff()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOff();

            Assert.AreEqual(IDevice.State.off, device.GetState());
        }

        [TestMethod]
        public void MFD_GetState_StateOn()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            Assert.AreEqual(IDevice.State.on, device.GetState());
        }

        // weryfikacja, czy po wywo³aniu metody `Send` i w³¹czonym urz¹dzeniu wielofunkcyjnym w napisie pojawia siê s³owo `sent`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_Send_DeviceOn()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                device.Send(doc1, "asd@e-fax.com.pl");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("sent"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywo³aniu metody `Print` i w³¹czonej kopiarce w napisie pojawia siê s³owo `Print`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_Print_DeviceOn()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                device.Print(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywo³aniu metody `Print` i wy³¹czonej kopiarce w napisie NIE pojawia siê s³owo `Print`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_Print_DeviceOff()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                device.Print(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywo³aniu metody `Scan` i wy³¹czonej kopiarce w napisie NIE pojawia siê s³owo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void Copier_Scan_DeviceOff()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                device.Scan(out doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywo³aniu metody `Scan` i wy³¹czonej kopiarce w napisie pojawia siê s³owo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_Scan_DeviceOn()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                device.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy wywo³anie metody `Scan` z parametrem okreœlaj¹cym format dokumentu
        // zawiera odpowiednie rozszerzenie (`.jpg`, `.txt`, `.pdf`)
        [TestMethod]
        public void MFD_Scan_FormatTypeDocument()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                device.Scan(out doc1, formatType: IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                device.Scan(out doc1, formatType: IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                device.Scan(out doc1, formatType: IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


        // weryfikacja, czy po wywo³aniu metody `ScanAndPrint` i wy³¹czonej kopiarce w napisie pojawiaj¹ siê s³owa `Print`
        // oraz `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_ScanAndPrint_DeviceOn()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                device.ScanAndPrint();
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywo³aniu metody `ScanAndPrint` i wy³¹czonej kopiarce w napisie NIE pojawia siê s³owo `Print`
        // ani s³owo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MFD_ScanAndPrint_DeviceOff()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                device.ScanAndPrint();
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MFD_PrintCounter()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            device.Print(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            device.Print(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            device.Print(in doc3);

            device.PowerOff();
            device.Print(in doc3);
            device.Scan(out doc1);
            device.PowerOn();

            device.ScanAndPrint();
            device.ScanAndPrint();

            // 5 wydruków, gdy urz¹dzenie w³¹czone
            Assert.AreEqual(5, device.PrintCounter);
        }

        [TestMethod]
        public void MFD_ScanCounter()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();

            IDocument doc1;
            device.Scan(out doc1);
            IDocument doc2;
            device.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            device.Print(in doc3);

            device.PowerOff();
            device.Print(in doc3);
            device.Scan(out doc1);
            device.PowerOn();

            device.ScanAndPrint();
            device.ScanAndPrint();

            // 4 skany, gdy urz¹dzenie w³¹czone
            Assert.AreEqual(4, device.ScanCounter);
        }

        [TestMethod]
        public void MFD_PowerOnCounter()
        {
            MultifunctionalDevice device = new MultifunctionalDevice();
            device.PowerOn();
            device.PowerOn();
            device.PowerOn();

            IDocument doc1;
            device.Scan(out doc1);
            IDocument doc2;
            device.Scan(out doc2);

            device.PowerOff();
            device.PowerOff();
            device.PowerOff();
            device.PowerOn();

            IDocument doc3 = new ImageDocument("aaa.jpg");
            device.Print(in doc3);

            device.PowerOff();
            device.Print(in doc3);
            device.Scan(out doc1);
            device.PowerOn();

            device.ScanAndPrint();
            device.ScanAndPrint();

            // 3 w³¹czenia
            Assert.AreEqual(3, device.Counter);
        }

    }
}
