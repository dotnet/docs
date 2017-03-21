
    // Create the target permission.
    WebPermission targetPermission = new WebPermission();
    targetPermission.AddPermission(NetworkAccess.Connect, new Regex("www\\.contoso\\.com/Public/.*"));

    // Create the permission for a URI matching target.
    WebPermission connectPermission = new WebPermission();
    connectPermission.AddPermission(NetworkAccess.Connect, "www.contoso.com/Public/default.htm");

    //The following statement prints true.
    Console.WriteLine("Is the second URI a subset of the first one?: " + connectPermission.IsSubsetOf(targetPermission));
