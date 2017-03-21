    Public Sub DisplayHostAddress(IpAddressString As [String])
        Try
            Dim hostIPAddress As IPAddress = IPAddress.Parse(IpAddressString)
            
            ' Call the GetHostByAddress(IPAddress) method, passing an IPAddress object as an argument 
            ' to obtain an IPHostEntry instance, containing address information for the specified host.
            
            Dim hostInfo As IPHostEntry = Dns.GetHostByAddress(hostIPAddress)
            ' Get the IP address list that resolves to the host names contained in 
            ' the Alias property.
            Dim address As IPAddress() = hostInfo.AddressList
            ' Get the alias names of the above addresses in the IP address list.
            Dim [alias] As [String]() = hostInfo.Aliases
            
            Console.WriteLine(("Host name : " + hostInfo.HostName))
            Console.WriteLine(ControlChars.Cr + "Aliases :")
            Dim index As Integer
            For index = 0 To [alias].Length - 1
                Console.WriteLine([alias](index))
            Next index
            Console.WriteLine(ControlChars.Cr + "IP address list : ")

            For index = 0 To address.Length - 1
                Console.WriteLine(address(index))
            Next index
            
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            
        Catch e As FormatException
            Console.WriteLine("FormatException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'DisplayHostAddress