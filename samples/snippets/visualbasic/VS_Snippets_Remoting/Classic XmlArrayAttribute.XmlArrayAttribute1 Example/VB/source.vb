' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class MyClass1
    <XmlArrayAttribute("MyStrings")> _
        Public MyStringArray() As String

    <XmlArrayAttribute(ElementName := "MyIntegers")> _
        Public MyIntegerArray() As Integer
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("MyClass.xml")
    End Sub    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Creates a new instance of the XmlSerializer class.
        Dim s As New XmlSerializer(GetType(MyClass1))
        ' Needed a StreamWriter to write the file.
        Dim myWriter As New StreamWriter(filename)
        
        Dim class1 As New MyClass1()
        ' Creates and populates a string array, then assigns
        ' it to the MyStringArray property.
        Dim myStrings() As String =  {"Hello", "World", "!"}
        class1.MyStringArray = myStrings
        ' Creates and populates an integer array, and assigns
        ' it to the MyIntegerArray property.
        Dim myIntegers() As Integer =  {1, 2, 3}
        class1.MyIntegerArray = myIntegers
        ' Serializes the class, and writes it to disk.
        s.Serialize(myWriter, class1)
        myWriter.Close()
    End Sub
End Class

' </Snippet1>
