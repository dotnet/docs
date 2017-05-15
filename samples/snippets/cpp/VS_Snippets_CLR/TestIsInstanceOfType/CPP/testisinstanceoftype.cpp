
//<Snippet1>
using namespace System;

public interface class IExample{};

public ref class BaseClass: IExample{};

public ref class DerivedClass: BaseClass{};

void main()
{
   Type^ interfaceType = IExample::typeid;
   BaseClass^ base1 = gcnew BaseClass;
   Type^ base1Type = base1->GetType();
   BaseClass^ derived1 = gcnew DerivedClass;
   Type^ derived1Type = derived1->GetType();
   array<Int32>^ arr = gcnew array<Int32>(11);
   Type^ arrayType = Array::typeid;

   Console::WriteLine("Is Int32[] an instance of the Array class? {0}.",
                      arrayType->IsInstanceOfType( arr ) );
   Console::WriteLine("Is myclass an instance of BaseClass? {0}.",
                      base1Type->IsInstanceOfType( base1 ) );
   Console::WriteLine("Is myderivedclass an instance of BaseClass? {0}.",
                      base1Type->IsInstanceOfType( derived1 ) );
   Console::WriteLine("Is myclass an instance of IExample? {0}.",
                      interfaceType->IsInstanceOfType( base1 ) );
   Console::WriteLine("Is myderivedclass an instance of IExample? {0}.",
                      interfaceType->IsInstanceOfType( derived1 ) );
}
// The example displays the following output:
//    Is int[] an instance of the Array class? True.
//    Is base1 an instance of BaseClass? True.
//    Is derived1 an instance of BaseClass? True.
//    Is base1 an instance of IExample? True.
//    Is derived1 an instance of IExample? True.
//</Snippet1>
