        Sub GetSerialPortNames()
            ' Show all available COM ports.
            For Each sp As String In My.Computer.Ports.SerialPortNames
                ListBox1.Items.Add(sp)
            Next
        End Sub