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