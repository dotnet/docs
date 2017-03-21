    public static int Main() {
        // Creates a new collection.
        MyCollection myNewCollection = new MyCollection();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewCollection);
     
        /* Prints the name of the default event by retrieving the 
         * DefaultEventAttribute from the AttributeCollection. */
        DefaultEventAttribute myAttribute = 
           (DefaultEventAttribute)attributes[typeof(DefaultEventAttribute)];
        Console.WriteLine("The default event is: " + myAttribute.Name);
        return 0;
     }