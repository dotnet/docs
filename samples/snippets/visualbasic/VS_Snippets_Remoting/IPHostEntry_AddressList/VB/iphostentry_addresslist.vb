 '
'   This program demostrates 'AddressList' property of 'IPHostEntry' class.
'   It takes a URL from commandline(or uses default value) and obtains a
'   'IPHostEntry' object by calling 'GetHostByName' method of 'Dns' class and
'   prints the host name and IP addresses associated with the specified URL.      
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic


Class HostInfoSample
    
    Public Shared Sub Main()
        Dim hostString As [String] = " "
        'Creates an instance of HostInfoSample class
        Dim hostInfoSampleObj As New HostInfoSample()
        Console.Write("Type a URL(or press Enter for default, default is 'www.microsoft.net') : ")
        hostString = Console.ReadLine()
        If hostString.Length > 0 Then
            hostInfoSampleObj.GetIpAddressList(hostString)
        Else
            hostInfoSampleObj.GetIpAddressList("www.microsoft.net")
        End If
    End Sub 'Main
' <Snippet1>	     
    Public Sub GetIpAddressList(hostString As [String])
        Try
            ' Get 'IPHostEntry' object which contains information like host name, IP addresses, aliases
	    ' for specified url
            Dim hostInfo As IPHostEntry = Dns.GetHostByName(hostString)
            Console.WriteLine(("Host name : " + hostInfo.HostName))
            Console.WriteLine("IP address List : ")
            Dim index As Integer
            For index = 0 To hostInfo.AddressList.Length - 1
                Console.WriteLine(hostInfo.AddressList(index))
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
    End Sub 'GetIpAddressList
' </Snippet1>	
End Class 'HostInfoSample 
