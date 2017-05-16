
//<snippet1>  
// This sample demonstrates methods of classes found in the System.IO IsolatedStorage namespace.
using namespace System;
using namespace System::IO;
using namespace System::IO::IsolatedStorage;
using namespace System::Security::Policy;
using namespace System::Security::Permissions;

public ref class LoginPrefs
{
private:
   String^ userName;
   String^ newsUrl;
   String^ sportsUrl;
   bool newPrefs;

public:

   //<snippet4>   
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   bool GetPrefsForUser()
   {
      try
      {
         
         //<Snippet15>
         // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), (Type^)nullptr, nullptr );
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::Open,FileAccess::ReadWrite,isoFile );
         
         //</Snippet15>
         // farThe code executes to this point only if a file corresponding to the username exists.
         // Though you can perform operations on the stream, you cannot get a handle to the file.
         try
         {
            IntPtr aFileHandle = isoStream->Handle;
            Console::WriteLine( "A pointer to a file handle has been obtained. {0} {1}", aFileHandle, aFileHandle.GetHashCode() );
         }
         catch ( Exception^ e ) 
         {
            
            // Handle the exception.
            Console::WriteLine( "Expected exception" );
            Console::WriteLine( e->ToString() );
         }

         StreamReader^ reader = gcnew StreamReader( isoStream );
         
         // Read the data.
         this->NewsUrl = reader->ReadLine();
         this->SportsUrl = reader->ReadLine();
         reader->Close();
         isoFile->Close();
         isoStream->Close();
         return false;
      }
      catch ( Exception^ e ) 
      {
         
         // Expected exception if a file cannot be found. This indicates that we have a new user.
         String^ errorMessage = e->ToString();
         return true;
      }

   }


   //</snippet4>
   //<snippet3> 
   bool GetIsoStoreInfo()
   {
      
      // Get a User store with type evidence for the current Domain and the Assembly.
      IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
      
      //<Snippet16>
      array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
      array<String^>^fileNames = isoFile->GetFileNames( "*" );
      
      // List directories currently in this Isolated Storage.
      if ( dirNames->Length > 0 )
      {
         for ( int i = 0; i < dirNames->Length; ++i )
         {
            Console::WriteLine( "Directory Name: {0}", dirNames[ i ] );

         }
      }

      
      // List the files currently in this Isolated Storage.
      // The list represents all users who have personal preferences stored for this application.
      if ( fileNames->Length > 0 )
      {
         for ( int i = 0; i < fileNames->Length; ++i )
         {
            Console::WriteLine( "File Name: {0}", fileNames[ i ] );

         }
      }

      
      //</Snippet16>
      isoFile->Close();
      return true;
   }


   //</snippet3>
   //<snippet2>
   double SetPrefsForUser()
   {
      try
      {
         
         //<snippet10>   
         IsolatedStorageFile^ isoFile;
         isoFile = IsolatedStorageFile::GetUserStoreForDomain();
         
         // Open or create a writable file.
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,FileAccess::Write,isoFile );
         StreamWriter^ writer = gcnew StreamWriter( isoStream );
         writer->WriteLine( this->NewsUrl );
         writer->WriteLine( this->SportsUrl );
         
         // Calculate the amount of space used to record the user's preferences.
         double d = isoFile->CurrentSize / isoFile->MaximumSize;
         Console::WriteLine( "CurrentSize = {0}", isoFile->CurrentSize.ToString() );
         Console::WriteLine( "MaximumSize = {0}", isoFile->MaximumSize.ToString() );
         writer->Close();
         isoFile->Close();
         isoStream->Close();
         return d;
         
         //</snippet10>
      }
      catch ( Exception^ e ) 
      {      
         // Add code here to handle the exception.
         Console::WriteLine( e->ToString() );
         return 0.0;
      }

   }


   //</snippet2>
   //<snippet6>  
   void DeleteFiles()
   {
      
      //<snippet9>  
      try
      {
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
         array<String^>^fileNames = isoFile->GetFileNames( "*" );
         
         //</snippet9>
         // List the files currently in this Isolated Storage.
         // The list represents all users who have personal
         // preferences stored for this application.
         if ( fileNames->Length > 0 )
         {
            for ( int i = 0; i < fileNames->Length; ++i )
            {
               
               //Delete the files.
               isoFile->DeleteFile( fileNames[ i ] );

            }
            fileNames = isoFile->GetFileNames( "*" );
         }
         isoFile->Close();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }

   }


   //</snippet6>
   //<snippet8>  
   // This method deletes directories in the specified Isolated Storage, after first 
   // deleting the files they contain. In this example, the Archive directory is deleted. 
   // There should be no other directories in this Isolated Storage.
   void DeleteDirectories()
   {
      try
      {
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         array<String^>^dirNames = isoFile->GetDirectoryNames( "*" );
         array<String^>^fileNames = isoFile->GetFileNames( "Archive\\*" );
         
         // Delete the current files within the Archive directory.
         if ( fileNames->Length > 0 )
         {
            for ( int i = 0; i < fileNames->Length; ++i )
            {
               
               //delete files
               isoFile->DeleteFile( String::Concat("Archive\\", fileNames[ i ]) );

            }
            fileNames = isoFile->GetFileNames( "Archive\\*" );
         }
         if ( dirNames->Length > 0 )
         {
            for ( int i = 0; i < dirNames->Length; ++i )
            {
               
               // Delete the Archive directory.
               isoFile->DeleteDirectory( dirNames[ i ] );

            }
         }
         dirNames = isoFile->GetDirectoryNames( "*" );
         isoFile->Remove();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }

   }


   //</snippet8>
   //<snippet7>  
   double SetNewPrefsForUser()
   {
      try
      {
         Byte inputChar;
         IsolatedStorageFile^ isoFile = IsolatedStorageFile::GetStore( static_cast<IsolatedStorageScope>(IsolatedStorageScope::User | IsolatedStorageScope::Assembly | IsolatedStorageScope::Domain), System::Security::Policy::Url::typeid, System::Security::Policy::Url::typeid );
         
         // If this is not a new user, archive the old preferences and 
         // overwrite them using the new preferences.
         if (  !this->NewPrefs )
         {
            if ( isoFile->GetDirectoryNames( "Archive" )->Length == 0 )
                        isoFile->CreateDirectory( "Archive" );
            else
            {
               
               //<Snippet11>
               // This is the stream to which data will be written.
               IsolatedStorageFileStream^ source = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,isoFile );
               
               // This is the stream from which data will be read.
               Console::WriteLine( "Is the source file readable?  {0}", (source->CanRead ? (String^)"true" : "false") );
               Console::WriteLine( "Creating new IsolatedStorageFileStream for Archive." );
               
               // Open or create a writable file.
               IsolatedStorageFileStream^ target = gcnew IsolatedStorageFileStream( String::Concat("Archive\\",this->userName),FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,isoFile );
               
               //</Snippet11>
               //<Snippet13>
               Console::WriteLine( "Is the target file writable? {0}", (target->CanWrite ? (String^)"true" : "false") );
               
               //</Snippet13>
               // Stream the old file to a new file in the Archive directory.
               if ( source->IsAsync && target->IsAsync )
               {
                  
                  // IsolatedStorageFileStreams cannot be asynchronous.  However, you
                  // can use the asynchronous BeginRead and BeginWrite functions
                  // with some possible performance penalty.
                  Console::WriteLine( "IsolatedStorageFileStreams cannot be asynchronous." );
               }
               else
               {
                  
                  //<Snippet14>
                  Console::WriteLine( "Writing data to the new file." );
                  while ( source->Position < source->Length )
                  {
                     inputChar = (Byte)source->ReadByte();
                     target->WriteByte( (Byte)source->ReadByte() );
                  }
                  
                  // Determine the size of the IsolatedStorageFileStream
                  // by checking its Length property.
                  Console::WriteLine( "Total Bytes Read: {0}", source->Length.ToString() );
                  
                  //</Snippet14>
               }
               
               // After you have read and written to the streams, close them.
               target->Close();
               source->Close();
            }
         }
         
         //<Snippet12>
         // Open or create a writable file, no larger than 10k
         IsolatedStorageFileStream^ isoStream = gcnew IsolatedStorageFileStream( this->userName,FileMode::OpenOrCreate,FileAccess::Write,FileShare::Write,10240,isoFile );
         
         //</Snippet12>
         isoStream->Position = 0; // Position to overwrite the old data.
         
         //</snippet7>
         //<snippet5>  
         StreamWriter^ writer = gcnew StreamWriter( isoStream );
         
         // Update the data based on the new inputs.
         writer->WriteLine( this->NewsUrl );
         writer->WriteLine( this->SportsUrl );
         
         // Calculate the amount of space used to record this user's preferences.
         double d = isoFile->CurrentSize / isoFile->MaximumSize;
         Console::WriteLine( "CurrentSize = {0}", isoFile->CurrentSize.ToString() );
         Console::WriteLine( "MaximumSize = {0}", isoFile->MaximumSize.ToString() );
         
         //</snippet5>
         // StreamWriter.Close implicitly closes isoStream.
         writer->Close();
         isoFile->Close();
         return d;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
         return 0.0;
      }

   }

   LoginPrefs( String^ aUserName )
   {
      userName = aUserName;
      newPrefs = GetPrefsForUser();
   }


   property String^ NewsUrl 
   {
      String^ get()
      {
         return newsUrl;
      }

      void set( String^ value )
      {
         newsUrl = value;
      }

   }

   property String^ SportsUrl 
   {
      String^ get()
      {
         return sportsUrl;
      }

      void set( String^ value )
      {
         sportsUrl = value;
      }

   }

   property bool NewPrefs 
   {
      bool get()
      {
         return newPrefs;
      }

   }

};

