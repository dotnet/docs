
//<Snippet1>
// Example for the OperatingSystem::Clone method.
using namespace System;

// Copy, clone, and duplicate an OperatingSystem object.
void CopyOperatingSystemObjects()
{
   
   // The Version object does not need to correspond to an 
   // actual OS version.
   Version^ verMMBVer = gcnew Version( 5,6,7,8 );
   OperatingSystem^ opCreate1 = gcnew OperatingSystem( PlatformID::Win32NT,verMMBVer );
   
   // Create another OperatingSystem object with the same 
   // parameters as opCreate1.
   OperatingSystem^ opCreate2 = gcnew OperatingSystem( PlatformID::Win32NT,verMMBVer );
   
   // Clone opCreate1 and copy the opCreate1 reference.
   OperatingSystem^ opClone = safe_cast<OperatingSystem^>(opCreate1->Clone());
   OperatingSystem^ opCopy = opCreate1;
   
   // Compare the various objects for equality.
   Console::WriteLine( "{0,-50}{1}", "Is the second object the same as the original?", opCreate1->Equals( opCreate2 ) );
   Console::WriteLine( "{0,-50}{1}", "Is the object clone the same as the original?", opCreate1->Equals( opClone ) );
   Console::WriteLine( "{0,-50}{1}", "Is the copied object the same as the original?", opCreate1->Equals( opCopy ) );
}

int main()
{
   Console::WriteLine( "This example of OperatingSystem::Clone( ) "
   "generates the following output.\n" );
   Console::WriteLine( "Create an OperatingSystem object, and then "
   "create another object with the \n"
   "same parameters. Clone and copy the original "
   "object, and then compare \n"
   "each object with the original "
   "using the Equals( ) method. Equals( ) \n"
   "returns true only when both "
   "references refer to the same object.\n" );
   CopyOperatingSystemObjects();
}

/*
This example of OperatingSystem::Clone( ) generates the following output.

Create an OperatingSystem object, and then create another object with the
same parameters. Clone and copy the original object, and then compare
each object with the original using the Equals( ) method. Equals( )
returns true only when both references refer to the same object.

Is the second object the same as the original?    False
Is the object clone the same as the original?     False
Is the copied object the same as the original?    True
*/
//</Snippet1>
