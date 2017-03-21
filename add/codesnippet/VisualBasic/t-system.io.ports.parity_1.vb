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