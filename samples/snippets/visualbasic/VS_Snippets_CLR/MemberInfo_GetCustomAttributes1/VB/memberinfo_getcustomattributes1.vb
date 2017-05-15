' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define a custom attribute with one named parameter.
<AttributeUsage(AttributeTargets.All)> Public Class MyAttribute
    Inherits Attribute
    Private myName As String

    Public Sub New(ByVal name As String)
        myName = name
    End Sub 'New

    Public ReadOnly Property Name() As String
        Get
            Return myName
        End Get
    End Property
End Class 'MyAttribute

' Define a class that has the custom attribute associated with one of its members.
Public Class MyClass1

    <MyAttribute("This is an example attribute.")> Public Sub MyMethod(ByVal i As Integer)
        Return
    End Sub 'MyMethod
End Class 'MyClass1


Public Class MemberInfo_GetCustomAttributes

    Public Shared Sub Main()
        Try
            ' Get the type of MyClass1.
            Dim myType As Type = GetType(MyClass1)
            ' Get the members associated with MyClass1.
            Dim myMembers As MemberInfo() = myType.GetMembers()

            ' Display the attributes for each of the members of MyClass1.
            Dim i As Integer
            For i = 0 To myMembers.Length - 1
                Dim myAttributes As [Object]() = myMembers(i).GetCustomAttributes(False)
                If myAttributes.Length > 0 Then
                    Console.WriteLine("The attributes for the member {0} are: ", myMembers(i))
                    Dim j As Integer
                    For j = 0 To myAttributes.Length - 1
                        Console.WriteLine("The type of the attribute is: {0}", myAttributes(j))
                    Next j
                End If
            Next i
        Catch e As Exception
            Console.WriteLine("An exception occurred: {0}.", e.Message)
        End Try
    End Sub 'Main
End Class 'MemberInfo_GetCustomAttributes
' </Snippet1>