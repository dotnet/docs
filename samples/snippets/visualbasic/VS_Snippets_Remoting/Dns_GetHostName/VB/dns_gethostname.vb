 '
'   This program demonstrates the 'GetHostName' method of 'Dns' class.
'   It creates a 'DnsHostName' instance and calls 'GetHostName' method to get the local host 
'   computer name. Then prints the computer name on the console.
'

Imports System
Imports System.Net
Imports System.Net.Sockets



Class DnsHostName
    
    Public Shared Sub Main()
        Dim dnsHostNameObj As New DnsHostName()
        dnsHostNameObj.DisplayLocalHostName()
    End Sub 'Main
    
    
' <Snippet1>
    Public Sub DisplayLocalHostName()
        Try
            ' Get the local computer host name.
            Dim hostName As [String] = Dns.GetHostName()
            Console.WriteLine(("Computer name :" + hostName))
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
' </Snippet1>
    End Sub 'DisplayLocalHostName
End Class 'DnsHostName 