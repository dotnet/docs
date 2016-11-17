        Sub SendSerialData(ByVal data As String)
            ' Send strings to a serial port.
            Using com1 As IO.Ports.SerialPort = 
                    My.Computer.Ports.OpenSerialPort("COM1")
                com1.WriteLine(data)
            End Using
        End Sub