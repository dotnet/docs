' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class FieldInfo_GetFieldFromHandle
    Public x As String
    Public y As Char
    Public a As Single
    Public b As Integer

    Public Shared Sub Main()
        ' Get the type of the FieldInfo_GetFieldFromHandle class.
        Dim myType As Type = GetType(FieldInfo_GetFieldFromHandle)
        ' Get the fields of the FieldInfo_GetFieldFromHandle class.
        Dim myFieldInfoArray As FieldInfo() = myType.GetFields()
        Console.WriteLine(ControlChars.NewLine & _
           "The field information of the declared" & _
           " fields x, y, a, and b is:" & ControlChars.NewLine)
        Dim myRuntimeFieldHandle As RuntimeFieldHandle
        Dim i As Integer
        For i = 0 To myFieldInfoArray.Length - 1
            ' Get the RuntimeFieldHandle of myFieldInfoArray.
            myRuntimeFieldHandle = myFieldInfoArray(i).FieldHandle
            ' Call the GetFieldFromHandle method. 
            Dim myFieldInfo As FieldInfo = FieldInfo.GetFieldFromHandle(myRuntimeFieldHandle)
            ' Display the FieldInfo of myFieldInfo.
            Console.WriteLine("{0}", myFieldInfo)
        Next i
    End Sub 'Main
End Class 'FieldInfo_GetFieldFromHandle
' </Snippet1>