' <Snippet1>	

Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class [MyClass]
    Private myField As String
    Public myArray() As String = {"New York", "New Jersey"}

    Sub New()
        myField = "Microsoft"
    End Sub 'New

    ReadOnly Property GetField() As String
        Get
            Return myField
        End Get
    End Property
End Class '[MyClass]


Class FieldInfo_IsPrivate

    Public Shared Sub Main()
        Try
            ' Gets the type of MyClass.
            Dim myType As Type = GetType([MyClass])

            ' Gets the field information of MyClass.
            Dim myFields As FieldInfo() = myType.GetFields((BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Instance))

            Console.WriteLine(ControlChars.Cr & "Displaying whether the fields of {0} are private or not:" & ControlChars.Cr, myType)
            Console.WriteLine() 
            Dim i As Integer
            For i = 0 To myFields.Length - 1
                ' Check whether the field is private or not. 
                If myFields(i).IsPrivate Then
                    Console.WriteLine("{0} is a private field.", myFields(i).Name)
                Else
                    Console.WriteLine("{0} is not a private field.", myFields(i).Name)
                End If
            Next i
        Catch e As Exception
            Console.WriteLine("Exception : {0} ", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'FieldInfo_IsPrivate
' </Snippet1>