using System.Security;
using System.Security.Permissions;
using System.Net;
using System;

//<Snippet1>
//Uses the DnsPermissionAttribute to restrict access only to those who have permission.
[DnsPermission(SecurityAction.Demand, Unrestricted = true)]
public class MyClass{

public static IPAddress GetIPAddress(){
     IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
     return ipAddress;
}
public static void Main(){
try{
     //Grants Access.
     Console.WriteLine(" Access granted\n The local host IP Address is :" + 
                                  MyClass.GetIPAddress().ToString());
}
// Denies Access.
catch(SecurityException securityException){
     Console.WriteLine("Access denied");	
     Console.WriteLine(securityException.ToString());
}
//</Snippet1>
}
}
