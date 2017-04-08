' <Snippet1>
' <Snippet2>

Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class MyFieldClassA
    Public Field As String = "A Field"
End Class 'MyFieldClassA

Public Class MyFieldClassB
    Private myField As String = "B Field"

    Public Property Field() As String
        Get
            Return myField
        End Get
        Set(ByVal Value As String)
            If myField <> value Then
                myField = value
            End If
        End Set
    End Property
End Class 'MyFieldClassB


Public Class MyFieldInfoClass

    Public Shared Sub Main()
        Dim myFieldObjectB As New MyFieldClassB()
        Dim myFieldObjectA As New MyFieldClassA()

        Dim myTypeA As Type = GetType(MyFieldClassA)
        Dim myFieldInfo As FieldInfo = myTypeA.GetField("Field")

        Dim myTypeB As Type = GetType(MyFieldClassB)
        Dim myFieldInfo1 As FieldInfo = myTypeB.GetField("myField", _
            BindingFlags.NonPublic Or BindingFlags.Instance)

        Console.WriteLine("The value of the public field is: '{0}'", _
            myFieldInfo.GetValue(myFieldObjectA))
        Console.WriteLine("The value of the private field is: '{0}'", _
            myFieldInfo1.GetValue(myFieldObjectB))
    End Sub 'Main

End Class 'MyFieldInfoClass

' </Snippet2>
' </Snippet1>