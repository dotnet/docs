    public static int Main() {
        // Creates a new component.
        MyControl myNewControl = new MyControl();
     
        // Gets the attributes for the component.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewControl);
     
        /* Prints the name of the license provider by retrieving the LicenseProviderAttribute 
         * from the AttributeCollection. */
        LicenseProviderAttribute myAttribute = (LicenseProviderAttribute)attributes[typeof(LicenseProviderAttribute)];
        Console.WriteLine("The license provider for this class is: " + myAttribute.LicenseProvider.ToString());
     
        return 0;
     }