// This sample demonstrates how to use each member of the FileCodeGroup class.
//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Security::Permissions;
using namespace System::Reflection;

ref class Members
{
public:
   [STAThread]
   static void Main()
   {
      FileCodeGroup^ fileCodeGroup = constructDefaultGroup();
      
      // Create a deep copy of the FileCodeGroup.
      //<Snippet18>
      FileCodeGroup^ copyCodeGroup =
         dynamic_cast<FileCodeGroup^>(fileCodeGroup->Copy());
      //</Snippet18>

      CompareTwoCodeGroups( fileCodeGroup, copyCodeGroup );
      addPolicy(  &fileCodeGroup );
      addXmlMember(  &fileCodeGroup );
      updateMembershipCondition(  &fileCodeGroup );
      addChildCodeGroup(  &fileCodeGroup );
      Console::Write( L"Comparing the resolved code group " );
      Console::WriteLine( L"with the initial code group." );
      FileCodeGroup^ resolvedCodeGroup =
         ResolveGroupToEvidence( fileCodeGroup );
      if ( CompareTwoCodeGroups( fileCodeGroup, resolvedCodeGroup ) )
      {
         PrintCodeGroup( resolvedCodeGroup );
      }
      else
      {
         PrintCodeGroup( fileCodeGroup );
      }

      Console::WriteLine( L"This sample completed successfully; press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Construct a new FileCodeGroup with Read, Write, Append
   // and PathDiscovery access.
   static FileCodeGroup^ constructDefaultGroup()
   {
      // Construct a new file code group that has complete access to
      // files in the specified path.
      //<Snippet2>
      FileCodeGroup^ fileCodeGroup = gcnew FileCodeGroup(
         gcnew AllMembershipCondition,FileIOPermissionAccess::AllAccess );
      //</Snippet2>

      // Set the name of the file code group.
      //<Snippet3>
      fileCodeGroup->Name = L"TempCodeGroup";
      //</Snippet3>

      // Set the description of the file code group.
      //<Snippet4>
      fileCodeGroup->Description = L"Temp folder permissions group";
      //</Snippet4>

      // Retrieve the string representation of the  fileCodeGroup’s
      // attributes. FileCodeGroup does not use AttributeString, so the
      // value should be null.
      //<Snippet5>
      if ( fileCodeGroup->AttributeString != nullptr )
      {
         throw gcnew NullReferenceException(
            L"The AttributeString property should be null." );
      }
      //</Snippet5>

      return fileCodeGroup;
   }

   // Add file permission to restrict write access to all files on the
   // local machine.
   static void addPolicy( interior_ptr<FileCodeGroup^> fileCodeGroup )
   {
      // Set the PolicyStatement property to a policy with read access to
      // the root directory of drive C.
      //<Snippet6>
      FileIOPermission^ rootFilePermissions =
         gcnew FileIOPermission( PermissionState::None );
      rootFilePermissions->AllLocalFiles =
         FileIOPermissionAccess::Read;
      rootFilePermissions->SetPathList(
         FileIOPermissionAccess::Read, L"C:\\" );
      NamedPermissionSet^ namedPermissions =
         gcnew NamedPermissionSet( L"RootPermissions" );
      namedPermissions->AddPermission( rootFilePermissions );
      ( *fileCodeGroup )->PolicyStatement =
         gcnew PolicyStatement( namedPermissions );
      //</Snippet6>
   }

   // Set the membership condition of the specified FileCodeGroup
   // to the Intranet zone.
   static void updateMembershipCondition( interior_ptr<FileCodeGroup^> fileCodeGroup )
   {
      //<Snippet7>
      ZoneMembershipCondition^ zoneCondition =
         gcnew ZoneMembershipCondition( SecurityZone::Intranet );
      ( *fileCodeGroup )->MembershipCondition = zoneCondition;
      //</Snippet7>
   }

   // Add a child group with read-access file permission to the specified
   // code group.
   static void addChildCodeGroup( interior_ptr<FileCodeGroup^> fileCodeGroup )
   {
      // Create a file code group with read-access permission.
      //<Snippet8>
      FileCodeGroup^ tempFolderCodeGroup = gcnew FileCodeGroup(
         gcnew AllMembershipCondition,FileIOPermissionAccess::Read );
      
      // Set the name of the child code group and add it to
      // the specified code group.
      tempFolderCodeGroup->Name = L"Read-only group";
      ( *fileCodeGroup )->AddChild( tempFolderCodeGroup );
      //</Snippet8>
   }

   // Compare the two specified file code groups for equality.
   static bool CompareTwoCodeGroups( FileCodeGroup^ firstCodeGroup,
      FileCodeGroup^ secondCodeGroup )
   {
      //<Snippet20>
      if ( firstCodeGroup->Equals( secondCodeGroup ) )
      //</Snippet20>
      {
         Console::WriteLine( L"The two code groups are equal." );
         return true;
      }
      else
      {
         Console::WriteLine( L"The two code groups are not equal." );
         return false;
      }
   }

   // Retrieve the resolved policy based on Evidence from the executing
   // assembly found in the specified code group.
   static String^ ResolveEvidence( CodeGroup^ fileCodeGroup )
   {
      String^ policyString = L"";
      
      // Resolve the policy based on evidence in the executing assembly.
      //<Snippet19>
      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ executingEvidence = assembly->Evidence;
      PolicyStatement^ policy = fileCodeGroup->Resolve( executingEvidence );
      //</Snippet19>

      if ( policy != nullptr )
      {
         policyString = policy->ToString();
      }

      return policyString;
   }

   // Retrieve the resolved code group based on the Evidence from
   // the executing assembly found in the specified code group.
   static FileCodeGroup^ ResolveGroupToEvidence( FileCodeGroup^ fileCodeGroup )
   {
      // Resolve matching code groups to the executing assembly.
      //<Snippet9>
      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ evidence = assembly->Evidence;
      CodeGroup^ codeGroup = fileCodeGroup->ResolveMatchingCodeGroups( evidence );
      //</Snippet9>

      return dynamic_cast<FileCodeGroup^>(codeGroup);
   }

   // If a domain attribute is not found in the specified FileCodeGroup,
   // add a child XML element identifying a custom membership condition.
   static void addXmlMember( interior_ptr<FileCodeGroup^> fileCodeGroup )
   {
      //<Snippet10>
      SecurityElement^ xmlElement = ( *fileCodeGroup )->ToXml();
      //</Snippet10>

      SecurityElement^ rootElement = gcnew SecurityElement( L"CodeGroup" );
      if ( xmlElement->Attribute(L"domain") == nullptr )
      {
         //<Snippet11>
         SecurityElement^ newElement = gcnew SecurityElement(
            L"CustomMembershipCondition" );
         newElement->AddAttribute( L"class", L"CustomMembershipCondition" );
         newElement->AddAttribute( L"version", L"1" );
         newElement->AddAttribute( L"domain", L"contoso.com" );
         rootElement->AddChild( newElement );
         ( *fileCodeGroup )->FromXml( rootElement );
         //</Snippet11>
      }

      Console::WriteLine( L"Added a custom membership condition:" );
      Console::WriteLine( rootElement );
   }

   // Print the properties of the specified code group to the console.
   static void PrintCodeGroup( CodeGroup^ codeGroup )
   {
      // Compare the type of the specified object with the FileCodeGroup
      // type.
      //<Snippet12>
      if (  !codeGroup->GetType()->Equals( FileCodeGroup::typeid ) )
      //</Snippet12>
      {
         throw gcnew ArgumentException( L"Expected the FileCodeGroup type." );
      }

      String^ codeGroupName = codeGroup->Name;
      String^ membershipCondition = codeGroup->MembershipCondition->ToString();
      
      //<Snippet13>
      String^ permissionSetName = codeGroup->PermissionSetName;
      //</Snippet13>

      //<Snippet14>
      int hashCode = codeGroup->GetHashCode();
      //</Snippet14>

      String^ mergeLogic = L"";
      
      //<Snippet15>
      if ( codeGroup->MergeLogic->Equals( L"Union" ) )
      {
         mergeLogic = L" with Union merge logic";
      }
      //</Snippet15>
      
      // Retrieve the class path for FileCodeGroup.
      //<Snippet16>
      String^ fileGroupClass = codeGroup->ToString();
      
      //</Snippet16>
      // Write summary to the console window.
      Console::WriteLine( L"\n*** {0} summary ***", fileGroupClass );
      Console::Write( L"A FileCodeGroup named " );
      Console::Write( L"{0}{1}", codeGroupName, mergeLogic );
      Console::Write( L" has been created with hash code{0}.", hashCode );
      Console::Write( L"This code group contains a {0}", membershipCondition );
      Console::Write( L" membership condition with the " );
      Console::Write( L"{0} permission set. ", permissionSetName );
      Console::Write( L"The code group has the following security policy: " );
      Console::WriteLine( ResolveEvidence( codeGroup ) );
      int childCount = codeGroup->Children->Count;
      if ( childCount > 0 )
      {
         Console::Write( L"There are {0}", childCount );
         Console::WriteLine( L" child code groups in this code group." );
         
         // Iterate through the child code groups to display their names
         // and remove them from the specified code group.
         for ( int i = 0; i < childCount; i++ )
         {
            // Get child code group as type FileCodeGroup.
            //<Snippet21>
            FileCodeGroup^ childCodeGroup =
               dynamic_cast<FileCodeGroup^>(codeGroup->Children->default[ i ]);
            
            //</Snippet21>
            Console::Write( L"Removing the {0}.", childCodeGroup->Name );
            // Remove child code group.

            //<Snippet17>
            codeGroup->RemoveChild( childCodeGroup );
            //</Snippet17>
         }
         Console::WriteLine();
      }
      else
      {
         Console::Write( L"There are no child code groups" );
         Console::WriteLine( L" in this code group." );
      }
   }
};

int main()
{
   Members::Main();
}

//
// This sample produces the following output:
//
// The two code groups are equal.
// Added a custom membership condition:
// <CodeGroup>
// <CustomMembershipCondition class="CustomMembershipCondition"
//                                version="1"
//                                domain="contoso.com"/>
//                                </CodeGroup>
// Comparing the resolved code group with the initial code group.
// The two code groups are not equal.
//
// *** System.Security.Policy.FileCodeGroup summary ***
// A FileCodeGroup named  with Union merge logic has been created with hash
// code 113151473. This code group contains a Zone - Intranet membership
// condition with the Same directory FileIO - NoAccess permission set. The
// code group has the following security policy:
// There are 1 child code groups in this code group.
// Removing the Read-only group.
// This sample completed successfully; press Enter to exit.
//</Snippet1>
