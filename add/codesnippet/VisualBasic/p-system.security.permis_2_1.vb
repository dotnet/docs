' The following class is an example of code that exposes 
' external process management.
' Add the LicenseProviderAttribute to the control.
<LicenseProvider(GetType(LicFileLicenseProvider))> _
Public Class MyControl
    Inherits System.Windows.Forms.Control

    ' Create a new, null license.
    Private license As License = Nothing

    <HostProtectionAttribute(ExternalProcessMgmt := True)> _
    Public Sub New()

        ' Determine if a valid license can be granted.
        Dim isValid As Boolean = LicenseManager.IsValid(GetType(MyControl))
        Console.WriteLine(("The result of the IsValid method call is " & _
            isValid.ToString()))
    End Sub 'New

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (license Is Nothing) Then
                license.Dispose()
                license = Nothing
            End If
        End If
    End Sub 'Dispose
End Class 'MyControl