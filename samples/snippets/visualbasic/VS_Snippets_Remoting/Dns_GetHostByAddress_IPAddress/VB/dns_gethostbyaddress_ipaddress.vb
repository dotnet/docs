 '
'   This program demonstrates 'GetHostByAddress(IPAddress)' method of 'Dns' class.
'   It takes an IP address string from commandline or uses default value and creates 
'   an instance of IPAddress for the specified IP address string. Obtains the IPHostEntry 
'   object by calling 'GetHostByAddress' method of 'Dns' class and prints host name,
'   IP address list and aliases.   
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic



Class DnsHostByAddress
    
    Public Shared Sub Main()
        Dim IpAddressString As [String] = ""
        Dim myDnsHostByAddress As New DnsHostByAddress()
        Console.Write("Type an IP address (press Enter for default, default is '207.46.131.199'): ")
        IpAddressString = Console.ReadLine()
        If IpAddressString.Length > 0 Then
            myDnsHostByAddress.DisplayHostAddress(IpAddressString)
        Else
            myDnsHostByAddress.DisplayHostAddress("207.46.131.199")
        End If
    End Sub 'Main
' <Snippet1>     
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
' </Snippet1>
End Class