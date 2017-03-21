int main()
{
   // Creates a new component.
   MyImage^ myNewImage = gcnew MyImage;

   // Gets the attributes for the component.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewImage );

   /* Prints the name of the editor by retrieving the EditorAttribute 
       * from the AttributeCollection. */
   EditorAttribute^ myAttribute = dynamic_cast<EditorAttribute^>(attributes[ EditorAttribute::typeid ]);
   Console::WriteLine( "The editor for this class is: {0}", myAttribute->EditorTypeName );
   return 0;
}