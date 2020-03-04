//sdtree\CLR\System.Security.Permissions.ReflectionPermission

//<snippet1>
// ReflectionPermission.cpp : main project file.

using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Runtime::InteropServices;




void DisplayIntro()
{
    Console::WriteLine(
    "Welcome to the Reflection Permission Demo\n\n"
    "Background:  ReflectionPermission Class\n\n"
    "  1) Controls access to metadata through the System.Reflection APIs\n"
    "  2) Cannot be inherited\n"
    "  3) Contains a Flags Property:  Gets or sets the type of\n" 
    "       reflection allowed for the current permission.\n"
    "       Possible values are:\n\n"
    "       a.  ReflectionPermissionFlag::AllFlags\n"
    "       b.  ReflectionPermissionFlag::MemberAccess\n"
    "       c.  ReflectionPermissionFlag::RestrictedMemberAccess\n"
    "       d.  ReflectionPermissionFlag::NoFlags\n"
    "       e.  ReflectionPermissionFlag::ReflectionEmit\n"

    "  4) Supports the System.Security IPermissions interface.\n"
	"     The following members are demonstrated:\n\n"
    "       a.  IsSubsetOf  Determines whether the current permission is a subset\n"
	"                          of the specified permission\n\n"
    "       b.  Copy        Creates and returns an identical copy of the current\n"
	"                          permission\n\n"
    "       c.  Intersect   Creates and returns a permission that is the\n"
	"                          intersection of the current permission and the\n"
	"                          specified permission\n\n"
    "       d.  Union       Creates a permission that is the union of the\n"
	"                          current permission\n"
    "                          and the specified permission\n\n"
    "       e.  ToXml       When overridden in a derived class, creates an\n"
	"                          XML encoding of the\n"
    "                          security object and its current state.\n\n"
    "       f.  FromXML     When overridden in a derived class, reconstructs\n"
	"                          a security object with a specified state \n"
    "                          from an XML encoding\n\n"

    "Sample Introduction\n\n"
    "This sample consists of five small tests, illustrating the preceeding\n"
    "interface members.  In each test, two RelectionPermission objects are\n"
    "instantiated with various combinations of ReflectionPermissionFlag properties.\n"
    "These two objects are then compared with, or manipulated against, each other.\n\n");
}

int main()
{
    DisplayIntro();

    array<ReflectionPermissionFlag>^ aRPF =  {ReflectionPermissionFlag::AllFlags,
                                              ReflectionPermissionFlag::MemberAccess,
                                              ReflectionPermissionFlag::RestrictedMemberAccess,
                                              ReflectionPermissionFlag::NoFlags,
                                              ReflectionPermissionFlag::ReflectionEmit};

    int i,j;
    String^ spacer = "------------------------------------------------------\n";

    ReflectionPermission^ RP1, ^RP2, ^RP3;

    Console::WriteLine( "\n**********************  IsSubsetOf() Demo **********************\n" );
    for ( i=0;i<5;i++)
       {
       RP1 = gcnew ReflectionPermission( aRPF[i] );

       for ( j=0;j<5;j++)
            {
            RP2 = gcnew ReflectionPermission( aRPF[j] );
            Console::WriteLine("   {0} is {1}a subset of {2} ", RP2->Flags,
                               RP2->IsSubsetOf(RP1)?"":"not ", RP1->Flags);
            }
       Console::WriteLine(spacer);
       }


    Console::WriteLine( "\n*************************  Copy Demo() *************************\n" );
    for ( i=0;i<5;i++)
       {
       RP1 = gcnew ReflectionPermission( aRPF[i] );

       for ( j=0;j<5;j++)
            {
            RP2 = gcnew ReflectionPermission( aRPF[j] );
            Console::WriteLine("   {0} is {1}a subset of {2} ", RP2->Flags,
                               RP2->IsSubsetOf(RP1)?"":"not ", RP1->Flags);
            }
       Console::WriteLine(spacer);
       }


    Console::WriteLine( "\n*********************  Intersection() Demo *********************\n" );
    for ( i=0;i<5;i++)
       {
       RP1 = gcnew ReflectionPermission( aRPF[i] );

       for ( j=0;j<5;j++)
            {
            RP2 = gcnew ReflectionPermission( aRPF[j] );
            RP3 = dynamic_cast<ReflectionPermission^>(RP1->Intersect( RP2 ));
            if ( RP3 != nullptr )
               Console::WriteLine( "The intersection of {0} and {1} = {2}", RP1->Flags, RP2->Flags,
                                    (dynamic_cast<ReflectionPermission^>(RP3))->Flags );
            else
               Console::WriteLine( "The intersection of {0} and {1} is null", RP1->Flags, RP2->Flags );
            }
       Console::WriteLine(spacer);
       }


    Console::WriteLine( "\n************************  Union() Demo *************************\n" );
    for ( i=0;i<5;i++)
       {
       RP1 = gcnew ReflectionPermission( aRPF[i] );

       for ( j=0;j<5;j++)
            {
            RP2 = gcnew ReflectionPermission( aRPF[j] );
            RP3 = dynamic_cast<ReflectionPermission^>(RP1->Union( RP2 ));
            if ( RP3 != nullptr )
               Console::WriteLine( "The union of {0} and {1} = {2}", RP1->Flags, RP2->Flags,
                                    (dynamic_cast<ReflectionPermission^>(RP3))->Flags );
            else
               Console::WriteLine( "The union of {0} and {1} is null", RP1->Flags, RP2->Flags );
            }
       Console::WriteLine(spacer);
       }


    Console::WriteLine( "\n*******************  ToXml() and FromXml Demo ******************\n" );
    RP1 = gcnew ReflectionPermission( aRPF[1] );
    Console::WriteLine( "RP1->ToXml = {0}", RP1->ToXml() );
                                                                // Next 2 lines are identical
    RP2 = gcnew ReflectionPermission( PermissionState::None );  // Sets the NoFlag state
//  RP2 = gcnew ReflectionPermission( aRPF[2] );                // Explicitely sets the NoFlag state
    Console::WriteLine( "RP2->ToXml = {0}", RP2->ToXml() );
    RP2->FromXml( RP1->ToXml() );
    Console::WriteLine( "RP2:   RP2->FromXml( RP1->ToXml() ) = {0}", RP2 );
    Console::WriteLine( "Note:  RP2 Flag changed from NoFlags to MemberAccess", RP2 );


    Console::WriteLine("\n\nHit ENTER to return");
    Console::ReadLine();
}
//</snippet1>