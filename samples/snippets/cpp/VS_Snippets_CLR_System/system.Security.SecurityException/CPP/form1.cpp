
#using "System.Data.dll"

//<Snippet1>
using namespace System;
using namespace System::Data;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Policy;
using namespace System::Reflection;
using namespace System::Runtime::Serialization;

namespace SecurityExceptionSample
{
    [assembly:KeyContainerPermissionAttribute(
        SecurityAction::RequestRefuse,
        Flags=KeyContainerPermissionFlags::Import)];
    ref class TestSecurityException
    {
    public:
        void MakeTest()
        {
            try
            {
                // Deny a permission.
                KeyContainerPermission^ keyContainerDecryptPermission =
                    gcnew KeyContainerPermission(
                    KeyContainerPermissionFlags::Decrypt);
                keyContainerDecryptPermission->Deny();
                
                // Demand the denied permission and display
                // the exception properties.
                Display("Demanding a denied permission. \n\n");
                DemandDeniedPermission();
                Display("*******************************************"
                    "**************\n");
                CodeAccessPermission::RevertDeny();
                
                // Demand the permission refused
                // in the assembly-level attribute.
                Display("Demanding a refused permission. \n\n");
                DemandRefusedPermission();
                Display("*******************************************"
                    "**************\n");
                
                // Demand the permission implicitly refused through a
                // PermitOnly attribute. Permit only the permission that
                // will cause the failure and the security permissions
                // necessary to display the results of the failure.
                PermissionSet^ permitOnlySet = gcnew PermissionSet(
                    PermissionState::None);
                permitOnlySet->AddPermission(gcnew KeyContainerPermission(
                    KeyContainerPermissionFlags::Import));
                permitOnlySet->AddPermission(gcnew SecurityPermission(
                    SecurityPermissionFlag::ControlEvidence |
                    SecurityPermissionFlag::ControlPolicy |
                    SecurityPermissionFlag::SerializationFormatter));
                permitOnlySet->PermitOnly();
                Display("Demanding an implicitly refused permission. \n\n");
                DemandPermitOnly();
            }
            catch (SecurityException^ exception)
            {
                Display("*******************************************"
                    "**************\n");
                
                //<Snippet17>
                Display("Displaying an exception using the ToString "
                    "method: ");
                Display(exception->ToString());
                //</Snippet17>
            }

        }

    private:
        void DemandDeniedPermission()
        {
            try
            {
                KeyContainerPermission^ keyContainerDecryptPermission =
                    gcnew KeyContainerPermission(
                    KeyContainerPermissionFlags::Decrypt);
                keyContainerDecryptPermission->Demand();
            }
            catch (SecurityException^ exception)
            {
                //<Snippet2>
                Display("The denied permission is: {0}",
                    exception->DenySetInstance);
                //</Snippet2>

                //<Snippet3>
                Display("The demanded permission is: {0}",
                    exception->Demanded);
                //</Snippet3>

                //<Snippet4>
                Display("The security action is: {0}",
                    exception->Action);
                //</Snippet4>

                //<Snippet5>
                Display("The method is: {0}", exception->Method);
                //</Snippet5>

                //<Snippet6>
                Display("The permission state at the time "
                    "of the exception was: {0}",
                    exception->PermissionState);
                //</Snippet6>

                //<Snippet7>
                Display("The permission that failed was: {0}",
                    exception->FirstPermissionThatFailed);
                //</Snippet7>

                //<Snippet8>
                Display("The permission type is: {0}",
                    exception->PermissionType);
                //</Snippet8>

                //<Snippet9>
                Display("Demonstrating the use of the GetObjectData "
                    "method.");
                SerializationInfo^ entryPointSerializatonInfo =
                    gcnew SerializationInfo(TestSecurityException::typeid,
                    gcnew FormatterConverter);
                exception->GetObjectData(entryPointSerializatonInfo,
                    *gcnew StreamingContext(StreamingContextStates::All));
                Display("The FirstPermissionThatFailed from the call"
                    " to GetObjectData is: ");
                Display(entryPointSerializatonInfo->GetString(
                    "FirstPermissionThatFailed"));
                //</Snippet9>
            }
        }

        void DemandRefusedPermission()
        {
            try
            {
                KeyContainerPermission^ keyContainerImportPermission =
                    gcnew KeyContainerPermission(
                    KeyContainerPermissionFlags::Import);
                keyContainerImportPermission->Demand();
            }
            catch (SecurityException^ exception)
            {            
                //<Snippet10>
                Display("The refused permission set is: {0}",
                    exception->RefusedSet);
                //</Snippet10>

                //<Snippet11>
                Display("The exception message is: {0}",
                    exception->Message);
                //</Snippet11>

                //<Snippet12>
                Display("The failed assembly is: {0}",
                    exception->FailedAssemblyInfo->EscapedCodeBase);
                //</Snippet12>

                //<Snippet13>
                Display("The granted set is: \n{0}",
                    exception->GrantedSet);
                //</Snippet13>

                Display("The permission that failed is: {0}",
                    exception->FirstPermissionThatFailed);
                Display("The permission type is: {0}",
                    exception->PermissionType);

                //<Snippet14>
                Display("The source is: {0}", exception->Source);
                //</Snippet14>
            }
        }

        void DemandPermitOnly()
        {
            try
            {
                KeyContainerPermission^ keyContainerDecryptPermission =
                    gcnew KeyContainerPermission(
                    KeyContainerPermissionFlags::Decrypt);
                keyContainerDecryptPermission->Demand();
            }
            catch (SecurityException^ exception)
            {
                //<Snippet15>
                Display("The permitted permission is: {0}",
                    exception->PermitOnlySetInstance);
                //</Snippet15>
                Display("The demanded permission is: {0}",
                    exception->Demanded);
                Display("The security action is: {0}",
                    exception->Action);
                Display("The method is: {0}", exception->Method);
                Display("The permission state at the time of the "
                    "exception was: {0}", exception->PermissionState);
                Display("The permission that failed was: {0}",
                    exception->FirstPermissionThatFailed);
                Display("The permission type is: {0}",
                    exception->PermissionType);

                //<Snippet16>
                // Demonstrate the SecurityException constructor
                // by throwing the exception again.
                Display("Rethrowing the exception thrown as a "
                    "result of a PermitOnly security action.");
                throw gcnew SecurityException(exception->Message,
                    exception->DenySetInstance,
                    exception->PermitOnlySetInstance,
                    exception->Method, exception->Demanded,
                    exception->FirstPermissionThatFailed);
                //</Snippet16>
                }
        }

        void Display(String^ line)
        {
            Console::WriteLine(line);
        }

        void Display(String^ format, Object^ arg)
        {
            Console::WriteLine(format, arg);
        }
    };
}

using namespace SecurityExceptionSample;

int main()
{
    TestSecurityException^ test = gcnew TestSecurityException;
    test->MakeTest();
    Console::WriteLine("Press the enter key to exit.");
    Console::Read();
}
//</Snippet1>
