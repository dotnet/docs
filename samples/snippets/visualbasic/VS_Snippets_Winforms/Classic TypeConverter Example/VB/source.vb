Imports System
Imports System.Drawing
Imports System.ComponentModel



Public Class Sample
    
    ' <Snippet1>
    <TypeConverter(GetType(MyClassConverter))> _
    Public Class Class1
        ' Insert code here.
    End Class 'MyClass
    
    ' </Snippet1>
    Public Enum MyPropertyEnum
        option1
        option2
        option3
    End Enum 'MyPropertyEnum
    
    Public Class MyClassConverter
    End Class 'MyClassConverter
    
    ' <Snippet2>
    
    Public WriteOnly Property MyProperty() As MyPropertyEnum
        Set
            ' Checks to see if the value passed is valid.
            If Not TypeDescriptor.GetConverter(GetType(MyPropertyEnum)).IsValid(value) Then
                Throw New ArgumentException()
            End If
            ' The value is valid. Insert code to set the property.
        End Set 
    End Property
    
    ' </Snippet2>
    Public Sub Method1()
        ' <Snippet3>
        Dim c As Color = Color.Red
        Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c))
        ' </Snippet3>
    End Sub 'Method1
     
    Public Sub Method2()
        ' <Snippet4>
        Dim c As Color = CType(TypeDescriptor.GetConverter(GetType(Color)).ConvertFromString("Red"), Color)
        ' </Snippet4>
    End Sub 'Method2
     
    
    Public Sub Method3()
        ' <Snippet5>
        Dim c As Color
        For Each c In  TypeDescriptor.GetConverter(GetType(Color)).GetStandardValues()
            Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c))
        Next c
        ' </Snippet5>
    End Sub 'Method3 
End Class 'Sample
