
static void SetNetCodeGroupAccess()
{
    String^ userPolicyLevel = "User";
    // Locate the User policy level.
    PolicyLevel^ level = nullptr;
    System::Collections::IEnumerator^ ph = 
        System::Security::SecurityManager::PolicyHierarchy();
    while(ph->MoveNext())
    {
        level = (PolicyLevel^)ph->Current;
        if (level->Label == userPolicyLevel)
        {
            break;       
        }
    }
    if (level->Label != userPolicyLevel)
        throw gcnew ApplicationException("Could not find User policy level.");

    IMembershipCondition^ membership =
        gcnew UrlMembershipCondition("http://www.contoso.com/*");
    NetCodeGroup^ codeGroup = gcnew NetCodeGroup(membership);
    // Delete default settings.
    codeGroup->ResetConnectAccess();
    // Create an object that represents access to the FTP scheme and 
    // default port.
    CodeConnectAccess^ CodeAccessFtp = 
        gcnew CodeConnectAccess(Uri::UriSchemeFtp, 
        CodeConnectAccess::DefaultPort);
    // Create an object that represents access to the HTTPS scheme 
    // and default port.
    CodeConnectAccess^ CodeAccessHttps = 
        gcnew CodeConnectAccess(Uri::UriSchemeHttps, 
        CodeConnectAccess::DefaultPort);
    // Create an object that represents access to the origin 
    // scheme and port.
    CodeConnectAccess^ CodeAccessOrigin = 
        CodeConnectAccess::CreateOriginSchemeAccess
        (CodeConnectAccess::OriginPort);
    // Add connection access objects to the NetCodeGroup object.
    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessFtp);
    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessHttps);
    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessOrigin);
    // Provide name and description information for caspol.exe tool.
    codeGroup->Name = "ContosoHttpCodeGroup";
    codeGroup->Description = "Code originating from contoso.com can" +
        " connect back using the FTP or HTTPS.";
    // Add the code group to the User policy's root node.
    level->RootCodeGroup->AddChild(codeGroup);
    // Save the changes to the policy level.
    System::Security::SecurityManager::SavePolicy();
}