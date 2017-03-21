    Public Shared Function Main() As Integer
        ' Creates a new form.
        Dim myNewForm As New MyForm()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewForm)
        
        ' Prints the name of the designer by retrieving the
        ' DesignerCategoryAttribute from the AttributeCollection. 
        Dim myAttribute As DesignerCategoryAttribute = _
            CType(attributes(GetType(DesignerCategoryAttribute)), DesignerCategoryAttribute)
        Console.WriteLine(("The category of the designer for this class is: " + myAttribute.Category))
        Return 0
    End Function 'Main