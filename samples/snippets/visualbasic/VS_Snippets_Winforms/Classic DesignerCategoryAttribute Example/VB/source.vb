Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms



Public Class Class1
    
    ' <Snippet1>
    <Designer("System.Windows.Forms.Design.DocumentDesigner, System.Windows.Forms.Design", _
        GetType(IRootDesigner)), DesignerCategory("Form")> _
    Public Class MyForm
        
        Inherits ContainerControl
        ' Insert code here.
    End Class 'MyForm
    ' </Snippet1>
    ' <Snippet2>
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
    ' </Snippet2>
End Class 'Class1 
