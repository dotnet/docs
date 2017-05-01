Option Strict On

'<Snippet2>
Imports System.Collections.Generic
Imports Microsoft.Office.Interop.Excel

Class Utility
    ' The following code causes an error when called by a client assembly.
    Public Function GetRange1() As List(Of Range)
        '</Snippet2>
        Return Nothing
        '<Snippet3>
    End Function

    ' The following code is valid for calls from a client assembly.
    Public Function GetRange2() As IList(Of Range)
        '</Snippet3>
        Return Nothing
        '<Snippet4>
    End Function
End Class
'</Snippet4>