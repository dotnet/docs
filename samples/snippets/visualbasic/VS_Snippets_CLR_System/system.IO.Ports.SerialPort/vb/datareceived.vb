'<snippet06>
Imports System
Imports System.IO.Ports

Class PortDataReceived
    Public Shared Sub Main()
        '<Snippet20>
        Dim mySerialPort As New SerialPort("COM1")

        mySerialPort.BaudRate = 9600
        mySerialPort.Parity = Parity.None
        mySerialPort.StopBits = StopBits.One
        mySerialPort.DataBits = 8
        mySerialPort.Handshake = Handshake.None
        mySerialPort.RtsEnable = True
        '</Snippet20>

        AddHandler mySerialPort.DataReceived, AddressOf DataReceivedHandler

        mySerialPort.Open()

        Console.WriteLine("Press any key to continue...")
        Console.WriteLine()
        Console.ReadKey()
        mySerialPort.Close()
    End Sub

    Private Shared Sub DataReceivedHandler(
                        sender As Object,
                        e As SerialDataReceivedEventArgs)
        Dim sp As SerialPort = CType(sender, SerialPort)
        Dim indata As String = sp.ReadExisting()
        Console.WriteLine("Data Received:")
        Console.Write(indata)
    End Sub
End Class
'</snippet06>
