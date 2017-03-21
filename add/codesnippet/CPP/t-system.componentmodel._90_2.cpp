int main()
{
   // Creates a new installer.
   MyProjectInstaller^ myNewProjectInstaller = gcnew MyProjectInstaller;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewProjectInstaller );

   /* Prints whether to run the installer by retrieving the 
       * RunInstallerAttribute from the AttributeCollection. */
   RunInstallerAttribute^ myAttribute = dynamic_cast<RunInstallerAttribute^>(attributes[ RunInstallerAttribute::typeid ]);
   Console::WriteLine( "Run the installer? {0}", myAttribute->RunInstaller );
   return 0;
}