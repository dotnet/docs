' <Internal>
' File name: ipaddress.cs
' The snippets contained here apply to:
' 1) System.Net.IPAddress.AddressFamily, snippet3.
' 2) System.Net.IPAddess.ScopeId, snippet3.
' more
' Note this program is compiled using using the vbc command line. Waiting
' for VS update that includes the IPv6 types.
' </Internal>

' <Snippet1>
' This program shows how to use the IPAddress class to obtain a server 
' IP addressess and related information.
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic


Namespace Mssc.Services.ConnectionManagement
  Module M_TestIPAddress

    Class TestIPAddress
      'The IPAddresses method obtains the selected server IP address information.      'It then displays the type of address family supported by the server and       'its IP address in standard and byte format.
      Private Shared Sub IPAddresses(ByVal server As String)
        Try
          Dim ASCII As New System.Text.ASCIIEncoding()

          ' Get server related information.
          Dim heserver As IPHostEntry = Dns.Resolve(server)

          ' Loop on the AddressList
          Dim curAdd As IPAddress
          For Each curAdd In heserver.AddressList

            '<Snippet3>
            ' Display the type of address family supported by the server. If the
            ' server is IPv6-enabled this value is: InternNetworkV6. If the server
            ' is also IPv4-enabled there will be an additional value of InterNetwork.
            Console.WriteLine(("AddressFamily: " + curAdd.AddressFamily.ToString()))

            ' Display the ScopeId property in case of IPV6 addresses.
            If curAdd.AddressFamily.ToString() = ProtocolFamily.InterNetworkV6.ToString() Then
              Console.WriteLine(("Scope Id: " + curAdd.ScopeId.ToString()))
            End If
            '</Snippet3>

            ' Display the server IP address in the standard format. In 
            ' IPv4 the format will be dotted-quad notation, in IPv6 it will be
            ' in in colon-hexadecimal notation.
            Console.WriteLine(("Address: " + curAdd.ToString()))

            ' Display the server IP address in byte format.
            Console.Write("AddressBytes: ")



'<Snippet2>
            Dim bytes As [Byte]() = curAdd.GetAddressBytes()
            Dim i As Integer
            For i = 0 To bytes.Length - 1
              Console.Write(bytes(i))
            Next i
' </Snippet2>
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf)
          Next curAdd 

        Catch e As Exception
          Console.WriteLine(("[DoResolve] Exception: " + e.ToString()))
        End Try
      End Sub 'IPAddresses


      ' This IPAddressAdditionalInfo displays additional server address information.
      Private Shared Sub IPAddressAdditionalInfo()
        Try
          ' Display the flags that show if the server supports IPv4 or IPv6
          ' address schemas.
          Console.WriteLine((ControlChars.Cr + ControlChars.Lf + "SupportsIPv4: " + Socket.SupportsIPv4.ToString()))
          Console.WriteLine(("SupportsIPv6: " + Socket.SupportsIPv6.ToString()))

          If Socket.SupportsIPv6 Then
            ' Display the server Any address. This IP address indicates that the server 
            ' should listen for client activity on all network interfaces. 
            Console.WriteLine((ControlChars.Cr + ControlChars.Lf + "IPv6Any: " + IPAddress.IPv6Any.ToString()))

            ' Display the server loopback address. 
            Console.WriteLine(("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString()))

            ' Used during autoconfiguration first phase.
            Console.WriteLine(("IPv6None: " + IPAddress.IPv6None.ToString()))

            Console.WriteLine(("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback).ToString()))
          End If
          Console.WriteLine(("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback).ToString()))
        Catch e As Exception
          Console.WriteLine(("[IPAddresses] Exception: " + e.ToString()))
        End Try
      End Sub 'IPAddressAdditionalInfo

      Public Shared Sub Main(ByVal args() As String)
        Dim server As String = Nothing

        ' Define a regular expression to parse user's input.
        ' This is a security check. It allows only
        ' alphanumeric input string between 2 to 40 character long.
        'Define a regular expression to parse user's input.
        'This is a security check. It allows only
        'alphanumeric input string between 2 to 40 character long.
        Dim rex As New Regex("^[a-zA-Z]\w{1,39}$")

        If args.Length < 1 Then
          ' If no server name is passed as an argument to this program, use the current 
          ' server name as default.
          server = Dns.GetHostName()
          Console.WriteLine(("Using current host: " + server))
        Else
          server = args(0)
          If Not rex.Match(server).Success Then
            Console.WriteLine("Input string format not allowed.")
            Return
          End If
        End If

        ' Get the list of the addresses associated with the requested server.
        IPAddresses(server)

        ' Get additonal address information.
        IPAddressAdditionalInfo()
      End Sub 'Main
    End Class 'TestIPAddress
  End Module
End Namespace
' </Snippet1>