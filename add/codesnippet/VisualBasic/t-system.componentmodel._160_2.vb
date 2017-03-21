    Public Shared Function Main() As Integer
        ' Creates a new form.
        Dim myNewForm As New MyForm()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewForm)
        
        ' Prints the name of the designer by retrieving the DesignerAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DesignerAttribute = _
            CType(attributes(GetType(DesignerAttribute)), DesignerAttribute)
        Console.WriteLine(("The designer for this class is: " & myAttribute.DesignerTypeName))
        
        Return 0
    End Function 'Main