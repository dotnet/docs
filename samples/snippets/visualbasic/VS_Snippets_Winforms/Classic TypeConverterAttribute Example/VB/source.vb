Imports System
Imports System.IO
Imports System.ComponentModel



Public Class Class1
    
    ' <Snippet1>
    <TypeConverter(GetType(MyClassConverter))> _
    Public Class ClassA
        ' Insert code here.
    End Class 'MyClass
    ' </Snippet1>
    
    Public Class MyClassConverter
        Inherits TypeConverter
    End Class 'MyClassConverter
    
    ' <Snippet2>
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
    ' </Snippet2>
End Class 'Class1 
