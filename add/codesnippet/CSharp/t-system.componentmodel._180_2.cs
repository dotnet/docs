    public static int Main() {
        // Creates a new form.
        MyForm myNewForm = new MyForm();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewForm);
     
        /* Prints the name of the designer by retrieving the DesignerAttribute
         * from the AttributeCollection. */
        DesignerAttribute myAttribute = 
           (DesignerAttribute)attributes[typeof(DesignerAttribute)];
        Console.WriteLine("The designer for this class is: " + myAttribute.DesignerTypeName);
      
        return 0;
    }