// This sample demonstrates how to use each member of the PolicyStatement
// class.
//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Security::Principal;
using namespace System::Security::Permissions;

ref class Members
{
public:
   [STAThread]
   static void Main()
   {
      // Create two new policy statements.
      PolicyStatement^ policyStatement = firstConstructorTest();
      PolicyStatement^ policyStatement2 = secondConstructorTest();
      
      // Add attributes to the first policy statement.
      //<Snippet4>
      policyStatement->Attributes = PolicyStatementAttribute::All;
      //</Snippet4>

      // Create a copy of the first policy statement.
      PolicyStatement^ policyStatementCopy = createCopy( policyStatement );
      addXmlMember(  &policyStatementCopy );

      summarizePolicyStatment( policyStatement );
      Console::Write( L"This sample completed successfully; " );
      Console::WriteLine( L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Construct a PolicyStatement with an Unrestricted permission set.
   static PolicyStatement^ firstConstructorTest()
   {
      // Construct the permission set.
      //<Snippet2>
      PermissionSet^ permissions = gcnew PermissionSet(
         PermissionState::Unrestricted );
      permissions->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      permissions->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );
      
      // Create a policy statement based on the newly created permission
      // set.
      PolicyStatement^ policyStatement = gcnew PolicyStatement(
         permissions );
      //</Snippet2>

      return policyStatement;
   }

   // Construct a PolicyStatement with an Unrestricted permission set and
   // the LevelFinal attribute.
   static PolicyStatement^ secondConstructorTest()
   {
      // Construct the permission set.
      //<Snippet3>
      PermissionSet^ permissions = gcnew PermissionSet(
         PermissionState::Unrestricted );
      permissions->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      permissions->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );

      PolicyStatementAttribute levelFinalAttribute =
         PolicyStatementAttribute::LevelFinal;
      
      // Create a new policy statement with the specified permission set.
      // The LevelFinal attribute is set to prevent the evaluation of lower
      // policy levels in a resolve operation.
      PolicyStatement^ policyStatement = gcnew PolicyStatement(
         permissions,levelFinalAttribute );
      //</Snippet3>

      return policyStatement;
   }

   // Add a named permission set to the specified PolicyStatement.
   static void AddPermissions( interior_ptr<PolicyStatement^>policyStatement )
   {
      // Construct a NamedPermissionSet with basic permissions.
      //<Snippet5>
      NamedPermissionSet^ allPerms = gcnew NamedPermissionSet(
         L"allPerms" );
      allPerms->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      allPerms->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );
      allPerms->AddPermission( gcnew SiteIdentityPermission(
         L"www.contoso.com" ) );

      ( *policyStatement)->PermissionSet = allPerms;
      //</Snippet5>
   }

   // If a class attribute is not found in the specified PolicyStatement,
   // add a child XML element with an added class attribute.
   static void addXmlMember( interior_ptr<PolicyStatement^>policyStatement )
   {
      //<Snippet6>
      SecurityElement^ xmlElement = ( *policyStatement)->ToXml();
      //</Snippet6>
      if ( xmlElement->Attribute(L"class") == nullptr )
      {
         //<Snippet7>
         SecurityElement^ newElement = gcnew SecurityElement(
            L"PolicyStatement" );
         newElement->AddAttribute( L"class", (
            *policyStatement)->ToString() );
         newElement->AddAttribute( L"version", L"1.1" );

         newElement->AddChild( gcnew SecurityElement( L"PermissionSet" ) );

         ( *policyStatement)->FromXml( newElement );
         //</Snippet7>

         Console::Write( L"Added the class attribute and modified its " );
         Console::WriteLine( L"version number.\n{0}", newElement );
      }
   }

   // Verify that the type of the specified object is a PolicyStatement type
   // then create a copy of the object.
   static PolicyStatement^ createCopy( Object^ sourceObject )
   {
      PolicyStatement^ returnedStatement = gcnew PolicyStatement( nullptr );
      // Compare specified object type with the PolicyStatement type.
      //<Snippet8>
      if ( sourceObject->GetType()->Equals( PolicyStatement::typeid ) )
      //</Snippet8>
      {
         returnedStatement = getCopy(
            static_cast<PolicyStatement^>(sourceObject) );
      }
      else
      {
         throw gcnew ArgumentException(
            L"Expected the PolicyStatement type." );
      }

      return returnedStatement;
   }

   // Return a copy of the specified PolicyStatement if the result of the
   // Copy command is an equivalent object. Otherwise, return the
   // original PolicyStatement object.
   static PolicyStatement^ getCopy( PolicyStatement^ policyStatement )
   {
      // Create an equivalent copy of the policy statement.
      //<Snippet9>
      PolicyStatement^ policyStatementCopy = policyStatement->Copy();
      //</Snippet9>

      // Compare the specified objects for equality.
      //<Snippet10>
      if (  !policyStatementCopy->Equals( policyStatement ) )
      //</Snippet10>
      {
         return policyStatementCopy;
      }
      else
      {
         return policyStatement;
      }
   }

   // Summarize the attributes of the specified PolicyStatement on the
   // console window.
   static void summarizePolicyStatment( PolicyStatement^ policyStatement )
   {
      // Retrieve the class path for policyStatement.
      //<Snippet11>
      String^ policyStatementClass = policyStatement->ToString();
      //</Snippet11>

      //<Snippet12>
      int hashCode = policyStatement->GetHashCode();
      //</Snippet12>

      String^ attributeString = L"";
      
      // Retrieve the string representation of the PolicyStatement
      // attributes.
      //<Snippet13>
      if ( policyStatement->AttributeString != nullptr )
      {
         attributeString = policyStatement->AttributeString;
      }
      //</Snippet13>

      // Write a summary to the console window.
      Console::WriteLine( L"\n*** {0} summary ***", policyStatementClass );
      Console::Write( L"This PolicyStatement has been created with hash " );
      Console::Write( L"code({0}) ", hashCode );

      Console::Write( L"and contains the following attributes: " );
      Console::WriteLine( attributeString );
   }
};

int main()
{
   Members::Main();
}

//
// This sample produces the following output:
//
// Added the class attribute and modified the version number.
// <PolicyStatement class="System.Security.Policy.PolicyStatement"
//                  version="1.1">
//    <PermissionSet/>
// </PolicyStatement>
//
// *** System.Security.Policy.PolicyStatement summary ***
// PolicyStatement has been created with hash code(20) containing the
// following attributes: Exclusive LevelFinal
// This sample completed successfully; press Enter to exit.
//</Snippet1>
