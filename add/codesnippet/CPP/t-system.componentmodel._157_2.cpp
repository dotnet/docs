int main()
{
   // Creates a new form.
   MyForm^ myNewForm = gcnew MyForm;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewForm );

   /* Prints the name of the designer by retrieving the DesignerAttribute
       * from the AttributeCollection. */
   DesignerAttribute^ myAttribute = dynamic_cast<DesignerAttribute^>(attributes[ DesignerAttribute::typeid ]);
   Console::WriteLine( "The designer for this class is: {0}", myAttribute->DesignerTypeName );
   return 0;
}