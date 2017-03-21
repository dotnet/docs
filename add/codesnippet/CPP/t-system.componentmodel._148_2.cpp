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