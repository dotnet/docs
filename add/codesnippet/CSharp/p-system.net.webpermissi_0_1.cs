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
