    Private Sub GetAttributeValue()
        ' Creates a new collection and assigns it the attributes for button1.
        Dim attributes As AttributeCollection
        attributes = TypeDescriptor.GetAttributes(button1)
        
        ' Gets the designer attribute from the collection.
        Dim myDesigner As DesignerAttribute
        myDesigner = CType(attributes(GetType(DesignerAttribute)), DesignerAttribute)
        
        ' Prints the value of the attribute in a text box.
        textBox1.Text = myDesigner.DesignerTypeName
    End Sub 'GetAttributeValue