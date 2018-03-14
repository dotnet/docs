
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Security.Permissions
Imports System.Collections

Public Class MySocketPermissionExample
   
   
   Public Shared Sub MySocketPermission()
      '<Snippet1>
      '<Snippet2>
      ' Creates a SocketPermission restricting access to and from all URIs.
      Dim mySocketPermission1 As New SocketPermission(PermissionState.None)
      
      ' The socket to which this permission will apply will allow connections from www.contoso.com.
      mySocketPermission1.AddPermission(NetworkAccess.Accept, TransportType.Tcp, "www.contoso.com", 11000)
      
      ' Creates a SocketPermission which will allow the target Socket to connect with www.southridgevideo.com.
      Dim mySocketPermission2 As New SocketPermission(NetworkAccess.Connect, TransportType.Tcp, "www.southridgevideo.com", 11002)
      
      ' Creates a SocketPermission from the union of two SocketPermissions.
      Dim mySocketPermissionUnion As SocketPermission = CType(mySocketPermission1.Union(mySocketPermission2), SocketPermission)
      
      ' Checks to see if the union was successfully created by using the IsSubsetOf method.
      If mySocketPermission1.IsSubsetOf(mySocketPermissionUnion) And mySocketPermission2.IsSubsetOf(mySocketPermissionUnion) Then
         Console.WriteLine("This union contains permissions from both mySocketPermission1 and mySocketPermission2")
         
         ' Prints the allowable accept URIs to the console.
         Console.WriteLine("This union accepts connections on :")
         
         Dim myEnumerator As IEnumerator = mySocketPermissionUnion.AcceptList
         While myEnumerator.MoveNext()
            Console.WriteLine(CType(myEnumerator.Current, EndpointPermission).ToString())
         End While
         
         Console.WriteLine("This union establishes connections on : ")
         
         ' Prints the allowable connect URIs to the console.
         Console.WriteLine("This union permits connections to :")
         
         myEnumerator = mySocketPermissionUnion.ConnectList
         While myEnumerator.MoveNext()
            Console.WriteLine(CType(myEnumerator.Current, EndpointPermission).ToString())
         End While
      End If 
      '</Snippet2>
      '<Snippet3>
      ' Creates a SocketPermission from the intersect of two SocketPermissions.
      Dim mySocketPermissionIntersect As SocketPermission = CType(mySocketPermission1.Intersect(mySocketPermissionUnion), SocketPermission)
      
      ' mySocketPermissionIntersect should now contain the permissions of mySocketPermission1.
      If mySocketPermission1.IsSubsetOf(mySocketPermissionIntersect) Then
         Console.WriteLine("This is expected")
      End If
      ' mySocketPermissionIntersect should not contain the permissios of mySocketPermission2.
      If mySocketPermission2.IsSubsetOf(mySocketPermissionIntersect) Then
         Console.WriteLine("This should not print")
      End If
      
      '</Snippet3>
      '<Snippet4>
      ' Creates a copy of the intersect SocketPermission.
      Dim mySocketPermissionIntersectCopy As SocketPermission = CType(mySocketPermissionIntersect.Copy(), SocketPermission)
      
      If mySocketPermissionIntersectCopy.Equals(mySocketPermissionIntersect) Then
         Console.WriteLine("Copy successfull")
      End If
      '</Snippet4>
      ' Converts a SocketPermission to XML format and then immediately converts it back to a SocketPermission.
      mySocketPermission1.FromXml(mySocketPermission1.ToXml())
      
      
      ' Checks to see if permission for this socket resource is unrestricted.  If it is, then there is no need to
      ' demand that permissions be enforced.
      If mySocketPermissionUnion.IsUnrestricted() Then
      
      'Do nothing.  There are no restrictions.
      Else
         ' Enforces the permissions found in mySocketPermissionUnion on any Socket Resources used below this statement. 
         mySocketPermissionUnion.Demand()
      End If
      
      Dim myIpHostEntry As IPHostEntry = Dns.Resolve("www.contoso.com")
      Dim myLocalEndPoint As New IPEndPoint(myIpHostEntry.AddressList(0), 11000)
      
      Dim s As New Socket(myLocalEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         s.Connect(myLocalEndPoint)
      Catch e As Exception
         Console.WriteLine(("Exception Thrown: " + e.ToString()))
      End Try
      
      ' Perform all socket operations in here.
      s.Close()
   End Sub 'MySocketPermission
    '</Snippet1>
   
   Public Shared Sub Main()
      MySocketPermissionExample.MySocketPermission()
   End Sub 'Main 
End Class 'MySocketPermissionExample


