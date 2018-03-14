' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic
Public Class MyClass1
    Protected myField As String = "A sample protected field."
End Class 'MyClass1
Public Class MyType_IsAnsiClass
    Public Shared Sub Main()
        Try
            Dim myObject As New MyClass1()
            ' Get the type of MyClass1.
            Dim myType As Type = GetType(MyClass1)
            ' Get the field information and the attributes associated with MyClass1.
            Dim myFieldInfo As FieldInfo = myType.GetField("myField", BindingFlags.NonPublic Or BindingFlags.Instance)

            Console.WriteLine(ControlChars.NewLine + "Checking for AnsiClass attribute for a field." + ControlChars.NewLine)
            ' Get and display the name, field, and the AnsiClass attribute.
            Console.WriteLine("Name of Class: {0} " + ControlChars.NewLine + "Value of Field: {1} " + ControlChars.NewLine + "IsAnsiClass = {2}", myType.FullName, myFieldInfo.GetValue(myObject), myType.IsAnsiClass)
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyType_IsAnsiClass
' </Snippet1>
