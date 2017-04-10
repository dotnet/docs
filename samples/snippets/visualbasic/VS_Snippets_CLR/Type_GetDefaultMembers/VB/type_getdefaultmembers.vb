' <Snippet1>
Imports System
Imports System.Reflection
Imports System.IO
Imports Microsoft.VisualBasic

<DefaultMemberAttribute("Age")> Public Class [MyClass]

    Public Sub Name(ByVal s As String)
    End Sub 'Name

    Public ReadOnly Property Age() As Integer
        Get
            Return 20
        End Get
    End Property

    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType([MyClass])
            Dim memberInfoArray As MemberInfo() = myType.GetDefaultMembers()
            If memberInfoArray.Length > 0 Then
                Dim memberInfoObj As MemberInfo
                For Each memberInfoObj In memberInfoArray
                    Console.WriteLine("The default member name is: " + memberInfoObj.ToString())
                Next memberInfoObj
            Else
                Console.WriteLine("No default members are available.")
            End If
        Catch e As InvalidOperationException
            Console.WriteLine("InvalidOperationException: " + e.Message)
        Catch e As IOException
            Console.WriteLine("IOException: " + e.Message)
        Catch e As Exception
            Console.WriteLine("Exception: " + e.Message)
        End Try
    End Sub 'Main
End Class '[MyClass]
' </Snippet1>