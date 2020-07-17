'<snippet48>
Imports System.Runtime.InteropServices

Public Class Snippets
    Public Shared Sub Main()

    End Sub

    '<snippet49>
    Public Sub M1(<MarshalAs(UnmanagedType.LPWStr)> msg As String)
        ' ...
    End Sub
    '</snippet49>

    '<snippet51>
    Public Function M2() As <MarshalAs(UnmanagedType.LPWStr)> String
        Dim msg As New String(New Char(128) {})
        ' Load message here ...
        Return msg
    End Function
    '</snippet51>
End Class

'<snippet50>
Class MsgText
    <MarshalAs(UnmanagedType.LPWStr)>
    Public msg As String = ""
End Class
'</snippet50>
'</snippet48>
