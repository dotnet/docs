        Sub DialModem()
            ' Dial a number via an attached modem on COM1.
            Using com1 As IO.Ports.SerialPort = 
                    My.Computer.Ports.OpenSerialPort("COM1", 9600)
                com1.DtrEnable = True
                com1.Write("ATDT 555-0100" & vbCrLf)
                ' Insert code to transfer data to and from the modem.
            End Using
        End Sub