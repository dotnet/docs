'<Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class AttributesSample

    Public Sub Mymethod(ByVal int1m As Integer, ByRef str2m As String, ByRef str3m As String)
        str2m = "in Mymethod"
    End Sub 'Mymethod

    Public Shared Function Main(ByVal args() As String) As Integer
        Console.WriteLine("Reflection.MethodBase.Attributes Sample")

        ' Get the type.
        Dim MyType As Type = Type.GetType("AttributesSample")

        ' Get the method Mymethod on the type.
        Dim Mymethodbase As MethodBase = MyType.GetMethod("Mymethod")

        ' Display the method name.
        Console.WriteLine("Mymethodbase = {0}.", Mymethodbase)

        ' Get the MethodAttribute enumerated value.
        Dim Myattributes As MethodAttributes = Mymethodbase.Attributes

        ' Display the flags that are set.
        PrintAttributes(GetType(System.Reflection.MethodAttributes), CInt(Myattributes))
        Return 0
    End Function 'Main

    Public Shared Sub PrintAttributes(ByVal attribType As Type, ByVal iAttribValue As Integer)
        If Not attribType.IsEnum Then
            Console.WriteLine("This type is not an enum.")
            Return
        End If
        Dim fields As FieldInfo() = attribType.GetFields((BindingFlags.Public Or BindingFlags.Static))
        Dim i As Integer
        For i = 0 To fields.Length - 1
            Dim fieldvalue As Integer = CType(fields(i).GetValue(Nothing), Int32)
            If (fieldvalue And iAttribValue) = fieldvalue Then
                Console.WriteLine(fields(i).Name)
            End If
        Next i
    End Sub 'PrintAttributes
End Class 'AttributesSample
'</Snippet1>