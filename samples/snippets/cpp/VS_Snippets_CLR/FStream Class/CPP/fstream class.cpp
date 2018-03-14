// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

void AddText( FileStream^ fs, String^ value )
{
   array<Byte>^info = (gcnew UTF8Encoding( true ))->GetBytes( value );
   fs->Write( info, 0, info->Length );
}

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   // Delete the file if it exists.
   if ( File::Exists( path ) )
   {
      File::Delete( path );
   }

   //Create the file.
   {
      FileStream^ fs = File::Create( path );
      try
      {
         AddText( fs, "This is some text" );
         AddText( fs, "This is some more text," );
         AddText( fs, "\r\nand this is on a new line" );
         AddText( fs, "\r\n\r\nThe following is a subset of characters:\r\n" );
         for ( int i = 1; i < 120; i++ )
         {
            AddText( fs, Convert::ToChar( i ).ToString() );
            
            //Split the output at every 10th character.
            if ( Math::IEEERemainder( Convert::ToDouble( i ), 10 ) == 0 )
            {
               AddText( fs, "\r\n" );
            }
         }
      }
      finally
      {
         if ( fs )
            delete (IDisposable^)fs;
      }
   }
   
   //Open the stream and read it back.
   {
      FileStream^ fs = File::OpenRead( path );
      try
      {
         array<Byte>^b = gcnew array<Byte>(1024);
         UTF8Encoding^ temp = gcnew UTF8Encoding( true );
         while ( fs->Read( b, 0, b->Length ) > 0 )
         {
            Console::WriteLine( temp->GetString( b ) );
         }
      }
      finally
      {
         if ( fs )
            delete (IDisposable^)fs;
      }
   }
}
// </Snippet1>
