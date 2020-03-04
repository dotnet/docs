
using namespace System;

// <Snippet2>
void main()
{
   String^ name = AppDomain::CurrentDomain->FriendlyName;
   Console::WriteLine( "MyExecutable running on {0}", name );
}

// </Snippet2>
