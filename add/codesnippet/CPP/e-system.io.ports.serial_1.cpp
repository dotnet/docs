#using <System.dll>

using namespace System;
using namespace System::IO::Ports;

ref class PortDataReceived
{
public:
    static void Main()
    {
        SerialPort^ mySerialPort = gcnew SerialPort("COM1");

        mySerialPort->BaudRate = 9600;
        mySerialPort->Parity = Parity::None;
        mySerialPort->StopBits = StopBits::One;
        mySerialPort->DataBits = 8;
        mySerialPort->Handshake = Handshake::None;
        mySerialPort->RtsEnable = true;

        mySerialPort->DataReceived += gcnew SerialDataReceivedEventHandler(DataReceivedHandler);

        mySerialPort->Open();

        Console::WriteLine("Press any key to continue...");
        Console::WriteLine();
        Console::ReadKey();
        mySerialPort->Close();
    }

private:
    static void DataReceivedHandler(
                        Object^ sender,
                        SerialDataReceivedEventArgs^ e)
    {
        SerialPort^ sp = (SerialPort^)sender;
        String^ indata = sp->ReadExisting();
        Console::WriteLine("Data Received:");
        Console::Write(indata);
    }
};

int main()
{
    PortDataReceived::Main();
}