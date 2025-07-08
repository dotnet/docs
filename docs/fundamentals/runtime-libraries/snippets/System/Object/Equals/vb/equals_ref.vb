' Visual Basic .NET Document
' Illustrates reference equality with reference types.
Option Strict On

' <Snippet2>
' Define a reference type that does not override Equals.
Public Class Person1
    Private personName As String

    Public Sub New(name As String)
        Me.personName = name
    End Sub

    Public Overrides Function ToString() As String
        Return Me.personName
    End Function
End Class

Module Example0
    Public Sub Main()
        Dim person1a As New Person1("John")
        Dim person1b As Person1 = person1a
        Dim person2 As New Person1(person1a.ToString())

        Console.WriteLine("Calling Equals:")
        Console.WriteLine("person1a and person1b: {0}", person1a.Equals(person1b))
        Console.WriteLine("person1a and person2: {0}", person1a.Equals(person2))
        Console.WriteLine()

        Console.WriteLine("Casting to an Object and calling Equals:")
        Console.WriteLine("person1a and person1b: {0}", CObj(person1a).Equals(CObj(person1b)))
        Console.WriteLine("person1a and person2: {0}", CObj(person1a).Equals(CObj(person2)))
    End Sub
End Module
' The example displays the following output:
'       Calling Equals:
'       person1a and person1b: True
'       person1a and person2: False
'       
'       Casting to an Object and calling Equals:
'       person1a and person1b: True
'       person1a and person2: False
' </Snippet2>
