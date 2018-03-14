//<SNIPPET1>
#using <System.dll>

using namespace System;
using namespace System::IO::Ports;
using namespace System::ComponentModel;

void main()
{
    array<String^>^ serialPorts = nullptr;
    try
    {
        // Get a list of serial port names.
        serialPorts = SerialPort::GetPortNames();
    }
    catch (Win32Exception^ ex)
    {
        Console::WriteLine(ex->Message);
    }

    Console::WriteLine("The following serial ports were found:");

    // Display each port name to the console.
    for each(String^ port in serialPorts)
    {
        Console::WriteLine(port);
    }
}

//</SNIPPET1>
