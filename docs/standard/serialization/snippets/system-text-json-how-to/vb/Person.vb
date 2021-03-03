Imports System.Runtime.CompilerServices

Namespace SystemTextJsonSamples

    ' <Person>
    Public Class Person
        Public Property Name As String
    End Class

    Public Class Customer
        Inherits Person
        Public Property CreditLimit As Decimal
    End Class

    Public Class Employee
        Inherits Person
        Public Property OfficeNumber As String
    End Class

    ' </Person>

    Public Module PersonExtensions

        <Extension()>
        Public Sub DisplayPropertyValues(person1 As Person)
            Utilities.DisplayPropertyValues(person1)
            Console.WriteLine()
        End Sub

    End Module

    Public Module PersonFactories

        Public Function CreatePeople() As List(Of Person)
            Return New List(Of Person) From {
                New Customer With {
                    .CreditLimit = 10000,
                    .Name = "John"},
                New Employee With {
                    .OfficeNumber = "555-1234",
                    .Name = "Nancy"}}
        End Function

    End Module
End Namespace
