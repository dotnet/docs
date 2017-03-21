
     // Creates a SocketPermission restricting access to and from all URIs.
     SocketPermission mySocketPermission1 = new SocketPermission(PermissionState.None);

     // The socket to which this permission will apply will allow connections from www.contoso.com.
     mySocketPermission1.AddPermission(NetworkAccess.Accept, TransportType.Tcp, "www.contoso.com", 11000);

     // Creates a SocketPermission which will allow the target Socket to connect with www.southridgevideo.com.
     SocketPermission mySocketPermission2 =
                                new SocketPermission(NetworkAccess.Connect, TransportType.Tcp, "www.southridgevideo.com", 11002);

     // Creates a SocketPermission from the union of two SocketPermissions.
     SocketPermission mySocketPermissionUnion = 
                                (SocketPermission)mySocketPermission1.Union(mySocketPermission2);

     // Checks to see if the union was successfully created by using the IsSubsetOf method.
     if (mySocketPermission1.IsSubsetOf(mySocketPermissionUnion) && 
     	   mySocketPermission2.IsSubsetOf(mySocketPermissionUnion)){
          Console.WriteLine("This union contains permissions from both mySocketPermission1 and mySocketPermission2"); 

          // Prints the allowable accept URIs to the console.
          Console.WriteLine("This union accepts connections on :");

          IEnumerator myEnumerator = mySocketPermissionUnion.AcceptList;
	   while (myEnumerator.MoveNext()) {
               Console.WriteLine(((EndpointPermission)myEnumerator.Current).ToString());
	        }      

             // Prints the allowable connect URIs to the console.
          Console.WriteLine("This union permits connections to :");

          myEnumerator = mySocketPermissionUnion.ConnectList;
	   while (myEnumerator.MoveNext()) {
               Console.WriteLine(((EndpointPermission)myEnumerator.Current).ToString());
	        }      

           }
