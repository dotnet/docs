' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic


' Make two fields.
Public Class Myfielda
    ' Make a private field.
    Private SomeField As String = "private field"

    Public ReadOnly Property Field() As String
        Get
            Return SomeField
        End Get
    End Property
End Class 'Myfielda

Public Class Myfieldb
    ' Make a public field.
    Public SomeField As String = "public field"
End Class 'Myfieldb

Public Class Myfieldinfo

    Public Shared Function Main() As Integer
        Console.WriteLine("Reflection.FieldInfo")
        Console.WriteLine()
        Dim Myfielda As New Myfielda()
        Dim Myfieldb As New Myfieldb()

        ' Get the Type and FieldInfo.
        Dim MyTypea As Type = GetType(Myfielda)
        Dim Myfieldinfoa As FieldInfo = MyTypea.GetField("SomeField", _
            BindingFlags.NonPublic Or BindingFlags.Instance)
        Dim MyTypeb As Type = GetType(Myfieldb)
        Dim Myfieldinfob As FieldInfo = MyTypeb.GetField("SomeField")

        ' Get and display the IsPublic and IsPrivate property values.
        Console.WriteLine("{0}.{1} - {2}", MyTypea.FullName, Myfieldinfoa.Name, _
            Myfielda.Field)
        Console.WriteLine("   IsPublic = {0}", Myfieldinfoa.IsPublic)
        Console.WriteLine("   IsPrivate = {0}", Myfieldinfoa.IsPrivate)
        Console.WriteLine()
        Console.WriteLine("{0}.{1} - {2}", MyTypeb.FullName, Myfieldinfob.Name, _
            Myfieldb.SomeField)
        Console.WriteLine("   IsPublic = {0}", Myfieldinfob.IsPublic)
        Console.WriteLine("   IsPrivate = {0}", Myfieldinfob.IsPrivate)

        Return 0
    End Function 'Main
End Class 'Myfieldinfo
' </Snippet1>