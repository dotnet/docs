
// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml, FromXml, 
// GetPathList and SetPathList methods, and the AllFiles and AllLocalFiles properties  
// of the FileIOPermission class.
// <Snippet1>
using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Collections;

// This class generates FileIOPermission objects.

[assembly:CLSCompliant(true)];
private ref class FileIOGenerator
{
private:
   array<String^>^myFile;
   array<FileIOPermissionAccess>^myAccess;
   int fileIndex;

public:
   FileIOGenerator()
   {
      array<String^>^tempFile = {"C:\\Examples\\Test\\TestFile.txt","C:\\Examples\\Test\\","C:\\Examples\\Test\\..","C:\\Temp"};
      myFile = tempFile;
      array<FileIOPermissionAccess>^ tempAccess = {FileIOPermissionAccess::AllAccess,FileIOPermissionAccess::Append,FileIOPermissionAccess::NoAccess,FileIOPermissionAccess::PathDiscovery,FileIOPermissionAccess::Read,FileIOPermissionAccess::Write};
      myAccess = tempAccess;
      ResetIndex();
   }

   void ResetIndex()
   {
      fileIndex = 0;
   }


   // Create a file path.
   //<Snippet10>
   bool CreateFilePath(  [Out]interior_ptr<String^> file )
   {
      if ( fileIndex == myFile->Length )
      {
         *file = "";
         fileIndex++;
         return true;
      }

      if ( fileIndex > myFile->Length )
      {
          *file = "";
         return false;
      }

       *file = myFile[ fileIndex++ ];
      try
      {
         return true;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Cannot create FileIOPermission: {0} {1}",  *file, e );
          *file = "";
         return true;
      }

   }

   //</Snippet10>
};

