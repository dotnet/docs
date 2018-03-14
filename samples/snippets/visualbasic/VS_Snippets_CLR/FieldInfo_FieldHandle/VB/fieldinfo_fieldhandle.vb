' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class [MyClass]
    Public MyField As String = "Microsoft"
End Class '[MyClass]

Public Class FieldInfo_FieldHandle
    Public Shared Sub Main()
        Dim [myClass] As New [MyClass]()
        ' Get the type of MyClass.
        Dim myType As Type = GetType([MyClass])
        Try
            ' Get the field information of MyField.
            Dim myFieldInfo As FieldInfo = myType.GetField("MyField", BindingFlags.Public Or BindingFlags.Instance)

            ' Determine whether or not the FieldInfo object is null.
            If Not (myFieldInfo Is Nothing) Then
                ' Get the handle for the field.
                Dim myFieldHandle As RuntimeFieldHandle = myFieldInfo.FieldHandle

                DisplayFieldHandle(myFieldHandle)
            Else
                Console.WriteLine("The myFieldInfo object is null.")
            End If
        Catch e As Exception
            Console.WriteLine(" Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main

    Public Shared Sub DisplayFieldHandle(ByVal myFieldHandle As RuntimeFieldHandle)
        ' Get the type from the handle.
        Dim myField As FieldInfo = FieldInfo.GetFieldFromHandle(myFieldHandle)
        ' Display the type.
        Console.WriteLine(ControlChars.Cr + "Displaying the field from the handle." + ControlChars.Cr)
        Console.WriteLine("The type is {0}.", myField.ToString())
    End Sub 'DisplayFieldHandle
End Class 'FieldInfo_FieldHandle
' </Snippet1>
