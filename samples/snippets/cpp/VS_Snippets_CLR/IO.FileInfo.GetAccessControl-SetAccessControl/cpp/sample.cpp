//<SNIPPET1>
#using <System.Security.dll>
using namespace System;
using namespace System::IO;
using namespace System::Security::AccessControl;
using namespace System::Security::Principal;

// Adds an ACL entry on the specified file for the specified account.
static void AddFileSecurity(String^ fileName, String^ account,
                     FileSystemRights^ rights, 
                     AccessControlType^ controlType)
{
    // Create a new FileInfo object.
    FileInfo^ fInfo = gcnew FileInfo(fileName);
	if (!fInfo->Exists)
	{
		fInfo->Create();
	}

    // Get a FileSecurity object that represents the
    // current security settings.
    FileSecurity^ fSecurity = fInfo->GetAccessControl();

    // Add the FileSystemAccessRule to the security settings.
    fSecurity->AddAccessRule(gcnew FileSystemAccessRule(account,
        *rights, *controlType));

    // Set the new access settings.
    fInfo->SetAccessControl(fSecurity);
}

// Removes an ACL entry on the specified file for the specified account.
static void RemoveFileSecurity(String^ fileName, String^ account,
                        FileSystemRights^ rights, 
                        AccessControlType^ controlType)
{
    // Create a new FileInfo object.
    FileInfo^ fInfo = gcnew FileInfo(fileName);
	if (!fInfo->Exists)
	{
		fInfo->Create();
	}

    // Get a FileSecurity object that represents the
    // current security settings.
    FileSecurity^ fSecurity = fInfo->GetAccessControl();

    // Remove the FileSystemAccessRule from the security settings.
    fSecurity->RemoveAccessRule(gcnew FileSystemAccessRule(account, 
		*rights, *controlType));

    // Set the new access settings.
    fInfo->SetAccessControl(fSecurity);
}

int main()
{
    try
    {
		String^ fileName = "c:\\test.xml";

        Console::WriteLine("Adding access control entry for " +
            fileName);

        // Add the access control entry to the file.
        // Before compiling this snippet, change MyDomain to your 
        // domain name and MyAccessAccount to the name 
        // you use to access your domain.
        AddFileSecurity(fileName, "MyDomain\\MyAccessAccount",
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Removing access control entry from " +
            fileName);

        // Remove the access control entry from the file.
        // Before compiling this snippet, change MyDomain to your 
        // domain name and MyAccessAccount to the name 
        // you use to access your domain.
        RemoveFileSecurity(fileName, "MyDomain\\MyAccessAccount",
            FileSystemRights::ReadData, AccessControlType::Allow);

        Console::WriteLine("Done.");
    }
    catch (Exception^ e)
    {
        Console::WriteLine(e);
    }

}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Adding access control entry for c:\test.xml
//Removing access control entry from c:\test.xml
//Done.
//
//</SNIPPET1>