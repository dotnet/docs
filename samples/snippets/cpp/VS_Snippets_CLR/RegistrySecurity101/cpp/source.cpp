//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace Microsoft::Win32;
using namespace System::Security::AccessControl;
using namespace System::Security;

int main()
{
    // Delete the example key if it exists.
    try
    {
        Registry::CurrentUser->DeleteSubKey("RegistryRightsExample");
        Console::WriteLine("Example key has been deleted.");
    }
    catch (ArgumentException^)
    {
        // ArgumentException is thrown if the key does not exist. In
        // this case, there is no reason to display a message.
    }
    catch (InvalidOperationException^ ex)
    {
        Console::WriteLine(
            "{0}Unable to delete key: it appears to have child subkeys:{0}{1}", 
            Environment::NewLine, ex);
        return 0;
    }
    catch (SecurityException^ ex)
    {
        Console::WriteLine("{0}You do not have the permissions required " +
            "to delete this key:{0}{1}", Environment::NewLine, ex);
        return 0;
    }

    String^ user = Environment::UserDomainName + "\\" + Environment::UserName;

    RegistrySecurity^ regSecurity = gcnew RegistrySecurity();

    // Allow the current user to read and delete the key.
    //
    regSecurity->AddAccessRule(gcnew RegistryAccessRule(user,
        RegistryRights::ReadKey | RegistryRights::Delete,
        InheritanceFlags::None,
        PropagationFlags::None,
        AccessControlType::Allow));

    // Prevent the current user from writing or changing the
    // permission set of the key. Note that if Delete permission
    // were not allowed in the previous access rule, denying
    // WriteKey permission would prevent the user from deleting the
    // key.
    regSecurity->AddAccessRule(gcnew RegistryAccessRule(user,
        RegistryRights::WriteKey | RegistryRights::ChangePermissions,
        InheritanceFlags::None,
        PropagationFlags::None,
        AccessControlType::Deny));

    // Create the example key with registry security.
    RegistryKey^ createdKey = nullptr;
    try
    {
        createdKey = Registry::CurrentUser->CreateSubKey(
            "RegistryRightsExample", RegistryKeyPermissionCheck::Default,
            regSecurity);
        Console::WriteLine("{0}Example key created.", Environment::NewLine);
        createdKey->SetValue("ValueName", "StringValue");
    }
    catch (SecurityException^ ex)
    {
        Console::WriteLine("{0}You do not have the permissions required " +
            "to create the example key:{0}{1}", Environment::NewLine, ex);
        return 0;
    }
    if (createdKey != nullptr)
    {
        createdKey->Close();
    }

    RegistryKey^ openedKey;

    // Open the key with read access.
    openedKey = Registry::CurrentUser->OpenSubKey("RegistryRightsExample",
        false);
    Console::WriteLine("{0}Retrieved value: {1}",
        Environment::NewLine, openedKey->GetValue("ValueName"));
    openedKey->Close();

    // Attempt to open the key with write access.
    try
    {
        openedKey = Registry::CurrentUser->OpenSubKey("RegistryRightsExample",
            true);
    }
    catch (SecurityException^ ex)
    {
        Console::WriteLine("{0}You do not have the permissions required " +
            "to write to the example key:{0}{1}", Environment::NewLine, ex);
    }
    if (openedKey != nullptr)
    {
        openedKey->Close();
    }

    // Attempt to change permissions for the key.
    try
    {
        regSecurity = gcnew RegistrySecurity();
        regSecurity->AddAccessRule(gcnew RegistryAccessRule(user,
            RegistryRights::WriteKey,
            InheritanceFlags::None,
            PropagationFlags::None,
            AccessControlType::Allow));
        openedKey = Registry::CurrentUser->OpenSubKey("RegistryRightsExample",
            false);
        openedKey->SetAccessControl(regSecurity);
        Console::WriteLine("{0}Example key permissions were changed.", 
            Environment::NewLine);
    }
    catch (UnauthorizedAccessException^ ex)
    {
        Console::WriteLine("{0}You are not authorized to change " +
            "permissions for the example key:{0}{1}", Environment::NewLine, ex);
    }
    if (openedKey != nullptr)
    {
        openedKey->Close();
    }

    Console::WriteLine("{0}Press Enter to delete the example key.", 
        Environment::NewLine);
    Console::ReadLine();

    try
    {
        Registry::CurrentUser->DeleteSubKey("RegistryRightsExample");
        Console::WriteLine("Example key was deleted.");
    }
    catch(SecurityException^ ex)
    {
        Console::WriteLine("{0}You do not have the permissions required to "
            + "delete the example key:{0}{1}", Environment::NewLine, ex);
    }
}
//</Snippet1>

