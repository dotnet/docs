

// <Snippet1>
#using <System.DLL>

using namespace System;
using namespace System::Reflection;

#define NULL 0
void main()
{
   Type^ tDate = Type::GetType( L"System.DateTime" );
   Object^ result = tDate->InvokeMember( L"Now", BindingFlags::GetProperty, nullptr, NULL, gcnew array<Object^>(0) );
   Console::WriteLine( result->ToString() );
}

// </Snippet1>
