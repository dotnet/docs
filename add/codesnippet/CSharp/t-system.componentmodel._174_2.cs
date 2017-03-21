    public static int Main() {
        // Creates a new form.
        MyForm myNewForm = new MyForm();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewForm);
     
        /* Prints the name of the designer by retrieving the 
         * DesignerCategoryAttribute from the AttributeCollection. */
        DesignerCategoryAttribute myAttribute = 
           (DesignerCategoryAttribute)attributes[typeof(DesignerCategoryAttribute)];
        Console.WriteLine("The category of the designer for this class is: " + myAttribute.Category);
      
        return 0;
    }