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