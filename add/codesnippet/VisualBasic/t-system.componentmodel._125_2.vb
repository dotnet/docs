    Public Shared Function Main() As Integer
        ' Creates a new collection.
        Dim myNewCollection As New MyCollection()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewCollection)
        
        ' Prints the name of the default event by retrieving the
        ' DefaultEventAttribute from the AttributeCollection. 
        Dim myAttribute As DefaultEventAttribute = _
            CType(attributes(GetType(DefaultEventAttribute)), DefaultEventAttribute)
        Console.WriteLine(("The default event is: " & myAttribute.Name))
        Return 0
    End Function 'Main