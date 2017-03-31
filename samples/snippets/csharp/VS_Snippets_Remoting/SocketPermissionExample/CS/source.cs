using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Permissions;
using System.Collections;

public class MySocketPermissionExample{

public static void MySocketPermission(){
//<Snippet1>
//<Snippet2>

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

//</Snippet2>
//<Snippet3>

     // Creates a SocketPermission from the intersect of two SocketPermissions.
     SocketPermission mySocketPermissionIntersect = 
                               (SocketPermission)mySocketPermission1.Intersect(mySocketPermissionUnion);

     // mySocketPermissionIntersect should now contain the permissions of mySocketPermission1.
     if (mySocketPermission1.IsSubsetOf(mySocketPermissionIntersect)){
          Console.WriteLine("This is expected");
     }
    // mySocketPermissionIntersect should not contain the permissios of mySocketPermission2.
     if (mySocketPermission2.IsSubsetOf(mySocketPermissionIntersect)){
          Console.WriteLine("This should not print");
     }


//</Snippet3>

//<Snippet4>
// Creates a copy of the intersect SocketPermission.
     SocketPermission mySocketPermissionIntersectCopy = 
                               (SocketPermission)mySocketPermissionIntersect.Copy();

     if (mySocketPermissionIntersectCopy.Equals(mySocketPermissionIntersect)){
     Console.WriteLine("Copy successfull");
     }

//</Snippet4>

     // Converts a SocketPermission to XML format and then immediately converts it back to a SocketPermission.
     mySocketPermission1.FromXml(mySocketPermission1.ToXml());
     

     // Checks to see if permission for this socket resource is unrestricted.  If it is, then there is no need to
     // demand that permissions be enforced.
     if (mySocketPermissionUnion.IsUnrestricted()){
     	
          //Do nothing.  There are no restrictions.

     }
     else{
         // Enforces the permissions found in mySocketPermissionUnion on any Socket Resources used below this statement. 
         mySocketPermissionUnion.Demand();
     }

	IPHostEntry myIpHostEntry = Dns.Resolve("www.contoso.com");
	IPEndPoint myLocalEndPoint = new IPEndPoint(myIpHostEntry.AddressList[0], 11000);

       Socket s = new Socket(myLocalEndPoint.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
            s.Connect(myLocalEndPoint);
       }
       catch (Exception e){
            Console.WriteLine("Exception Thrown: " + e.ToString());
       } 

      // Perform all socket operations in here.
      
      s.Close();
//</Snippet1>
}

public static void Main(){
MySocketPermissionExample.MySocketPermission();

}


}

