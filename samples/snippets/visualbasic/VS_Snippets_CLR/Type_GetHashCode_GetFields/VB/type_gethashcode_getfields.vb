' <Snippet1>
Imports System
Imports System.Security
Imports System.Reflection
Imports Microsoft.VisualBasic

' Compile this sample using the following command line:
' vbc type_gethashcode_getfields.vb /r:"System.Windows.Forms.dll" /r:"System.dll"

Class FieldsSample

    Public Shared Sub Main()
        Dim myType As Type = GetType(System.Net.IPAddress)
        Dim myFields As FieldInfo() = myType.GetFields((BindingFlags.Static Or BindingFlags.NonPublic))
        Console.WriteLine(ControlChars.Lf & "The IPAddress class has the following nonpublic fields: ")
        Dim myField As FieldInfo
        For Each myField In myFields
            Console.WriteLine(myField.ToString())
        Next myField
        Dim myType1 As Type = GetType(System.Net.IPAddress)
        Dim myFields1 As FieldInfo() = myType1.GetFields()
        Console.WriteLine(ControlChars.Lf & "The IPAddress class has the following public fields: ")
        Dim myField1 As FieldInfo
        For Each myField1 In myFields1
            Console.WriteLine(myField.ToString())
        Next myField1
        Try
            Console.WriteLine("The HashCode of the System.Windows.Forms.Button type is: {0}", GetType(System.Windows.Forms.Button).GetHashCode())
        Catch e As SecurityException
            Console.WriteLine("An exception occurred.")
            Console.WriteLine(("Message: " & e.Message))
        Catch e As Exception
            Console.WriteLine("An exception occurred.")
            Console.WriteLine(("Message: " & e.Message))
        End Try
    End Sub 'Main
End Class 'FieldsSample
' </Snippet1>