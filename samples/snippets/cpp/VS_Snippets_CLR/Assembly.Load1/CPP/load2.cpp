// <Snippet2>
using namespace System;
using namespace System::Reflection;

ref class Class1
{
public:
    static void Main()
    {
        // You must supply a valid fully qualified assembly name.
        // <Snippet3>
        Assembly^ myDll =
            Assembly::Load("myDll, Version=1.0.0.1, Culture=neutral, PublicKeyToken=9b35aa32c18d4fb1");
        // </Snippet3>

        // Display all the types contained in the specified assembly.
		for each (Type^ oType in myDll->GetTypes()) {
            Console::WriteLine(oType->Name);
        }
    }
};

int main()
{
    Class1::Main();
}
// </Snippet2>