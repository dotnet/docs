//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::AccessControl;


	static void Addencryption(String^ fileName)
{
    // Create a new FileInfo object.
	FileInfo^ fInfo = gcnew FileInfo(fileName);
	if (!fInfo->Exists)
	{
		fInfo->Create();
	}
	// Add encryption.
    fInfo->Encrypt();
	
}


	static void Removeencryption(String^ fileName)
{
//    Create a new FileInfo object.
    FileInfo^ fInfo = gcnew FileInfo(fileName);
	if (!fInfo->Exists)
	{
		fInfo->Create();
	}
    // Remove encryption.
    fInfo->Decrypt();
}

int main()
{
	try
    {
		String^ fileName = "c:\\MyTest.txt";
        Console::WriteLine("Encrypt " + fileName);

        // Encrypt the file.
     
		Addencryption(fileName);
		Console::WriteLine("Decrypt " + fileName);

        // Decrypt the file.
        Removeencryption(fileName);
		Console::WriteLine("Done");
     }
     catch (IOException^ ex)
     {
		Console::WriteLine(ex->Message);
     }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Encrypt c:\MyTest.txt
//Decrypt c:\MyTest.txt
//Done
//</SNIPPET1>