void GatherInfoFromUser( LoginPrefs^ lp )
{
   Console::WriteLine( "Please enter the URL of your news site." );
   lp->NewsUrl = Console::ReadLine();
   Console::WriteLine( "Please enter the URL of your sports site." );
   lp->SportsUrl = Console::ReadLine();
}

int main()
{
   
   // Prompt the user for their username.
   Console::WriteLine( "Enter your login ID:" );
   
   // Does no error checking.
   LoginPrefs^ lp = gcnew LoginPrefs( Console::ReadLine() );
   if ( lp->NewPrefs )
   {
      Console::WriteLine( "Please set preferences for a new user." );
      GatherInfoFromUser( lp );
      
      // Write the new preferences to storage.
      double percentUsed = lp->SetPrefsForUser();
      Console::WriteLine( "Your preferences have been written. Current space used is {0}%", percentUsed );
   }
   else
   {
      Console::WriteLine( "Welcome back." );
      Console::WriteLine( "Your preferences have expired, please reset them." );
      GatherInfoFromUser( lp );
      lp->SetNewPrefsForUser();
      Console::WriteLine( "Your news site has been set to {0}\n and your sports site has been set to {1}.", lp->NewsUrl, lp->SportsUrl );
   }

   lp->GetIsoStoreInfo();
   Console::WriteLine( "Enter 'd' to delete the IsolatedStorage files and exit, or press any other key to exit without deleting files." );
   String^ consoleInput = Console::ReadLine();
   if ( consoleInput->Equals( "d" ) )
   {
      lp->DeleteFiles();
      lp->DeleteDirectories();
   }
}

//</snippet1>
