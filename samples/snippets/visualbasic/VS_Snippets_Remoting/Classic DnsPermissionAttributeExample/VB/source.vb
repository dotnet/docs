
Imports System.Security
Imports System.Security.Permissions
Imports System.Net
Imports System
Imports Microsoft.VisualBasic


'<Snippet1>
' Uses the DnsPermissionAttribute to restrict access only to those who have permission.
<DnsPermission(SecurityAction.Demand, Unrestricted := true)>  _
Public Class MyClass1
   
   Public Shared Function GetIPAddress() As IPAddress
      Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
      Return ipAddress
   End Function 'GetIPAddress
   
   Public Shared Sub Main()
      Try
         ' Grants Access.
         Console.WriteLine(("Access granted" + ControlChars.NewLine + " The local host IP Address is :" + MyClass1.GetIPAddress().ToString()))
      ' Denies Access.
      Catch securityException As SecurityException
         Console.WriteLine("Access denied")
         Console.WriteLine(securityException.ToString())
      End Try
   End Sub 'Main 
End Class '[MyClass1]
'</Snippet1>