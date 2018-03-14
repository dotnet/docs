Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidTestToolWindowSearchVBPkgString As String = "e9f99996-deb9-4995-a130-60ef9dfb2202"
    Public Const guidTestToolWindowSearchVBCmdSetString As String = "198e2eb0-c29f-442c-a34e-c23ac467cd69"
    Public Const guidToolWindowPersistanceString As String = "dd3f95d9-1f87-4fdc-9019-adac667908ed"

    Public Shared ReadOnly guidTestToolWindowSearchVBCmdSet As New Guid(guidTestToolWindowSearchVBCmdSetString)
End Class