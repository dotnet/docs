//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Runtime;
using namespace System::Reflection;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Security::Permissions;

namespace StreamWriterSample
{
   public ref class Logger
   {
//</snippet1>
   public:
      //Constructors
      Logger()
      {
         BeginWrite();
      }

      Logger( String^ logFile )
      {
         BeginWrite( logFile );
      }

      //Destructor
      ~Logger()
      {
         EndWrite();
      }

      //<snippet2> 
      void CreateTextFile( String^ fileName, String^ textToAdd )
      {
         String^ logFile = String::Concat( DateTime::Now.ToShortDateString()
            ->Replace( "/", "-" )->Replace( "\\", "-" ), ".log" );

         FileStream^ fs = gcnew FileStream( fileName,
            FileMode::CreateNew, FileAccess::Write, FileShare::None );

         StreamWriter^ swFromFile = gcnew StreamWriter( logFile );
         swFromFile->Write( textToAdd );
         swFromFile->Flush();
         swFromFile->Close();

         StreamWriter^ swFromFileStream = gcnew StreamWriter( fs );
         swFromFileStream->Write( textToAdd );
         swFromFileStream->Flush();
         swFromFileStream->Close();

         StreamWriter^ swFromFileStreamDefaultEnc =
            gcnew System::IO::StreamWriter( fs,
               System::Text::Encoding::Default );
         swFromFileStreamDefaultEnc->Write( textToAdd );
         swFromFileStreamDefaultEnc->Flush();
         swFromFileStreamDefaultEnc->Close();

         StreamWriter^ swFromFileTrue =
            gcnew StreamWriter( fileName,true );
         swFromFileTrue->Write( textToAdd );
         swFromFileTrue->Flush();
         swFromFileTrue->Close();

         StreamWriter^ swFromFileTrueUTF8Buffer =
            gcnew StreamWriter( fileName,
               true, System::Text::Encoding::UTF8, 512 );
         swFromFileTrueUTF8Buffer->Write( textToAdd );
         swFromFileTrueUTF8Buffer->Flush();
         swFromFileTrueUTF8Buffer->Close();

         StreamWriter^ swFromFileTrueUTF8 =
            gcnew StreamWriter( fileName, true,
               System::Text::Encoding::UTF8 );
         swFromFileTrueUTF8->Write( textToAdd );
         swFromFileTrueUTF8->Flush();
         swFromFileTrueUTF8->Close();

         StreamWriter^ swFromFileStreamUTF8Buffer =
            gcnew StreamWriter( fs, System::Text::Encoding::UTF8, 512 );
         swFromFileStreamUTF8Buffer->Write( textToAdd );
         swFromFileStreamUTF8Buffer->Flush();
         swFromFileStreamUTF8Buffer->Close();
      }
      //</snippet2> 

      //<snippet3> 
   private:
      [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]
      void BeginWrite( String^ logFile )
      {
      //</snippet3> 
         //<snippet4>
         StreamWriter^ sw = gcnew StreamWriter( logFile,true );
         
         //</snippet4>
         //<snippet5> 
         // Gets or sets a value indicating whether the StreamWriter
         // will flush its buffer to the underlying stream after every 
         // call to StreamWriter.Write.
         sw->AutoFlush = true;
         //</snippet5>
         //<snippet6> 
         if ( sw->Equals( StreamWriter::Null ) )
         {
            sw->WriteLine( "The store can be written to, but not read from." );
         }
         //</snippet6>
         //<snippet7> 
         sw->Write( Char::Parse( " " ) );
         //</snippet7>
         //<snippet8> 
         String^ hello = "Hellow World!";
         array<Char>^ buffer = hello->ToCharArray();
         sw->Write( buffer );
         //</snippet8>
         //<snippet9> 
         String^ helloWorld = "Hellow World!";
         // writes out "low World"
         sw->Write( helloWorld );
         //</snippet9>
         //<snippet10> 
         sw->WriteLine( "---Begin Log Entry---" );
         //</snippet10>
         //<snippet11> 
         // Write out the current text encoding
         sw->WriteLine( "Encoding: {0}",
            sw->Encoding->ToString() );
         //</snippet11>
         //<snippet12> 
         // Display the Format Provider
         sw->WriteLine( "Format Provider: {0} ",
            sw->FormatProvider->ToString() );
         //</snippet12>
         //<snippet13> 
         // Set the characters you would like to designate a new line
         sw->NewLine = "\r\n";
         //</snippet13>
         //<snippet14> 
         ILease^ obj = dynamic_cast<ILease^>(sw->InitializeLifetimeService());
         if ( obj != nullptr )
         {
            sw->WriteLine( "Object initialized lease " +
               "time remaining: {0}.",
               obj->CurrentLeaseTime.ToString() );
         }
         //</snippet14>
         //<snippet15> 
         ILease^ lease = dynamic_cast<ILease^>(sw->GetLifetimeService());
         if ( lease != nullptr )
         {
            sw->WriteLine( "Object lease time remaining: {0}.",
               lease->CurrentLeaseTime.ToString() );
         }
         //</snippet15>

         //<snippet16> 
         // update underlying file
         sw->Flush();
         //</snippet16>
         //<snippet17> 
         // close the file by closing the writer
         sw->Close();
         //</snippet17>
         //<snippet18> 
      }
      //</snippet18> 

      void BeginWrite()
      {
         BeginWrite( String::Concat( DateTime::Now.ToShortDateString()
            ->Replace( "/", "-" )->Replace( "\\", "-" ), ".log" ) );
      }

      void EndWrite( String^ logFile )
      {
         StreamWriter^ sw = gcnew StreamWriter( logFile,true );
         
         // Set the file pointer to the end of file.
         sw->BaseStream->Seek( 0, SeekOrigin::End );
         // Write text to the file.
         sw->WriteLine( "---End Log Entry---\r\n" );
         // Update the underlying file.
         sw->Flush();
         // Close the file by closing the writer.
         sw->Close();
      }

      void EndWrite()
      {
         EndWrite( String::Concat( DateTime::Now.ToShortDateString()
            ->Replace( "/", "-" )->Replace( "\\", "-" ), ".log" ) );
      }
      //<snippet19> 
   };
}
//</snippet19>

int main()
{
   StreamWriterSample::Logger^ l = gcnew StreamWriterSample::Logger;
}
