//Types:System.Security.Permissions.IsolatedStorageContainment (enum)  Vendor: Richter
//Types:System.Security.Permissions.IsolatedStoragePermissionAttribute  Vendor: Richter
//Types:System.Security.Permissions.SecurityAction  Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO::IsolatedStorage;
using namespace System::IO;


static void WriteIsolatedStorage()
{
    try
    {
        // Attempt to create a storage file that is isolated by
        // user and assembly. IsolatedStorageFilePermission
        // granted to the attribute at the top of this file
        // allows CLR to load this assembly and execution of this
        // statement.
        Stream^ fileCreateStream = gcnew
            IsolatedStorageFileStream(
            "AssemblyData",
            FileMode::Create,
            IsolatedStorageFile::GetUserStoreForAssembly());

        StreamWriter^ streamWriter = gcnew StreamWriter(
            fileCreateStream);
        try
        {
            // Write some data out to the isolated file.

            streamWriter->Write("This is some test data.");
            streamWriter->Close();	
        }
        finally
        {
            delete fileCreateStream;
            delete streamWriter;
        } 
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }

    try
    {
        Stream^ fileOpenStream =
            gcnew IsolatedStorageFileStream(
            "AssemblyData",
            FileMode::Open,
            IsolatedStorageFile::GetUserStoreForAssembly());
        // Attempt to open the file that was previously created.

        StreamReader^ streamReader = gcnew StreamReader(
            fileOpenStream);
        try
        { 
            // Read the data from the file and display it.

            Console::WriteLine(streamReader->ReadLine());
            streamReader->Close();
        }
        finally
        {
            delete fileOpenStream;
            delete streamReader;
        }
    }
    catch (FileNotFoundException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}
// Notify the CLR to only grant IsolatedStorageFilePermission to called methods. 
// This restricts the called methods to working only with storage files that are isolated 
// by user and assembly.
[IsolatedStorageFilePermission(SecurityAction::PermitOnly, UsageAllowed = IsolatedStorageContainment::AssemblyIsolationByUser)]
int main()
{
	WriteIsolatedStorage();
}

// This code produces the following output.
//
//  This is some test data.
//</snippet1>
