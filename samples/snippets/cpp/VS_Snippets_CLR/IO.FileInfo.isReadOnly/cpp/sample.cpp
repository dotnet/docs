//<SNIPPET1>
using namespace System;
using namespace System::IO;

namespace FileSystemExample
{
    // Sets the read-only value of a file.
    void SetFileReadAccess(String^ fileName, bool setReadOnly)
    {
        // Create a new FileInfo object.
        FileInfo^ fInfo = gcnew FileInfo(fileName);

        // Set the IsReadOnly property.
        fInfo->IsReadOnly = setReadOnly;
    }

    // Returns whether a file is read-only.
    bool IsFileReadOnly(String^ fileName)
    {
        // Create a new FileInfo object.
        FileInfo^ fInfo = gcnew FileInfo(fileName);

        // Return the IsReadOnly property value.
        return fInfo->IsReadOnly;
    }
}

int main()
{
    try
    {
		String^ fileName = "c:\\test.xml";

        if (File::Exists(fileName))
        {
            // Get the read-only value for a file.
            bool isReadOnly = FileSystemExample::IsFileReadOnly(fileName);

            // Display whether the file is read-only.
            Console::WriteLine("The file read-only value for {0} is:" +
                "{1}", fileName, isReadOnly);

            Console::WriteLine("Changing the read-only value for {0}" +
                " to true.", fileName);

            // Set the file to read-only.
            FileSystemExample::SetFileReadAccess(fileName, true);

            // Get the read-only value for a file.
            isReadOnly = FileSystemExample::IsFileReadOnly(fileName);

            // Display that the file is read-only.
            Console::WriteLine("The file read-only value for {0} is:" +
                "{1}", fileName, isReadOnly);
        }
        else
        {
            Console::WriteLine("The file {0} doesn't exist.", fileName);
        }
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
};
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The file read-only value for c:\test.xml is:False
//Changing the read-only value for c:\test.xml to true.
//The file read-only value for c:\test.xml is:True
//</SNIPPET1>