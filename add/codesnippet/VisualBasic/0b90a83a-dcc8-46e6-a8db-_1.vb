        ' Create a byte array for binary data to associate with the entry.
        Dim myByte(9) As Byte
        Dim i As Integer
        ' Populate the byte array with simulated data.
        For i = 0 To 9
            myByte(i) = CByte(i Mod 2)
        Next i
        ' Write an entry to the event log that includes associated binary data.
        Console.WriteLine("Write from second source ")
        EventLog.WriteEntry("SecondSource", "Writing warning to event log.", _
                             EventLogEntryType.Error, myEventID, myCategory, myByte)