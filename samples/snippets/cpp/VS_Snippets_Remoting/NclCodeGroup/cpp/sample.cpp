#using <System.dll>

using namespace System;
using namespace System::Security::Policy;

static void DisplayConnectionAccessRules(NetCodeGroup^ group);
// <snippet1>


static CodeConnectAccess^ CreateFtpAndDefaultPortAccess()
{
    return gcnew CodeConnectAccess(Uri::UriSchemeFtp, 
        CodeConnectAccess::DefaultPort);
}
// </snippet1>
// <snippet2>


static CodeConnectAccess^ CreateHttpAndOriginPortAccess()
{
    return gcnew CodeConnectAccess(Uri::UriSchemeHttp, 
        CodeConnectAccess::OriginPort);
}
// </snippet2>
// <snippet5>

static CodeConnectAccess^ CreateAnySchemeOriginPortAccess()
{
    return CodeConnectAccess::CreateAnySchemeAccess
        (CodeConnectAccess::OriginPort);
}
// </snippet5>
// <snippet3>

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
    // <snippet7>

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
    // </snippet7>
    // Provide name and description information for caspol.exe tool.
    codeGroup->Name = "ContosoHttpCodeGroup";
    codeGroup->Description = "Code originating from contoso.com can" +
        " connect back using the FTP or HTTPS.";
    // Add the code group to the User policy's root node.
    level->RootCodeGroup->AddChild(codeGroup);
    // Save the changes to the policy level.
    System::Security::SecurityManager::SavePolicy();
}
// </snippet3>
// <snippet4>

static void DisplayProperties (CodeConnectAccess^ access)
{
    Console::WriteLine("Scheme:{0} Port: {1}", 
        access->Scheme, access->Port);
}
// </snippet4>
// <snippet6>

static void DisplayFields ()
{
    Console::WriteLine("Origin scheme value:{0} AnyScheme value: {1}", 
        CodeConnectAccess::OriginScheme, CodeConnectAccess::AnyScheme);
}
// </snippet6>


static void CreateNetCodeGroup()
{
    IMembershipCondition^ membership =
        gcnew UrlMembershipCondition("http://www.contoso.com/*");
    NetCodeGroup^ codeGroup = gcnew NetCodeGroup(membership);

    // Display default settings.
    DisplayConnectionAccessRules(codeGroup);
    // Delete default settings.
    codeGroup->ResetConnectAccess();
    // Create an object that represents access to the ftp scheme and
    // default port.
    CodeConnectAccess^ CodeAccessFtp = 
        gcnew CodeConnectAccess(Uri::UriSchemeFtp, 
        CodeConnectAccess::DefaultPort);
    // Create an object that represents access to the HTTPS scheme
    // and default port.
    CodeConnectAccess^ CodeAccessHttps = 
        gcnew CodeConnectAccess(Uri::UriSchemeHttps, 
        CodeConnectAccess::DefaultPort);
    // Create an object that represents access to the origin scheme
    // and port.
    CodeConnectAccess^ CodeAccessOrigin =
        CodeConnectAccess::CreateOriginSchemeAccess
        (CodeConnectAccess::OriginPort);

    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessFtp);
    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessHttps);
    codeGroup->AddConnectAccess(Uri::UriSchemeHttp, CodeAccessOrigin);
    Console::WriteLine("New NetCodeGroup settings:");
    DisplayConnectionAccessRules(codeGroup);
}
// <snippet8>

static void DisplayConnectionAccessRules(NetCodeGroup^ group)
{
    array<System::Collections::DictionaryEntry>^ rules = 
        group->GetConnectAccessRules();
    for each (System::Collections::DictionaryEntry^ o in rules)
    {
        String^ key = (String^)(o->Key);
        array<CodeConnectAccess^>^ values = (array<CodeConnectAccess^>^)(o->Value);
        Console::WriteLine("Origin scheme: {0}", key);
        for each (CodeConnectAccess^ c in values)
        {
            Console::WriteLine("Scheme {0} Port: {1}", c->Scheme, c->Port);
        }
        Console::WriteLine("__________________________");
    }
}
// </snippet8>

int main()
{
    DisplayProperties(CreateFtpAndDefaultPortAccess());
    DisplayFields();
    DisplayProperties(CreateHttpAndOriginPortAccess());
    DisplayProperties(CreateAnySchemeOriginPortAccess());
    SetNetCodeGroupAccess();
    CreateNetCodeGroup();
}
