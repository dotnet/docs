// This sample demonstrates how to use each member of the FirstMatchCodeGroup
// class.
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
      // Create a new FirstMatchCodeGroup.
      FirstMatchCodeGroup^ codeGroup = constructDefaultGroup();
      
      // Create a deep copy of the FirstMatchCodeGroup.
      //<Snippet18>
      FirstMatchCodeGroup^ copyCodeGroup =
         dynamic_cast<FirstMatchCodeGroup^>(codeGroup->Copy());
      //</Snippet18>

      // Compare the original code group with the copy.
      CompareTwoCodeGroups( codeGroup, copyCodeGroup );

      addPolicy(  &codeGroup );
      addXmlMember(  &codeGroup );
      updateMembershipCondition(  &codeGroup );
      addChildCodeGroup(  &codeGroup );

      Console::Write( L"Comparing the resolved code group " );
      Console::WriteLine( L"with the initial code group." );
      FirstMatchCodeGroup^ resolvedCodeGroup =
         ResolveGroupToEvidence( codeGroup );
      if ( CompareTwoCodeGroups( codeGroup, resolvedCodeGroup ) )
      {
         PrintCodeGroup( resolvedCodeGroup );
      }
      else
      {
         PrintCodeGroup( codeGroup );
      }

      Console::WriteLine( L"This sample completed successfully; "
      L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Create a FirstMatchCodeGroup with an exclusive policy and membership
   // condition.
   static FirstMatchCodeGroup^ constructDefaultGroup()
   {
      // Construct a new FirstMatchCodeGroup with Read, Write, Append
      // and PathDiscovery access.
      // Create read access permission to the root directory on drive C.
      //<Snippet2>
      FileIOPermission^ rootFilePermissions =
         gcnew FileIOPermission( PermissionState::None );
      rootFilePermissions->AllLocalFiles = FileIOPermissionAccess::Read;
      rootFilePermissions->SetPathList( FileIOPermissionAccess::Read, L"C:\\" );
      
      // Add a permission to a named permission set.
      NamedPermissionSet^ namedPermissions =
         gcnew NamedPermissionSet( L"RootPermissions" );
      namedPermissions->AddPermission( rootFilePermissions );
      
      // Create a PolicyStatement with exclusive rights to the policy.
      PolicyStatement^ policy = gcnew PolicyStatement(
         namedPermissions,PolicyStatementAttribute::Exclusive );
      
      // Create a FirstMatchCodeGroup with a membership condition that
      // matches all code, and an exclusive policy.
      FirstMatchCodeGroup^ codeGroup = gcnew FirstMatchCodeGroup(
         gcnew AllMembershipCondition,policy );
      //</Snippet2>

      // Set the name of the first match code group.
      //<Snippet3>
      codeGroup->Name = L"TempCodeGroup";
      //</Snippet3>

      // Set the description of the first match code group.
      //<Snippet4>
      codeGroup->Description = L"Temp folder permissions group";
      //</Snippet4>
      return codeGroup;
   }

   // Add file permission to restrict write access to all files
   // on the local machine.
   static void addPolicy( interior_ptr<FirstMatchCodeGroup^> codeGroup )
   {
      // Set the PolicyStatement property to a policy with read access to
      // the root directory on drive C.
      //<Snippet6>
      FileIOPermission^ rootFilePermissions =
         gcnew FileIOPermission( PermissionState::None );
      rootFilePermissions->AllLocalFiles = FileIOPermissionAccess::Read;
      rootFilePermissions->SetPathList( FileIOPermissionAccess::Read, L"C:\\" );

      NamedPermissionSet^ namedPermissions =
         gcnew NamedPermissionSet( L"RootPermissions" );
      namedPermissions->AddPermission( rootFilePermissions );
      
      // Create a PolicyStatement with exclusive rights to the policy.
      PolicyStatement^ policy = gcnew PolicyStatement(
         namedPermissions,PolicyStatementAttribute::Exclusive );
      ( *codeGroup )->PolicyStatement = policy;
      //</Snippet6>
   }

   // Set the membership condition of the code group.
   static void updateMembershipCondition(
      interior_ptr<FirstMatchCodeGroup^> codeGroup )
   {
      // Set the membership condition of the specified FirstMatchCodeGroup
      // to the Intranet zone.
      //<Snippet7>
      ZoneMembershipCondition^ zoneCondition =
         gcnew ZoneMembershipCondition( SecurityZone::Intranet );
      ( *codeGroup )->MembershipCondition = zoneCondition;
      //</Snippet7>
   }

   // Create a child code group with read-access file permissions and add it
   // to the specified code group.
   static void addChildCodeGroup( interior_ptr<FirstMatchCodeGroup^> codeGroup )
   {
      // Create a first match code group with read access.
      //<Snippet8>
      FileIOPermission^ rootFilePermissions = gcnew FileIOPermission(
         PermissionState::None );
      rootFilePermissions->AllLocalFiles = FileIOPermissionAccess::Read;
      rootFilePermissions->SetPathList( FileIOPermissionAccess::Read, L"C:\\" );

      PermissionSet^ permissions = gcnew PermissionSet(
         PermissionState::Unrestricted );
      permissions->AddPermission( rootFilePermissions );

      FirstMatchCodeGroup^ tempFolderCodeGroup =
         gcnew FirstMatchCodeGroup( gcnew AllMembershipCondition,
            gcnew PolicyStatement( permissions ) );
      
      // Set the name of the child code group and add it to
      // the specified code group.
      tempFolderCodeGroup->Name = L"Read-only code group";
      ( *codeGroup )->AddChild( tempFolderCodeGroup );
      //</Snippet8>
   }

   // Compare the two FirstMatchCodeGroups.
   static bool CompareTwoCodeGroups( FirstMatchCodeGroup^ firstCodeGroup,
      FirstMatchCodeGroup^ secondCodeGroup )
   {
      // Compare the two specified FirstMatchCodeGroups for equality.
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

   // Retrieve the resolved policy based on executing evidence found
   // in the specified code group.
   static String^ ResolveEvidence( CodeGroup^ codeGroup )
   {
      String^ policyString = L"None";
      
      // Resolve the policy based on the executing assembly's evidence.
      //<Snippet19>
      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ executingEvidence = assembly->Evidence;

      PolicyStatement^ policy = codeGroup->Resolve( executingEvidence );
      //</Snippet19>

      if ( policy != nullptr )
      {
         policyString = policy->ToString();
      }

      return policyString;
   }

   // Retrieve the resolved code group based on the evidence from the
   // specified code group.
   static FirstMatchCodeGroup^ ResolveGroupToEvidence(
      FirstMatchCodeGroup^ codeGroup )
   {
      // Resolve matching code groups to the executing assembly.
      //<Snippet9>
      Assembly^ assembly = Members::typeid->Assembly;
      Evidence^ evidence = assembly->Evidence;
      CodeGroup^ resolvedCodeGroup =
         codeGroup->ResolveMatchingCodeGroups( evidence );
      //</Snippet9>

      return dynamic_cast<FirstMatchCodeGroup^>(resolvedCodeGroup);
   }

   // If a domain attribute is not found in the specified
   // FirstMatchCodeGroup, add a child XML element identifying a custom
   // membership condition.
   static void addXmlMember( interior_ptr<FirstMatchCodeGroup^> codeGroup )
   {
      //<Snippet10>
      SecurityElement^ xmlElement = ( *codeGroup )->ToXml();
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
         ( *codeGroup )->FromXml( rootElement );
         //</Snippet11>
      }

      Console::WriteLine( L"Added a custom membership condition:" );
      Console::WriteLine( rootElement );
   }

   // Print the properties of the specified code group to the console.
   static void PrintCodeGroup( CodeGroup^ codeGroup )
   {
      // Compare the type of the specified object with the
      // FirstMatchCodeGroup type.
      //<Snippet12>
      if (  !codeGroup->GetType()->Equals( FirstMatchCodeGroup::typeid ) )
      //</Snippet12>
      {
         throw gcnew ArgumentException( L"Expected the FirstMatchCodeGroup type." );
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
      if ( codeGroup->MergeLogic->Equals( L"First Match" ) )
      //</Snippet15>
      {
         mergeLogic = L"with first-match merge logic";
      }
      
      // Retrieve the class path for the FirstMatchCodeGroup.
      //<Snippet16>
      String^ firstMatchGroupClass = codeGroup->ToString();
      //</Snippet16>

      String^ attributeString = L"";
      // Retrieve the string representation of the FirstMatchCodeGroup's
      // attributes.
      //<Snippet5>
      if ( codeGroup->AttributeString != nullptr )
      {
         attributeString = codeGroup->AttributeString;
      }
      //</Snippet5>

      // Write a summary to the console window.
      Console::WriteLine( L"\n*** {0} summary ***", firstMatchGroupClass );
      Console::Write( L"A FirstMatchCodeGroup named " );
      Console::Write( L"{0}{1}", codeGroupName, mergeLogic );
      Console::Write( L" has been created with hash code({0}).", hashCode );
      Console::Write( L"\nThis code group contains a {0}", membershipCondition );
      Console::Write( L" membership condition with the " );
      Console::WriteLine( L"{0} permission set.", permissionSetName );

      Console::Write( L"The code group contains the following policy: " );
      Console::Write( ResolveEvidence( codeGroup ) );
      Console::Write( L"\nIt also contains the following attributes: " );
      Console::WriteLine( attributeString );

      int childCount = codeGroup->Children->Count;
      if ( childCount > 0 )
      {
         Console::Write( L"There are {0}", childCount );
         Console::WriteLine( L" child elements in the code group." );
         
         // Iterate through the child code groups to display their names
         // and then remove them from the specified code group.
         for ( int i = 0; i < childCount; i++ )
         {
            // Retrieve a child code group, which has been cast as a
            // FirstMatchCodeGroup type.
            //<Snippet21>
            FirstMatchCodeGroup^ childCodeGroup =
               dynamic_cast<FirstMatchCodeGroup^>(codeGroup->Children->default[ i ]);
            //</Snippet21>

            Console::Write( L"Removing the {0}.", childCodeGroup->Name );
            // Remove the child code group.
            //<Snippet17>
            codeGroup->RemoveChild( childCodeGroup );
            //</Snippet17>
         }
         Console::WriteLine();
      }
      else
      {
         Console::WriteLine( L" No child code groups were found in this"
         L" code group." );
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
//   <CustomMembershipCondition class="CustomMembershipCondition"
//                              version="1"
//                              domain="contoso.com"/>
// </CodeGroup>
//
// Comparing the resolved code group with the initial code group.
// The two code groups are not equal.
//
// *** System.Security.Policy.FirstMatchCodeGroup summary ***
// A FirstMatchCodeGroup named with first-match merge logic has been created
// with hash code(113151525).
// This code group contains a Zone - Intranet membership condition with the
// permission set.The code group contains the following policy:
// It also contains the following attributes:
// There are 1 child elements in the code group.
// Removing the Read-only code group.
// This sample completed successfully; press Enter to exit.
//</Snippet1>
