         Dim myLog As String = "myNewLog"
         If EventLog.Exists(myLog) Then
            Console.WriteLine("Log '" + myLog + "' exists.")
         Else
            Console.WriteLine("Log '" + myLog + "' does not exist.")
         End If