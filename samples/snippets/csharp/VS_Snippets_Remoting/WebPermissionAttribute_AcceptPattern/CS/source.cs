// System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;
/*
This program demonstrates the 'Connect' and 'Accept' properties of the class 'WebPermissionAttribute'.
The program uses declarative security for calling the code in 'Connect' method.
By using the 'Accept' and 'Connect' properties of 'WebPermissionAttribute' accept and connect access 
has been given to the uri www.contoso.com.
*/


using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.IO;
using System.Text.RegularExpressions;


public class WebPermissionAttribute_AcceptConnect{
//<Snippet1>    
[WebPermission(SecurityAction.Deny, AcceptPattern=@"http://www\.contoso\.com/Private/.*")]

public static void CheckAcceptPermission(string uriToCheck) {

    WebPermission permissionToCheck = new WebPermission();
    permissionToCheck.AddPermission(NetworkAccess.Accept, uriToCheck);
    permissionToCheck.Demand();
}

public static void demoDenySite() {
    //Passes a security check.
    CheckAcceptPermission("http://www.contoso.com/Public/page.htm");
    Console.WriteLine("Public page has passed Accept permission check");

    try {
        //Throws a SecurityException.
        CheckAcceptPermission("http://www.contoso.com/Private/page.htm");
        Console.WriteLine("This line will not be printed");
}
    catch (SecurityException e) {
        Console.WriteLine("Expected exception: " + e.Message);
    }

 }

//</Snippet1>
        static void Main()
        {
             demoDenySite();
            
        }
    }
