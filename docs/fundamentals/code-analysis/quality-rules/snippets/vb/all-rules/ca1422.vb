
Imports System.Runtime.Versioning

Public Class Violation
    ' <Snippet1>
    <SupportedOSPlatform("Windows")>
    Public Sub M1()
        ' Violates rules CA1422.
        ' This call site is reachable on 'Windows',
        ' but 'ObsoletedOnWindows62()'
        ' is obsoleted on 'Windows 6.2' and later.
        ObsoletedOnWindows62()
    End Sub

    <ObsoletedOSPlatform("Windows6.2")>
    Public Sub ObsoletedOnWindows62()
    End Sub
    ' </Snippet1>
End Class

Public Class Fix
    ' <Snippet2>
    <SupportedOSPlatform("Windows")>
    <ObsoletedOSPlatform("Windows6.2")>
    Public Sub M1()
        ObsoletedOnWindows62()
    End Sub

    <ObsoletedOSPlatform("Windows6.2")>
    Public Sub ObsoletedOnWindows62()
    End Sub
    ' </Snippet2>
End Class
