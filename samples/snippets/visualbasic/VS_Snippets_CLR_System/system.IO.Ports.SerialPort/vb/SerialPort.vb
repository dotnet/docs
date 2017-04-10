'<snippet10>
' Use this code inside a project created with the Visual Basic > Windows Desktop > Console Application template.
' Replace the default code in Module1.vb with this code. Then right click the project in Solution Explorer,
' select Properties, and set the Startup Object to PortChat.

Imports System.IO.Ports
Imports System.Threading

Public Class PortChat
    Shared _continue As Boolean
    Shared _serialPort As SerialPort

    '<snippet01>
    Public Shared Sub Main()
        Dim name As String
        Dim message As String
        Dim stringComparer__1 As StringComparer = StringComparer.OrdinalIgnoreCase
        Dim readThread As New Thread(AddressOf Read)

        ' Create a new SerialPort object with default settings.
        _serialPort = New SerialPort()

        ' Allow the user to set the appropriate properties.
        _serialPort.PortName = SetPortName(_serialPort.PortName)
        _serialPort.BaudRate = SetPortBaudRate(_serialPort.BaudRate)
        _serialPort.Parity = SetPortParity(_serialPort.Parity)
        _serialPort.DataBits = SetPortDataBits(_serialPort.DataBits)
        _serialPort.StopBits = SetPortStopBits(_serialPort.StopBits)
        _serialPort.Handshake = SetPortHandshake(_serialPort.Handshake)

        ' Set the read/write timeouts
        _serialPort.ReadTimeout = 500
        _serialPort.WriteTimeout = 500

        _serialPort.Open()
        _continue = True
        readThread.Start()

        Console.Write("Name: ")
        name = Console.ReadLine()

        Console.WriteLine("Type QUIT to exit")

        While _continue
            message = Console.ReadLine()

            If stringComparer__1.Equals("quit", message) Then
                _continue = False
            Else
                _serialPort.WriteLine([String].Format("<{0}>: {1}", name, message))
            End If
        End While

        readThread.Join()
        _serialPort.Close()
    End Sub

    Public Shared Sub Read()
        While _continue
            Try
                Dim message As String = _serialPort.ReadLine()
                Console.WriteLine(message)
            Catch generatedExceptionName As TimeoutException
            End Try
        End While
    End Sub
    '</snippet01>

    '<snippet02>
    ' Display Port values and prompt user to enter a port.
    Public Shared Function SetPortName(defaultPortName As String) As String
        Dim portName As String

        Console.WriteLine("Available Ports:")
        For Each s As String In SerialPort.GetPortNames()
            Console.WriteLine("   {0}", s)
        Next

        Console.Write("Enter COM port value (Default: {0}): ", defaultPortName)
        portName = Console.ReadLine()

        If portName = "" OrElse Not (portName.ToLower()).StartsWith("com") Then
            portName = defaultPortName
        End If
        Return portName
    End Function
    '</snippet02>
    ' Display BaudRate values and prompt user to enter a value.
    Public Shared Function SetPortBaudRate(defaultPortBaudRate As Integer) As Integer
        Dim baudRate As String

        Console.Write("Baud Rate(default:{0}): ", defaultPortBaudRate)
        baudRate = Console.ReadLine()

        If baudRate = "" Then
            baudRate = defaultPortBaudRate.ToString()
        End If

        Return Integer.Parse(baudRate)
    End Function

    '<snippet03>
    ' Display PortParity values and prompt user to enter a value.
    Public Shared Function SetPortParity(defaultPortParity As Parity) As Parity
        Dim parity As String

        Console.WriteLine("Available Parity options:")
        For Each s As String In [Enum].GetNames(GetType(Parity))
            Console.WriteLine("   {0}", s)
        Next

        Console.Write("Enter Parity value (Default: {0}):", defaultPortParity.ToString(), True)
        parity = Console.ReadLine()

        If parity = "" Then
            parity = defaultPortParity.ToString()
        End If

        Return CType([Enum].Parse(GetType(Parity), parity, True), Parity)
    End Function
    '</snippet03>
    ' Display DataBits values and prompt user to enter a value.
    Public Shared Function SetPortDataBits(defaultPortDataBits As Integer) As Integer
        Dim dataBits As String

        Console.Write("Enter DataBits value (Default: {0}): ", defaultPortDataBits)
        dataBits = Console.ReadLine()

        If dataBits = "" Then
            dataBits = defaultPortDataBits.ToString()
        End If

        Return Integer.Parse(dataBits.ToUpperInvariant())
    End Function
    '<snippet04>
    ' Display StopBits values and prompt user to enter a value.

    Public Shared Function SetPortStopBits(defaultPortStopBits As StopBits) As StopBits
        Dim stopBits As String

        Console.WriteLine("Available StopBits options:")
        For Each s As String In [Enum].GetNames(GetType(StopBits))
            Console.WriteLine("   {0}", s)
        Next

        Console.Write("Enter StopBits value (None is not supported and " &
                      vbLf & "raises an ArgumentOutOfRangeException. " &
                      vbLf & " (Default: {0}):", defaultPortStopBits.ToString())
        stopBits = Console.ReadLine()

        If stopBits = "" Then
            stopBits = defaultPortStopBits.ToString()
        End If

        Return CType([Enum].Parse(GetType(StopBits), stopBits, True), StopBits)
    End Function
    '</snippet04>
    '<snippet05>
    Public Shared Function SetPortHandshake(defaultPortHandshake As Handshake) As Handshake
        Dim handshake As String

        Console.WriteLine("Available Handshake options:")
        For Each s As String In [Enum].GetNames(GetType(Handshake))
            Console.WriteLine("   {0}", s)
        Next

        Console.Write("Enter Handshake value (Default: {0}):", defaultPortHandshake.ToString())
        handshake = Console.ReadLine()

        If handshake = "" Then
            handshake = defaultPortHandshake.ToString()
        End If

        Return CType([Enum].Parse(GetType(Handshake), handshake, True), Handshake)
    End Function
    '</snippet05>
End Class
'</snippet10>
