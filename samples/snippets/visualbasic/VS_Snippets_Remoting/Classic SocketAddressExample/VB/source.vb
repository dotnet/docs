Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class MySerializeExample

   Public Shared Sub MySerializeIPEndPointClassMethod()
      
      '<Snippet1>
      'Creates an IpEndPoint.
      Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
      Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 11000)
      
      'Serializes the IPEndPoint. 
      Dim socketAddress As SocketAddress = ipLocalEndPoint.Serialize()
      
      'Verifies that ipLocalEndPoint is now serialized by printing its contents.
      Console.WriteLine(("Contents of socketAddress are: " + socketAddress.ToString()))
      'Checks the Family property.
      Console.WriteLine(("The address family of socketAddress is: " + socketAddress.Family.ToString()))
      'Checks the underlying buffer size.
      Console.WriteLine(("The size of the underlying buffer is: " + socketAddress.Size.ToString()))
   End Sub 'MySerializeIPEndPointClassMethod
    
   '</Snippet1>
   Public Shared Sub Main()
      
      ' For our example, we will use the default constructor.
      MySerializeIPEndPointClassMethod()
      
   End Sub 'Main 
End Class 





