int main()
{
   // Creates a new component.
   MyControl^ myNewControl = gcnew MyControl;

   // Gets the attributes for the component.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewControl );

   /* Prints the name of the license provider by retrieving the LicenseProviderAttribute 
        * from the AttributeCollection. */
   LicenseProviderAttribute^ myAttribute = dynamic_cast<LicenseProviderAttribute^>(attributes[ LicenseProviderAttribute::typeid ]);
   Console::WriteLine( "The license provider for this class is: {0}", myAttribute->LicenseProvider );
   return 0;
}