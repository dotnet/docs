 '
'   This program demonstrates 'GetHostByName' method of 'Dns' class.
'   It takes a URL string from commandline or uses default value, and obtains 
'   the 'IPHostEntry' object by calling 'GetHostByName' method of 'Dns' class.Then 
'   prints host name,IP address list and aliases.         
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic



Class DnsHostByName
    
    Public Shared Sub Main()
        
        Dim hostName As [String] = ""
        Dim myDnsHostByName As New DnsHostByName()
        Console.Write("Type a URL (press Enter for default, default is 'www.microsoft.net') : ")
        hostName = Console.ReadLine()
        If hostName.Length > 0 Then
            myDnsHostByName.DisplayHostName(hostName)
        Else
            myDnsHostByName.DisplayHostName("www.microsoft.net")
        End If
    End Sub 'Main
     
' <Snippet1>
    Public Sub DisplayHostName(hostName As [String])
        Try
            ' Call the GetHostByName method, passing a DNS style host name(for example,
            ' "www.contoso.com") as an argument to obtain an IPHostEntry instance, that 
            ' contains information for the specified host.
            
            Dim hostInfo As IPHostEntry = Dns.GetHostByName(hostName)
            ' Get the IP address list that resolves to the host names contained in 
            ' the Alias property.
            Dim address As IPAddress() = hostInfo.AddressList
            ' Get the alias names of the the addresses in the IP address list.
            Dim [alias] As [String]() = hostInfo.Aliases
            
            Console.WriteLine(("Host name : " + hostInfo.HostName))
            Console.WriteLine(ControlChars.Cr + "Aliases : ")
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
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
' </Snippet1>
    End Sub 'DisplayHostName
End Class 'DnsHostByName 