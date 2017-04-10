Imports System
Imports System.Drawing
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Class1
    
    ' <Snippet1>
    <Editor("System.Windows.Forms.ImageEditorIndex, System.Design", _
        GetType(UITypeEditor))> _
    Public Class MyImage
        ' Insert code here.
    End Class 'MyImage
    ' </Snippet1>
    ' <Snippet2>
    Public Shared Sub Main()
        ' Creates a new component.
        Dim myNewImage As New MyImage()
        
        ' Gets the attributes for the component.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewImage)
        
        ' Prints the name of the editor by retrieving the EditorAttribute
        ' from the AttributeCollection. 
        
        Dim myAttribute As EditorAttribute = CType(attributes(GetType(EditorAttribute)), EditorAttribute)
        Console.WriteLine(("The editor for this class is: " & myAttribute.EditorTypeName))

    End Sub 'Main
    ' </Snippet2>
End Class 'Class1 
