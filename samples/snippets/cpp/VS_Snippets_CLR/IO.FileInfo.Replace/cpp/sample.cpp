//<SNIPPET1>

using namespace System;
using namespace System::IO;


// Move a file into another file, delete the original,
// and create a backup of the replaced file.
void ReplaceFile(String^ fileToMoveAndDelete,
                 String^ fileToReplace, String^ backupOfFileToReplace)
{
    // Create a new FileInfo object.
    FileInfo^ fInfo = gcnew FileInfo(fileToMoveAndDelete);

    // replace the file.
    fInfo->Replace(fileToReplace, backupOfFileToReplace, false);
}


int main()
{
    try
    {
        // originalFile and fileToReplace must contain 
        // the path to files that already exist in the  
        // file system. backUpOfFileToReplace is created 
        // during the execution of the Replace method.

        String^ originalFile = "test.xml";
        String^ fileToReplace = "test2.xml";
        String^ backUpOfFileToReplace = "test2.xml.bak";

        if (File::Exists(originalFile) && (File::Exists(fileToReplace)))
        {
            Console::WriteLine("Move the contents of {0} into {1}, " +
                "delete {0}, and create a backup of {1}",
                originalFile, fileToReplace);

            // Replace the file.
            ReplaceFile(originalFile, fileToReplace,
                backUpOfFileToReplace);
			Console::WriteLine("Done");
        }
        else
        {
            Console::WriteLine("Either the file {0} or {1} doesn't " +
                "exist.", originalFile, fileToReplace);
        }
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}


//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Move the contents of c:\test1.xml into c:\test2.xml, delete c:\test1.xml, 
//and create a backup of c:\test2.xml
//Done

//</SNIPPET1>