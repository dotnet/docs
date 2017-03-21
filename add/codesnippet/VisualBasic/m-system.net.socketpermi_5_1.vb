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