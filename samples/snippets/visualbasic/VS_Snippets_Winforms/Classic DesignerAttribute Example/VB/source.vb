Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms



Public Class Class1
    
    ' <Snippet1>
    <Designer("System.Windows.Forms.Design.DocumentDesigner, System.Windows.Forms.Design.DLL", _
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
        
        ' Prints the name of the designer by retrieving the DesignerAttribute
        ' from the AttributeCollection. 
        Dim myAttribute As DesignerAttribute = _
            CType(attributes(GetType(DesignerAttribute)), DesignerAttribute)
        Console.WriteLine(("The designer for this class is: " & myAttribute.DesignerTypeName))
        
        Return 0
    End Function 'Main
    ' </Snippet2>
End Class 'Class1 
