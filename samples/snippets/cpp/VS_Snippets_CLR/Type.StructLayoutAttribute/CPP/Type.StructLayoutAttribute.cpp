
//<Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;
value struct Test1
{
public:
   Byte B1;
   short S;
   Byte B2;
};


[StructLayout(LayoutKind::Explicit,Pack=1)]
value struct Test2
{
public:

   [FieldOffset(0)]
   Byte B1;

   [FieldOffset(1)]
   short S;

   [FieldOffset(3)]
   Byte B2;
};

static void DisplayLayoutAttribute( StructLayoutAttribute^ sla )
{
   Console::WriteLine( L"\r\nCharSet: {0}\r\n   Pack: {1}\r\n   Size: {2}\r\n  Value: {3}", sla->CharSet, sla->Pack, sla->Size, sla->Value );
}

int main()
{
   DisplayLayoutAttribute( Test1::typeid->StructLayoutAttribute );
   return 0;
}

//</Snippet1>
