'<Snippet1>
Imports System.Collections.Generic

Class Base
    Public Shared Sub PrintBases(ByVal bases As IEnumerable(Of Base))
        For Each b As Base In bases
            Console.WriteLine(b)
        Next
    End Sub
End Class

Class Derived
    Inherits Base

    Shared Sub Main()
        Dim dlist As New List(Of Derived)()

        Derived.PrintBases(dlist)
        Dim bIEnum As IEnumerable(Of Base) = dlist
    End Sub
End Class
'</Snippet1>
