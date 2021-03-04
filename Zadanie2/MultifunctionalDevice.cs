using System;
using Zadanie1;

namespace Zadanie2
{
    public interface IFax : IDevice
    {
        /// <summary>
        /// Dokument jest wysyłany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        /// <param name="nameOfDevice">obiekt typu string, adres odbiorcy</param>
        void Send(in IDocument document, string nameOfDevice);
    }
    public class MultifunctionalDevice : Copier, IFax
    {
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
