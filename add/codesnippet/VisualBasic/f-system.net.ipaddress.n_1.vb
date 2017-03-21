    Public Shared Sub Main()

        ' Gets the IP address indicating that no network interface should be used
        ' and converts it to a string. 
        Dim address As String = IPAddress.None.ToString()
        Console.WriteLine(("IP address : " + address))
    End Sub 'Main 