using System;
using System.Security.Policy;

public class TestNetCodeGroups
{
// <snippet1>
    public static CodeConnectAccess CreateFtpAndDefaultPortAccess()
    {
        return new CodeConnectAccess(Uri.UriSchemeFtp, CodeConnectAccess.DefaultPort);
    }
// </snippet1>
// <snippet2>

        public static CodeConnectAccess CreateHttpAndOriginPortAccess()
    {
        return new CodeConnectAccess(Uri.UriSchemeHttp, CodeConnectAccess.OriginPort);
    }
// </snippet2>
// <snippet5>
    public static CodeConnectAccess CreateAnySchemeOriginPortAccess()
{
    return CodeConnectAccess.CreateAnySchemeAccess(CodeConnectAccess.OriginPort);
}
// </snippet5>
// <snippet3>
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
        // <snippet7>

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
        // </snippet7>
        // Provide name and description information for caspol.exe tool.
        codeGroup.Name = "ContosoHttpCodeGroup";
        codeGroup.Description = "Code originating from contoso.com can connect back using the FTP or HTTPS.";
        // Add the code group to the User policy's root node.
        level.RootCodeGroup.AddChild(codeGroup);
        // Save the changes to the policy level.
        System.Security.SecurityManager.SavePolicy();
    }
// </snippet3>
// <snippet4>
    public static void DisplayProperties (CodeConnectAccess access)
    {
        Console.WriteLine("Scheme:{0} Port: {1}", access.Scheme, access.Port);
    }
// </snippet4>
// <snippet6>
    public static void DisplayFields ()
    {
        Console.WriteLine("Origin scheme value:{0} AnyScheme value: {1}", 
            CodeConnectAccess.OriginScheme, CodeConnectAccess.AnyScheme);
    }
// </snippet6>

    public static void CreateNetCodeGroup()
    {
        IMembershipCondition membership =
            new UrlMembershipCondition(@"http://www.contoso.com/*");
        NetCodeGroup codeGroup = new NetCodeGroup(membership);

        // Display default settings.
        DisplayConnectionAccessRules(codeGroup);
        // Delete default settings.
        codeGroup.ResetConnectAccess();
        // Create an object that represents access to the ftp scheme and default port.
        CodeConnectAccess a1 = new CodeConnectAccess(Uri.UriSchemeFtp, CodeConnectAccess.DefaultPort);
        // Create an object that represents access to the HTTPS scheme and default port.
        CodeConnectAccess a2 = new CodeConnectAccess(Uri.UriSchemeHttps, CodeConnectAccess.DefaultPort);
        // Create an object that represents access to the origin scheme and port.
        CodeConnectAccess a3 = CodeConnectAccess.CreateOriginSchemeAccess(CodeConnectAccess.OriginPort);
        
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a1);
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a2);
        codeGroup.AddConnectAccess(Uri.UriSchemeHttp, a3);
        Console.WriteLine("New NetCodeGroup settings:");
        DisplayConnectionAccessRules(codeGroup);
    }
    // <snippet8>
    public static void DisplayConnectionAccessRules(NetCodeGroup group)
    {
        System.Collections.DictionaryEntry[] rules = group.GetConnectAccessRules();
        foreach (System.Collections.DictionaryEntry o in rules)
        {
            string key = o.Key as string;
            CodeConnectAccess[] values = (CodeConnectAccess[]) o.Value;
            Console.WriteLine("Origin scheme: {0}", key);
            foreach (CodeConnectAccess c in values)
            {
                Console.WriteLine("Scheme {0} Port: {1}", c.Scheme, c.Port);
            }
            Console.WriteLine("__________________________");
        }
    }
    // </snippet8>
    public static void Main()
    {
        
        DisplayProperties(CreateFtpAndDefaultPortAccess());
        DisplayFields();
        DisplayProperties(CreateHttpAndOriginPortAccess());
       DisplayProperties(CreateAnySchemeOriginPortAccess());
       SetNetCodeGroupAccess();
       CreateNetCodeGroup();
    }
}
