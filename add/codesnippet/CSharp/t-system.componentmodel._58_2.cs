    public static int Main() {
        // Creates a new control.
        MyControl myNewControl = new MyControl();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewControl);
     
        /* Prints the name of the default property by retrieving the 
         * DefaultPropertyAttribute from the AttributeCollection. */
        DefaultPropertyAttribute myAttribute = 
           (DefaultPropertyAttribute)attributes[typeof(DefaultPropertyAttribute)];
        Console.WriteLine("The default property is: " + myAttribute.Name);
      
        return 0;
     }