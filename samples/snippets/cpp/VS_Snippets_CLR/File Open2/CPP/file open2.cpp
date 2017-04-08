// <Snippet1>

using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
    // This sample assumes that you have a folder named "c:\temp" on your computer.
    String^ filePath = "c:\\temp\\MyTest.txt";
    // Delete the file if it exists.
    if (File::Exists( filePath ))
    {
        File::Delete( filePath );
    }
    // Create the file.
    FileStream^ fs = File::Create( filePath );
    try
    {
        array<Byte>^ info = ( gcnew UTF8Encoding( true ))->GetBytes( "This is some text in the file." );
        
        // Add some information to the file.
        fs->Write( info, 0, info->Length );
    }
    finally
    {
        if ( fs )
            delete (IDisposable^)fs;
    }

    // Open the stream and read it back.
    fs = File::Open( filePath, FileMode::Open, FileAccess::Read );
    try
    {
        array<Byte>^ b = gcnew array<Byte>(1024);
        UTF8Encoding^ temp = gcnew UTF8Encoding( true );
        while ( fs->Read( b, 0, b->Length ) > 0 )
        {
            Console::WriteLine( temp->GetString( b ) );
        }
        try
        {
            // Try to write to the file.
            fs->Write( b, 0, b->Length );
        }
        catch ( Exception^ e ) 
        {
            Console::WriteLine( "Writing was disallowed, as expected: {0}", e->ToString() );
        }
    }
    finally
    {
        if ( fs )
            delete (IDisposable^)fs;
    }
}
// </Snippet1>
