//<snippet06>
using System;
using System.IO.Ports;

class PortDataReceived
{
    public static void Main()
    {
        //<Snippet20>
        SerialPort mySerialPort = new SerialPort("COM1");

        mySerialPort.BaudRate = 9600;
        mySerialPort.Parity = Parity.None;
        mySerialPort.StopBits = StopBits.One;
        mySerialPort.DataBits = 8;
        mySerialPort.Handshake = Handshake.None;
        mySerialPort.RtsEnable = true;
        //</Snippet20>

        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        mySerialPort.Open();

        Console.WriteLine("Press any key to continue...");
        Console.WriteLine();
        Console.ReadKey();
        mySerialPort.Close();
    }

    private static void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Console.WriteLine("Data Received:");
        Console.Write(indata);
    }
}
//</snippet06>
