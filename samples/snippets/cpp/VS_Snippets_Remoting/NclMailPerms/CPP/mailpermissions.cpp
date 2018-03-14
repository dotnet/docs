
// NCLMailPerms
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Mail;
using namespace System::Net::Mime;
using namespace System::Security::Permissions;

namespace SmtpPermissionsExamples
{
    public ref class TestSmtpPermissions
    {
    public:
        // <snippet1>
        static SmtpPermission^ CreateConnectPermission()
        {
            SmtpPermission^ connectAccess = 
                gcnew SmtpPermission(SmtpAccess::Connect);
            Console::WriteLine("Access? {0}", connectAccess->Access);
            return connectAccess;
        }
        // </snippet1>

        // <snippet2>
        static SmtpPermission^ CreateUnrestrictedPermission()
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            Console::WriteLine("Is unrestricted? {0}", 
                allAccess->IsUnrestricted());
            return allAccess;
        }
        // </snippet2>

        //<snippet3>
        static SmtpPermission^ CreatePermissionCopy(SmtpPermission^ p)
        {
            SmtpPermission^ copy = (SmtpPermission^) p->Copy();
            return copy;
        }
        //</snippet3>

        // <snippet4>
        static SmtpPermission^ CreateUnrestrictedPermission2()
        {
            SmtpPermission^ allAccess = gcnew SmtpPermission(true);
            Console::WriteLine("Is unrestricted? {0}", 
                allAccess->IsUnrestricted());
            return allAccess;
        }
        // </snippet4>

        // <snippet5>
        static SmtpPermission^ GiveFullAccess(
            SmtpPermission^ permission)
        {
            permission->AddPermission(SmtpAccess::Connect);
            return permission;
        }
        // </snippet5>

        // <snippet6>
        static SmtpPermission^ IntersectionWithFull(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return (SmtpPermission^) permission->Intersect(allAccess);
        }
        // </snippet6>

        // <snippet7>
        static bool CheckSubSet(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return permission->IsSubsetOf(allAccess);
        }
        // </snippet7>

        // <snippet8>
        static SmtpPermission^ UnionWithFull(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return (SmtpPermission^) permission->Union(allAccess);
        }
        // </snippet8>
    };
};

int main()
{
}