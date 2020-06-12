Imports System.Data.Objects
Imports L2EMaterializationVB.AdventureWorksModel

Module Module1

    ' <SnippetMaterializationSideEffects>
    Public count As Integer = 0

    Sub Main()

        Using AWEntities As New AdventureWorksEntities()

            Dim query1 = AWEntities.Contacts _
            .Where(Function(c) c.LastName = "Jones") _
            .Select(Function(c) New MyContact With {.LastName = c.LastName})

            ' Execute the first query and print the count.
            query1.ToList()
            Console.WriteLine("Count: " & count)

            ' Reset the count variable.
            count = 0

            Dim query2 = AWEntities _
            .Contacts() _
            .Where(Function(c) c.LastName = "Jones") _
            .Select(Function(c) New MyContact With {.LastName = c.LastName}) _
            .Select(Function(x) x.LastName)

            ' Execute the second query and print the count.
            query2.ToList()
            Console.WriteLine("Count: " & count)

        End Using
    End Sub
    ' </SnippetMaterializationSideEffects>
    ' <SnippetMyContactClass>
    Public Class MyContact

        Private _lastName As String

        Public Property LastName() As String
            Get
                Return _lastName
            End Get

            Set(ByVal value As String)
                _lastName = value
                count += 1
            End Set
        End Property

    End Class
    ' </SnippetMyContactClass>


End Module
