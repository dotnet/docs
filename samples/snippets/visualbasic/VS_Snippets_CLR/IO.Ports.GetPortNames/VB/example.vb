'<SNIPPET1>
' Insert this code into a new VB Console application project, and set the
' startup object to Sub Main.

Imports System
Imports System.IO.Ports

Module SerialPortExample

    Sub Main()
        ' Get a list of serial port names.
        Dim ports As String() = SerialPort.GetPortNames()

        Console.WriteLine("The following serial ports were found:")

        ' Display each port name to the console.
        Dim port As String
        For Each port In ports
            Console.WriteLine(port)
        Next port

        Console.ReadLine()

    End Sub
End Module

'</SNIPPET1>