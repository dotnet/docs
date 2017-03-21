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