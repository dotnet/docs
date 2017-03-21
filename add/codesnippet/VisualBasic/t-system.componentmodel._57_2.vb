    Public Shared Function Main() As Integer
        ' Creates a new control.
        Dim myNewControl As New MyControl()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewControl)
        
        ' Prints the name of the default property by retrieving the
        ' DefaultPropertyAttribute from the AttributeCollection. 
        Dim myAttribute As DefaultPropertyAttribute = _
            CType(attributes(GetType(DefaultPropertyAttribute)), DefaultPropertyAttribute)
        Console.WriteLine(("The default property is: " + myAttribute.Name))
        Return 0
    End Function 'Main
    