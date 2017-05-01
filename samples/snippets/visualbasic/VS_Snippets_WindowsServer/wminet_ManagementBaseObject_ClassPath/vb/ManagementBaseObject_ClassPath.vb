'<Snippet1>
Imports System
Imports System.Management

Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Create a query for classes
        Dim query As New SelectQuery( _
            "SELECT * FROM meta_class")

        ' Initialize an object searcher with this query
        Dim searcher As New ManagementObjectSearcher( _
            query)

        ' Get the resulting collection and loop through it
        For Each classObject As ManagementObject _
            In searcher.Get()

            Console.WriteLine( _
                classObject.ClassPath)
        Next

    End Function
End Class
'</Snippet1>