public ref class FileIOPermissionDemo
{
private:

   // IsSubsetOf determines whether the current permission is a subset of the specified permission.
   // This method compares various FileIOPermission paths with FileIOPermissionAccess set to AllAccess.
   //<Snippet2>
   bool IsSubsetOfDemo()
   {
      bool returnValue = true;
      String^ fileIO1;
      String^ fileIO2;
      FileIOPermission^ fileIOPerm1;
      FileIOPermission^ fileIOPerm2;
      FileIOGenerator^ fileIOGen1 = gcnew FileIOGenerator;
      FileIOGenerator^ fileIOGen2 = gcnew FileIOGenerator;
      fileIOGen1->ResetIndex();
      while ( fileIOGen1->CreateFilePath(  &fileIO1 ) )
      {
          if (fileIO1 == "")
              fileIOPerm1 = gcnew FileIOPermission(PermissionState::None);
          else
              fileIOPerm1 = gcnew FileIOPermission(FileIOPermissionAccess::AllAccess, fileIO1);

         Console::WriteLine( "**********************************************************\n" );
         fileIOGen2->ResetIndex();
         while ( fileIOGen2->CreateFilePath( &fileIO2 ) )
         {
            if (fileIO2 == "")
                fileIOPerm2 = gcnew FileIOPermission(PermissionState::None);
            else
              fileIOPerm2 = gcnew FileIOPermission(FileIOPermissionAccess::AllAccess, fileIO2);
            String^ firstPermission = fileIO1 == "" || fileIO1 == nullptr ? "null" : fileIO1;
            String^ secondPermission = fileIO2 == "" || fileIO2 == nullptr ? "null" : fileIO2;
            if ( fileIOPerm2 == nullptr )
                        continue;
            try
            {
               if ( fileIOPerm1->IsSubsetOf( fileIOPerm2 ) )
               {
                  Console::WriteLine( "{0} is a subset of {1}\n", firstPermission, secondPermission );
               }
               else
               {
                  Console::WriteLine( "{0} is not a subset of {1}\n", firstPermission, secondPermission );
               }
            }
            catch ( Exception^ e ) 
            {
               Console::WriteLine( "An exception was thrown for subset :{0}\n{1}\n{2}", (fileIO1->Equals( "" ) ? "null" : fileIO1), (fileIO2->Equals( "" ) ? "null" : fileIO2), e );
            }

         }
      }

      return returnValue;
   }


   //</Snippet2>
   // Union creates a new permission that is the union of the current permission and the specified permission.
   //<Snippet3>
   bool UnionDemo()
   {
      bool returnValue = true;
      String^ fileIO1;
      String^ fileIO2;
      FileIOPermission^ fileIOPerm1;
      FileIOPermission^ fileIOPerm2;
      IPermission^ fileIOPerm3;
      FileIOGenerator^ fileIOGen1 = gcnew FileIOGenerator;
      FileIOGenerator^ fileIOGen2 = gcnew FileIOGenerator;
      fileIOGen1->ResetIndex();
      while ( fileIOGen1->CreateFilePath(  &fileIO1 ) )
      {
         if (fileIO1 == "")
             fileIOPerm1 = gcnew FileIOPermission(PermissionState::None);
          else
              fileIOPerm1 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO1);

         Console::WriteLine( "**********************************************************\n" );
         fileIOGen2->ResetIndex();
         while ( fileIOGen2->CreateFilePath(  &fileIO2 ) )
         {
             if (fileIO2 == "")
                 fileIOPerm2 = gcnew FileIOPermission(PermissionState::None);
            else
              fileIOPerm2 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO2);
            try
            {
               if ( fileIOPerm2 == nullptr )
                              continue;
               String^ firstPermission = fileIO1 == "" || fileIO1 == nullptr ? "null" : fileIO1;
               String^ secondPermission = fileIO2 == "" || fileIO2 == nullptr ? "null" : fileIO2;
               fileIOPerm3 = dynamic_cast<FileIOPermission^>(fileIOPerm1->Union( fileIOPerm2 ));
               fileIOPerm3 = fileIOPerm1->Union( fileIOPerm2 );
               if ( fileIOPerm3 == nullptr )
               {
                  Console::WriteLine( "The union of {0}  and {1} is null.", firstPermission, secondPermission );
               }
               else
               {
                  Console::WriteLine( "The union of {0}  and {1} = \n\t{2}", firstPermission, secondPermission, (dynamic_cast<FileIOPermission^>(fileIOPerm3))->GetPathList( FileIOPermissionAccess::Read )[ 0 ] );
               }
            }
            catch ( Exception^ e ) 
            {
               Console::WriteLine( "An exception was thrown for union {0}", e );
               returnValue = false;
            }

         }
      }

      return returnValue;
   }


   //</Snippet3>
   // Intersect creates and returns a new permission that is the intersection of the current 
   // permission and the permission specified.
   //<Snippet4>
   bool IntersectDemo()
   {
      bool returnValue = true;
      String^ fileIO1;
      String^ fileIO2;
      FileIOPermission^ fileIOPerm1;
      FileIOPermission^ fileIOPerm2;
      FileIOPermission^ fileIOPerm3;
      FileIOGenerator^ fileIOGen1 = gcnew FileIOGenerator;
      FileIOGenerator^ fileIOGen2 = gcnew FileIOGenerator;
      fileIOGen1->ResetIndex();
      while ( fileIOGen1->CreateFilePath ( &fileIO1  ) )
      {
         if (fileIO1 == "")
             fileIOPerm1 = gcnew FileIOPermission(PermissionState::None);
          else
              fileIOPerm1 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO1);

         Console::WriteLine( "**********************************************************\n" );
         fileIOGen2->ResetIndex();
         while ( fileIOGen2->CreateFilePath( &fileIO2  ) )
         {
            if (fileIO2 == "")
                fileIOPerm2 = gcnew FileIOPermission(PermissionState::None);
            else
              fileIOPerm2 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO2);
            String^ firstPermission = fileIO1 == "" || fileIO1 == nullptr ? "null" : fileIO1;
            String^ secondPermission = fileIO2 == "" || fileIO2 == nullptr ? "null" : fileIO2;
            try
            {
               fileIOPerm3 = dynamic_cast<FileIOPermission^>(fileIOPerm1->Intersect( fileIOPerm2 ));
               if ( fileIOPerm3 != nullptr && fileIOPerm3->GetPathList( FileIOPermissionAccess::Read ) != nullptr )
               {
                  Console::WriteLine( "The intersection of {0}  and \n\t{1} = \n\t{2}", firstPermission, secondPermission, (dynamic_cast<FileIOPermission^>(fileIOPerm3))->GetPathList( FileIOPermissionAccess::Read )[ 0 ] );
               }
               else
               {
                  Console::WriteLine( "The intersection of {0}  and {1} is null.", firstPermission, secondPermission );
               }
            }
            catch ( Exception^ e ) 
            {
               Console::WriteLine( "An exception was thrown for intersection {0}", e );
               returnValue = false;
            }

         }
      }

      return returnValue;
   }


   //</Snippet4>
   //Copy creates and returns an identical copy of the current permission.
   //<Snippet5>
   bool CopyDemo()
   {
      bool returnValue = true;
      String^ fileIO1;
      FileIOPermission^ fileIOPerm1;
      FileIOPermission^ fileIOPerm2;
      FileIOGenerator^ fileIOGen1 = gcnew FileIOGenerator;
      FileIOGenerator^ fileIOGen2 = gcnew FileIOGenerator;
      fileIOGen1->ResetIndex();
      while ( fileIOGen1->CreateFilePath( &fileIO1 ) )
      {
         if (fileIO1 == "")
             fileIOPerm1 = gcnew FileIOPermission(PermissionState::None);
          else
              fileIOPerm1 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO1);

         Console::WriteLine( "**********************************************************\n" );
         fileIOGen2->ResetIndex();
         try
         {
            fileIOPerm2 = dynamic_cast<FileIOPermission^>(fileIOPerm1->Copy());
            if ( fileIOPerm2 != nullptr )
            {
               Console::WriteLine( "Result of copy = {0}\n", fileIOPerm2 );
            }
            else
            {
               Console::WriteLine( "Result of copy is null. \n" );
            }
         }
         catch ( Exception^ e ) 
         {
            {
               if ( fileIO1->Equals( "" ) )
               {
                  Console::WriteLine( "The target FileIOPermission is empty, copy failed." );
               }
               else
                              Console::WriteLine( e );
            }
            continue;
         }

      }

      return returnValue;
   }


   //</Snippet5>
   // ToXml creates an XML encoding of the permission and its current state; 
   // FromXml reconstructs a permission with the specified state from the XML encoding. 
   //<Snippet6>
   bool ToFromXmlDemo()
   {
      bool returnValue = true;
      String^ fileIO1;
      FileIOPermission^ fileIOPerm1;
      FileIOPermission^ fileIOPerm2;
      FileIOGenerator^ fileIOGen1 = gcnew FileIOGenerator;
      FileIOGenerator^ fileIOGen2 = gcnew FileIOGenerator;
      fileIOGen1->ResetIndex();
      while ( fileIOGen1->CreateFilePath( &fileIO1 ) )
      {
         if (fileIO1 == "")
             fileIOPerm1 = gcnew FileIOPermission(PermissionState::None);
          else
              fileIOPerm1 = gcnew FileIOPermission(FileIOPermissionAccess::Read, fileIO1);

         Console::WriteLine( "********************************************************\n" );
         fileIOGen2->ResetIndex();
         try
         {
            fileIOPerm2 = gcnew FileIOPermission( PermissionState::None );
            fileIOPerm2->FromXml( fileIOPerm1->ToXml() );
            Console::WriteLine( "Result of ToFromXml = {0}\n", fileIOPerm2 );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( "ToFromXml failed :{0}{1}", fileIOPerm1, e );
            continue;
         }

      }

      return returnValue;
   }


   //</Snippet6>
   // AddPathList adds access for the specified files and directories to the existing state of the permission.
   // SetPathList sets the specified access to the specified files and directories, replacing the existing state 
   // of the permission.
   // GetPathList gets all files and directories that have the specified FileIOPermissionAccess.
   //<Snippet7>  
   bool SetGetPathListDemo()
   {
      try
      {
         Console::WriteLine( "********************************************************\n" );
         FileIOPermission^ fileIOPerm1;
         Console::WriteLine( "Creating a FileIOPermission with AllAccess rights for 'C:\\Examples\\Test\\TestFile.txt" );
         
         //<Snippet8>  
         fileIOPerm1 = gcnew FileIOPermission( FileIOPermissionAccess::AllAccess,"C:\\Examples\\Test\\TestFile.txt" );
         
         //</Snippet8>
         Console::WriteLine( "Adding 'C:\\Temp' to the write access list, and \n 'C:\\Examples\\Test' to read access." );
         fileIOPerm1->AddPathList( FileIOPermissionAccess::Write, "C:\\Temp" );
         fileIOPerm1->AddPathList( FileIOPermissionAccess::Read, "C:\\Examples\\Test" );
         array<String^>^paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Read );
         Console::WriteLine( "Read access before SetPathList = " );
         IEnumerator^ myEnum = paths->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum->Current);
            Console::WriteLine( "\t{0}", path );
         }

         Console::WriteLine( "Setting the read access list to \n'C:\\Temp'" );
         fileIOPerm1->SetPathList( FileIOPermissionAccess::Read, "C:\\Temp" );
         paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Read );
         Console::WriteLine( "Read access list after SetPathList = " );
         IEnumerator^ myEnum1 = paths->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum1->Current);
            Console::WriteLine( "\t{0}", path );
         }

         paths = fileIOPerm1->GetPathList( FileIOPermissionAccess::Write );
         Console::WriteLine( "Write access list after SetPathList = " );
         IEnumerator^ myEnum2 = paths->GetEnumerator();
         while ( myEnum2->MoveNext() )
         {
            String^ path = safe_cast<String^>(myEnum2->Current);
            Console::WriteLine( "\t{0}", path );
         }

         Console::WriteLine( "Write access = \n{0}", fileIOPerm1->GetPathList( FileIOPermissionAccess::AllAccess ) );
      }
      catch ( ArgumentException^ e ) 
      {
         
         // FileIOPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
         Console::WriteLine( "An ArgumentException occurred as a result of using AllAccess. This property cannot be used as a parameter in GetPathList because it represents more than one type of file variable access. : \n{0}", e );
      }

      return true;
   }


   //</Snippet7>  
   // The AllFiles property gets or sets the permitted access to all files.
   // The AllLocalFiles property gets or sets the permitted access to all local files.
   //<Snippet11>
   bool AllFilesDemo()
   {
      try
      {
         Console::WriteLine( "********************************************************\n" );
         FileIOPermission^ fileIOPerm1;
         Console::WriteLine( "Creating a FileIOPermission and adding read access for all files" );
         fileIOPerm1 = gcnew FileIOPermission( FileIOPermissionAccess::AllAccess,"C:\\Examples\\Test\\TestFile.txt" );
         fileIOPerm1->AllFiles = FileIOPermissionAccess::Read;
         Console::WriteLine( "AllFiles access = {0}", fileIOPerm1->AllFiles );
         Console::WriteLine( "Adding AllAccess rights for local files." );
         fileIOPerm1->AllLocalFiles = FileIOPermissionAccess::AllAccess;
         Console::WriteLine( "AllLocalFiles access = {0}", fileIOPerm1->AllLocalFiles );
      }
      catch ( ArgumentException^ e ) 
      {
         Console::WriteLine( e );
         return false;
      }

      return true;
   }


