        Try
            ' Call the Resolve method passing a DNS style host name or an IP address in 
            ' dotted-quad notation (for example, "www.contoso.com" or "207.46.131.199") to 
            ' obtain an IPHostEntry instance that contains address information for the 
            ' specified host.
            Dim hostInfo As IPHostEntry = Dns.Resolve(hostString)
            ' Get the IP address list that resolves to the host names contained in the Alias 
            ' property.
            Dim address As IPAddress() = hostInfo.AddressList
            ' Get the alias names of the addresses in the IP address list.
            Dim [alias] As [String]() = hostInfo.Aliases

            Console.WriteLine(("Host name : " + hostInfo.HostName))
            Console.WriteLine(ControlChars.Cr + "Aliases : ")
            Dim index As Integer
            For index = 0 To [alias].Length - 1
                Console.WriteLine([alias](index))
            Next index
            Console.WriteLine(ControlChars.Cr + "IP Address list :")

            For index = 0 To address.Length - 1
                Console.WriteLine(address(index))
            Next index
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As NullReferenceException
            Console.WriteLine("NullReferenceException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try