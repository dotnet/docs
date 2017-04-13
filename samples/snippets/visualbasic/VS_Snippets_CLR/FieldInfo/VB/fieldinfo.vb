' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class FieldInfoClass
    Public myField1 As Integer = 0
    Protected myField2 As String = Nothing

    Public Shared Sub Main()
        Dim myFieldInfo() As FieldInfo
        Dim myType As Type = GetType(FieldInfoClass)
        ' Get the type and fields of FieldInfoClass.
        myFieldInfo = myType.GetFields(BindingFlags.NonPublic Or _
                      BindingFlags.Instance Or BindingFlags.Public)
        Console.WriteLine(ControlChars.NewLine & "The fields of " & _
                      "FieldInfoClass class are " & ControlChars.NewLine)
        ' Display the field information of FieldInfoClass.
        Dim i As Integer
        For i = 0 To myFieldInfo.Length - 1
            Console.WriteLine(ControlChars.NewLine + "Name            : {0}", myFieldInfo(i).Name)
            Console.WriteLine("Declaring Type  : {0}", myFieldInfo(i).DeclaringType)
            Console.WriteLine("IsPublic        : {0}", myFieldInfo(i).IsPublic)
            Console.WriteLine("MemberType      : {0}", myFieldInfo(i).MemberType)
            Console.WriteLine("FieldType       : {0}", myFieldInfo(i).FieldType)
            Console.WriteLine("IsFamily        : {0}", myFieldInfo(i).IsFamily)
        Next i
    End Sub
End Class
' </Snippet1>