int main()
{
   // Creates a new control.
   Form1::MyControl^ myNewControl = gcnew Form1::MyControl;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewControl );

   /* Prints the name of the default property by retrieving the 
       * DefaultPropertyAttribute from the AttributeCollection. */
   DefaultPropertyAttribute^ myAttribute = dynamic_cast<DefaultPropertyAttribute^>(attributes[ DefaultPropertyAttribute::typeid ]);
   Console::WriteLine( "The default property is: {0}", myAttribute->Name );
   return 0;
}