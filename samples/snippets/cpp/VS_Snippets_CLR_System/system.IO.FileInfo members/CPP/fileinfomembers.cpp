// <Snippet12>
using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization::Formatters::Binary;
// </Snippet12>

void Attributes()
{
   // <Snippet1>
   String^ fileName = "C:\\autoexec.bat";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }
   Console::WriteLine( " {0} has attributes of {1}",
      fileName, fileInfo->Attributes );

   // Toggle the archive flag of the file.
   bool archiveFlag = (fileInfo->Attributes & FileAttributes::Archive)
      == FileAttributes::Archive;
   if ( archiveFlag )
   {
      fileInfo->Attributes = (FileAttributes)(fileInfo->Attributes &
         ( ~FileAttributes::Archive));
   }
   else
   {
      fileInfo->Attributes = (FileAttributes)(fileInfo->Attributes |
         (FileAttributes::Archive) );
   }

   Console::WriteLine( " {0} has attributes of {1}",
      fileName, fileInfo->Attributes );
   // </Snippet1>
   Console::WriteLine();
}

void CreationTime()
{
   // <Snippet2>
   String^ fileName = "C:\\autoexec.bat";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   Console::WriteLine( " {0} was created at {1}",
      fileName, fileInfo->CreationTime );

   // Add two hours to the creation time.
   fileInfo->CreationTime += TimeSpan::FromHours( 2.0 );

   Console::WriteLine( " {0} is now created at {1}",
      fileName, fileInfo->CreationTime );
   // </Snippet2>
   Console::WriteLine();
}

void DirectoryName()
{
   // <Snippet3>
   String^ fileName = "C:\\TMP\\log.txt";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   Console::WriteLine( " {0} has a directoryName of {1}",
      fileName, fileInfo->DirectoryName );
   // </Snippet3>
   Console::WriteLine();
}

void DirectoryContents()
{
   // <Snippet4>
   String^ fileName = "C:\\autoexec.bat";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   DirectoryInfo^ dirInfo = fileInfo->Directory;
   Console::WriteLine( " {0} is in a directory of {1} files.",
      fileName, dirInfo->GetFiles()->Length );
   // </Snippet4>
   Console::WriteLine();
}

void ExtensionAndName()
{
   // <Snippet5>
   String^ dirName = "C:\\";
   DirectoryInfo^ dirInfo = gcnew DirectoryInfo( dirName );

   Console::WriteLine( "{0} contains the following system files:",
      dirName );
   for each ( FileInfo^ fileInfo in dirInfo->GetFiles() )
   {
      if ( fileInfo->Extension->ToLower() == ".sys" )
      {
         Console::WriteLine( fileInfo->Name );
      }
   }
   // </Snippet5>
   Console::WriteLine();
}

void LastAccessTime()
{
   // <Snippet6>
   String^ fileName = "C:\\autoexec.bat";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   Console::WriteLine( " {0} was last accessed at {1}",
      fileName, fileInfo->LastAccessTime );

   // Set the access time back two hours.
   fileInfo->LastAccessTime -= TimeSpan::FromHours( 2.0 );

   Console::WriteLine( " {0} now was last accessed at {1}",
      fileName, fileInfo->LastAccessTime );
   // </Snippet6>
   Console::WriteLine();
}

void LastWriteTime()
{
   // <Snippet7>
   String^ fileName = "C:\\autoexec.bat";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   Console::WriteLine( " {0} was last written to at {1}",
      fileName, fileInfo->LastWriteTime );

   // Set the access time back two hours.
   fileInfo->LastWriteTime -= TimeSpan::FromHours( 2.0 );
   Console::WriteLine( " {0} now was last written to at {1}",
      fileName, fileInfo->LastWriteTime );
   // </Snippet7>
   Console::WriteLine();
}

void Length()
{
   // <Snippet8>
   String^ dirName = "C:\\";
   DirectoryInfo^ dirInfo = gcnew DirectoryInfo( dirName );

   Console::WriteLine( " {0} contains the following files:", dirName );
   Console::WriteLine( "Size\t Filename" );
   for each ( FileInfo^ fileInfo in dirInfo->GetFiles() )
   {
      try
      {
         Console::WriteLine( " {0}\t {1}", fileInfo->Length, fileInfo->Name );
      }
      catch ( IOException^ e )
      {
         Console::WriteLine( "\t {0}: {1}", fileInfo->Name, e->Message );
      }
   }
   // </Snippet8>
   Console::WriteLine();
}

void AppendTextAndOpenText()
{
   // <Snippet9>
   String^ fileName = Path::GetTempFileName();
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   Console::WriteLine( "File ' {0}' created of size {1} bytes",
      fileName, fileInfo->Length );

   // Append some text to the file.
   StreamWriter^ s = fileInfo->AppendText();
   s->WriteLine( "The text in the file" );
   s->Close();

   fileInfo->Refresh();
   Console::WriteLine( "File ' {0}' now has size {1} bytes",
      fileName, fileInfo->Length );

   // Read the text file.
   StreamReader^ r = fileInfo->OpenText();
   String^ textLine;
   while ( (textLine = r->ReadLine()) != nullptr )
   {
      Console::WriteLine( textLine );
   }
   r->Close();
   // </Snippet9>
   Console::WriteLine();
}

void CreateText()
{
   // <Snippet10>
   FileInfo^ fileInfo = gcnew FileInfo( "myFile" );

   // Create the file and output some text to it.
   StreamWriter^ s = fileInfo->CreateText();
   s->WriteLine( "Output to the file" );
   s->Close();

   fileInfo->Refresh();
   Console::WriteLine( "File ' {0}' now has size {1} bytes",
      fileInfo->Name, fileInfo->Length );
   // </Snippet10>
   Console::WriteLine();
}

void OpenWriteAndOpenRead()
{
   // <Snippet11>
   // Create a temporary file.
   String^ fileName = Path::GetTempFileName();
   FileInfo^ fileInfo = gcnew FileInfo( fileName );

   // Write the current time to the file in binary form.
   DateTime currentTime = DateTime::Now;
   FileStream^ fileWriteStream = fileInfo->OpenWrite();
   BinaryFormatter^ binaryFormatter = gcnew BinaryFormatter;
   binaryFormatter->Serialize( fileWriteStream, currentTime );
   fileWriteStream->Close();

   // Read the time back from the file.
   FileStream^ fileReadStream = fileInfo->OpenRead();
   DateTime timeRead = (DateTime)(binaryFormatter->Deserialize( fileReadStream ));
   fileReadStream->Close();

   Console::WriteLine( "Value written {0}", currentTime );
   Console::WriteLine( "Value read {0}", timeRead );
   // </Snippet11>
   Console::WriteLine();
}

void main()
{
   Console::WriteLine();
   Attributes();
   CreationTime();
   DirectoryName();
   DirectoryContents();
   ExtensionAndName();
   LastAccessTime();
   LastWriteTime();
   Length();
   AppendTextAndOpenText();
   CreateText();
   OpenWriteAndOpenRead();
}
