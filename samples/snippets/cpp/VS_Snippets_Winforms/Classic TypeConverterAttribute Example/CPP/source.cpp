

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::ComponentModel;

public ref class Class1
{
public:
   ref class MyClassConverter: public TypeConverter{};

   // <Snippet1>
   [TypeConverter(Class1::MyClassConverter::typeid)]
   ref class MyClass{
      // Insert code here.
   };
   // </Snippet1>
};

// <Snippet2>
int main()
{
   // Creates a new instance of MyClass.
   Class1::MyClass^ myNewClass = gcnew Class1::MyClass;

   // Gets the attributes for the instance.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewClass );

   /* Prints the name of the type converter by retrieving the 
        * TypeConverterAttribute from the AttributeCollection. */
   TypeConverterAttribute^ myAttribute = dynamic_cast<TypeConverterAttribute^>(attributes[ TypeConverterAttribute::typeid ]);
   Console::WriteLine( "The type converter for this class is: {0}", myAttribute->ConverterTypeName );
   return 0;
}
// </Snippet2>