public:

   //</Snippet11>
   // Invoke all demos.
   bool RunDemo()
   {
      bool ret = true;
      bool retTmp;
      
      // Call the IsSubsetOfPath demo.
      if ( retTmp = IsSubsetOfDemo() )
            Console::WriteLine( "IsSubsetOf demo completed successfully." );
      else
            Console::WriteLine( "IsSubsetOf demo failed." );

      ret = retTmp && ret;
      
      // Call the Union demo.
      if ( retTmp = UnionDemo() )
            Console::WriteLine( "Union demo completed successfully." );
      else
            Console::WriteLine( "Union demo failed." );

      ret = retTmp && ret;
      
      // Call the Intersect demo. 
      if ( retTmp = IntersectDemo() )
            Console::WriteLine( "Intersect demo completed successfully." );
      else
            Console::WriteLine( "Intersect demo failed." );

      ret = retTmp && ret;
      
      // Call the Copy demo. 
      if ( retTmp = CopyDemo() )
            Console::WriteLine( "Copy demo completed successfully." );
      else
            Console::WriteLine( "Copy demo failed." );

      ret = retTmp && ret;
      
      // Call the ToFromXml demo. 
      if ( retTmp = ToFromXmlDemo() )
            Console::WriteLine( "ToFromXml demo completed successfully." );
      else
            Console::WriteLine( "ToFromXml demo failed." );

      ret = retTmp && ret;
      
      // Call the SetGetPathList demo. 
      if ( retTmp = SetGetPathListDemo() )
            Console::WriteLine( "SetGetPathList demo completed successfully." );
      else
            Console::WriteLine( "SetGetPathList demo failed." );

      ret = retTmp && ret;
      
      // Call the AllFiles demo. 
      if ( retTmp = AllFilesDemo() )
            Console::WriteLine( "AllFiles demo completed successfully." );
      else
            Console::WriteLine( "AllFiles demo failed." );

      ret = retTmp && ret;
      return (ret);
   }

};


// Test harness.
int main()
{
   try
   {
      FileIOPermissionDemo^ democase = gcnew FileIOPermissionDemo;
      bool ret = democase->RunDemo();
      if ( ret )
      {
         Console::WriteLine( "FileIOPermission demo completed successfully." );
         Console::WriteLine( "Press the Enter key to exit." );
         Console::ReadLine();
         System::Environment::ExitCode = 100;
      }
      else
      {
         Console::WriteLine( "FileIOPermission demo failed." );
         Console::WriteLine( "Press the Enter key to exit." );
         Console::ReadLine();
         System::Environment::ExitCode = 101;
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "FileIOPermission demo failed" );
      Console::WriteLine( e );
      Console::WriteLine( "Press the Enter key to exit." );
      Console::ReadLine();
      System::Environment::ExitCode = 101;
   }

}

//</Snippet1>

