//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::AccessControl;

// Adds an ACL entry on the specified file for the specified account.

void AddFileSecurity(String^ fileName, String^ account, 
                        FileSystemRights rights, AccessControlType controlType)
{
    // Get a FileSecurity object that represents the 
    // current security settings.
    FileSecurity^ fSecurity = File::GetAccessControl(fileName);

    // Add the FileSystemAccessRule to the security settings. 
    fSecurity->AddAccessRule(gcnew FileSystemAccessRule
                                   (account,rights, controlType));

    // Set the new access settings.
    File::SetAccessControl(fileName, fSecurity);
}

// Removes an ACL entry on the specified file for the specified account.

void RemoveFileSecurity(String^ fileName, String^ account, 
                        FileSystemRights rights, AccessControlType controlType)
{

    // Get a FileSecurity object that represents the 
    // current security settings.
    FileSecurity^ fSecurity = File::GetAccessControl(fileName);

    // Remove the FileSystemAccessRule from the security settings. 
    fSecurity->RemoveAccessRule(gcnew FileSystemAccessRule
                                      (account,rights, controlType));

    // Set the new access settings.
    File::SetAccessControl(fileName, fSecurity);
}

int main()
{
    try
    {
        String^ fileName = "test.xml";

        Console::WriteLine("Adding access control entry for " + fileName);

        // Add the access control entry to the file.
        AddFileSecurity(fileName, "MYDOMAIN\\MyAccount", 
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Removing access control entry from " + fileName);

        // Remove the access control entry from the file.
        RemoveFileSecurity(fileName, "MYDOMAIN\\MyAccount", 
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Done.");
    }
    catch (Exception^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}

//</SNIPPET1>
