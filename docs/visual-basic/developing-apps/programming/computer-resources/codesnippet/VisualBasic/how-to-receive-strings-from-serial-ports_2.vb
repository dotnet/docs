        Dim com1 As IO.Ports.SerialPort = Nothing
        Try
            com1 = My.Computer.Ports.OpenSerialPort("COM1")
            com1.ReadTimeout = 10000

        Catch ex As TimeoutException
            returnStr = "Error: Serial Port read timed out."
        Finally
            If com1 IsNot Nothing Then com1.Close()
        End Try