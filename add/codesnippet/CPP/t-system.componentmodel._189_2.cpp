int main()
{
   // Creates a new form.
   MyForm^ myNewForm = gcnew MyForm;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewForm );

   /* Prints the name of the designer by retrieving the 
       * DesignerCategoryAttribute from the AttributeCollection. */
   DesignerCategoryAttribute^ myAttribute = dynamic_cast<DesignerCategoryAttribute^>(attributes[ DesignerCategoryAttribute::typeid ]);
   Console::WriteLine( "The category of the designer for this class is: {0}", myAttribute->Category );
   return 0;
}