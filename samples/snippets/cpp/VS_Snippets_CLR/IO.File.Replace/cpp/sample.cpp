//<SNIPPET1>
using namespace System;
using namespace System::IO;


// Move a file into another file, delete the original,
// and create a backup of the replaced file.

void ReplaceFile(String^ fileToMoveAndDelete,
                 String^ fileToReplace, String^ backupOfFileToReplace)
{
    File::Replace(fileToMoveAndDelete, fileToReplace,
        backupOfFileToReplace, false);
}	


int main()
{
    try
    {
        String^ originalFile = "test.xml";
        String^ fileToReplace = "test2.xml";
        String^ backUpOfFileToReplace = "test2.xml.bac";

        Console::WriteLine("Move the contents of " + originalFile + " into " 
            + fileToReplace + ", delete " + originalFile
            + ", and create a backup of " + fileToReplace + ".");

        // Replace the file.
        ReplaceFile(originalFile, fileToReplace, backUpOfFileToReplace);

        Console::WriteLine("Done");
    }
    catch (IOException^ ex)
    {
        Console::WriteLine(ex->Message);
    } 
};
//</SNIPPET1>
