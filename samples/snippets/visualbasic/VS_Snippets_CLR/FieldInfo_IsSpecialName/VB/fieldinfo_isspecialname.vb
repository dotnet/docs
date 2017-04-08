' <Snippet1>
Imports System
Imports System.Reflection
Imports System.ComponentModel.Design
Imports Microsoft.VisualBasic

Class FieldInfo_IsSpecialName

    Public Shared Sub Main()
        Try
            ' Get the type handle of a specified class.
            Dim myType As Type = GetType(ViewTechnology)

            ' Get the fields of a specified class.
            Dim myField As FieldInfo() = myType.GetFields()

            Console.WriteLine(ControlChars.Cr + "Displaying fields that have SpecialName attributes:" + ControlChars.Cr)
            Dim i As Integer
            For i = 0 To myField.Length - 1
                ' Determine whether or not each field is a special name.
                If myField(i).IsSpecialName Then
                    Console.WriteLine("The field {0} has a SpecialName attribute.", myField(i).Name)
                End If
            Next i
        Catch e As Exception
            Console.WriteLine("Exception : {0} ", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'FieldInfo_IsSpecialName
' </Snippet1>