
// Set the WebPermissionAttribute  Connect property.
[WebPermission(SecurityAction.Deny, Connect=@"http://www.contoso.com/Private.htm")]

public static void demoDenySite() 
{
    //Pass the security check.
    CheckConnectPermission("http://www.contoso.com/Public.htm");
    Console.WriteLine("Public page has passed connect permission check");

    try 
    {
        //Throw a SecurityException.
        CheckConnectPermission("http://www.contoso.com/Private.htm");
        Console.WriteLine("This line will not be printed");
    }
    catch (SecurityException e) {
        Console.WriteLine("Expected exception" + e.Message);
    }

 }

public static void CheckConnectPermission(string uriToCheck) {
    WebPermission permissionToCheck = new WebPermission();
    permissionToCheck.AddPermission(NetworkAccess.Connect, uriToCheck);
    permissionToCheck.Demand();
}
