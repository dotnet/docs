    public static void SetNetCodeGroupAccess()
    {
        const string userPolicyLevel = "User";
        // Locate the User policy level.
        PolicyLevel level = null;
        System.Collections.IEnumerator ph = 
            System.Security.SecurityManager.PolicyHierarchy();
        while(ph.MoveNext())
        {
            level = (PolicyLevel)ph.Current;
            if( level.Label == userPolicyLevel )
            {
                break;
            }
        }
        if (level.Label != userPolicyLevel)
            throw new ApplicationException("Could not find User policy level.");

        IMembershipCondition membership =
            new UrlMembershipCondition(@"http://www.contoso.com/*");
        NetCodeGroup codeGroup = new NetCodeGroup(membership);
        // Delete default settings.
        codeGroup.ResetConnectAccess();
        // Create an object that represents access to the FTP scheme and default port.
        CodeConnectAccess a1 = new CodeConnectAccess(Uri.UriSchemeFtp, CodeConnectAccess.DefaultPort);
        // Create an object that represents access to the HTTPS scheme and default port.
        CodeConnectAccess a2 = new CodeConnectAccess(Uri.UriSchemeHttps, CodeConnectAccess.DefaultPort);
        // Create an object that represents access to the origin scheme and port.
        CodeConnectAccess a3 = CodeConnectAccess.CreateOriginSchemeAccess(CodeConnectAccess.OriginPort);
        // Add connection access objects to the NetCodeGroup object.
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a1);
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a2);
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a3);
        // Provide name and description information for caspol.exe tool.
        codeGroup.Name = "ContosoHttpCodeGroup";
        codeGroup.Description = "Code originating from contoso.com can connect back using the FTP or HTTPS.";
        // Add the code group to the User policy's root node.
        level.RootCodeGroup.AddChild(codeGroup);
        // Save the changes to the policy level.
        System.Security.SecurityManager.SavePolicy();
    }