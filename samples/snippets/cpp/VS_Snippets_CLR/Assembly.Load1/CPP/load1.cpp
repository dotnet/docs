
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;
int main()
{
    // You must supply a valid fully qualified assembly name.            
    Assembly^ SampleAssembly = Assembly::Load
        ( "SampleAssembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3" );
    array<Type^>^ Types = SampleAssembly->GetTypes();
    
    // Display all the types contained in the specified assembly.
    IEnumerator^ myEnum = Types->GetEnumerator();
    Type^ oType;
    while ( myEnum->MoveNext() )
    {
        oType = safe_cast<Type^>(myEnum->Current);
        Console::WriteLine( oType->Name );
    }
}

// </Snippet1>
