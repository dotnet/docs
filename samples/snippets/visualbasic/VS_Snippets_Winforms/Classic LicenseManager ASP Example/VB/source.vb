' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Web.UI

' Adds the LicenseProviderAttribute to the control.
<LicenseProvider(GetType(LicFileLicenseProvider))> Public Class MyControl
    Inherits Control

    ' Creates a new, null license.
    Private license As License

    Public Sub New()

        ' Adds Validate to the control's constructor.
        license = LicenseManager.Validate(GetType(MyControl), Me)

        ' Insert code to perform other instance creation tasks here.

    End Sub

    Public Overrides Sub Dispose()
        If (license IsNot Nothing) Then
            license.Dispose()
            license = Nothing
        End If
        MyBase.Dispose()
    End Sub
End Class

' </snippet1>