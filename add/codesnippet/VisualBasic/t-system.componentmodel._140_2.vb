    Public Shared Function Main() As Integer
        ' Creates a new instance of ClassA.
        Dim myNewClass As New ClassA()
        
        ' Gets the attributes for the instance.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewClass)
        
        ' Prints the name of the type converter by retrieving the
        ' TypeConverterAttribute from the AttributeCollection. 
        Dim myAttribute As TypeConverterAttribute = _
            CType(attributes(GetType(TypeConverterAttribute)), TypeConverterAttribute)
        
        Console.WriteLine(("The type conveter for this class is: " _
            + myAttribute.ConverterTypeName))
        Return 0
    End Function 'Main