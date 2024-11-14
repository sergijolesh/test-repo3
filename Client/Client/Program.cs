using System;
using System.IO.Ports;
using System.Threading;

class SerialClient
{
    static void Main()
    {
        SerialPort serialPort = new SerialPort("COM3", 9600);
        try
        {
            serialPort.Open();
            Thread.Sleep(2000);
            while (true)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.WriteLine("Hello, Server");
                Thread.Sleep(100);
                string response = serialPort.ReadLine();
                Console.WriteLine("Received from server: " + response.Trim());
            }
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Read/Write operation timed out.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                Console.WriteLine("Closed the connection.");
            }
        }
    }
}
