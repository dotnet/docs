Imports System.Collections.Generic

Class Base
End Class
Class Derived
    Inherits Base
End Class

Class C
    Shared Sub Main()
        '<Snippet1>
        Dim d As IEnumerable(Of Derived) = New List(Of Derived)
        Dim b As IEnumerable(Of Base) = d
        '</Snippet1>
    End Sub
End Class
