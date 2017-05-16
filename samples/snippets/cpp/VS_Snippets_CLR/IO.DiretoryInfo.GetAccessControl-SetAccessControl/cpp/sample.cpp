//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::AccessControl;

// Adds an ACL entry on the specified directory for the
// specified account.
void AddDirectorySecurity(String^ directoryName, String^ account, 
     FileSystemRights rights, AccessControlType controlType)
{
    // Create a new DirectoryInfo object.
    DirectoryInfo^ dInfo = gcnew DirectoryInfo(directoryName);

    // Get a DirectorySecurity object that represents the
    // current security settings.
    DirectorySecurity^ dSecurity = dInfo->GetAccessControl();

    // Add the FileSystemAccessRule to the security settings.
    dSecurity->AddAccessRule( gcnew FileSystemAccessRule(account,
        rights, controlType));

    // Set the new access settings.
    dInfo->SetAccessControl(dSecurity);
}

// Removes an ACL entry on the specified directory for the
// specified account.
void RemoveDirectorySecurity(String^ directoryName, String^ account,
     FileSystemRights rights, AccessControlType controlType)
{
    // Create a new DirectoryInfo object.
    DirectoryInfo^ dInfo = gcnew DirectoryInfo(directoryName);

    // Get a DirectorySecurity object that represents the
    // current security settings.
    DirectorySecurity^ dSecurity = dInfo->GetAccessControl();

    // Add the FileSystemAccessRule to the security settings.
    dSecurity->RemoveAccessRule(gcnew FileSystemAccessRule(account,
        rights, controlType));

    // Set the new access settings.
    dInfo->SetAccessControl(dSecurity);
}    

int main()
{
    String^ directoryName = "TestDirectory";
    String^ accountName = "MYDOMAIN\\MyAccount";
    if (!Directory::Exists(directoryName))
    {
        Console::WriteLine("The directory {0} could not be found.", 
            directoryName);
        return 0;
    }
    try
    {
        Console::WriteLine("Adding access control entry for {0}",
            directoryName);

        // Add the access control entry to the directory.
        AddDirectorySecurity(directoryName, accountName,
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Removing access control entry from {0}",
            directoryName);

        // Remove the access control entry from the directory.
        RemoveDirectorySecurity(directoryName, accountName, 
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Done.");
    }
    catch (UnauthorizedAccessException^)
    {
        Console::WriteLine("You are not authorised to carry" +
            " out this procedure.");
    }
    catch (System::Security::Principal::
        IdentityNotMappedException^)
    {
        Console::WriteLine("The account {0} could not be found.", accountName);
    }
}

//</SNIPPET1>
