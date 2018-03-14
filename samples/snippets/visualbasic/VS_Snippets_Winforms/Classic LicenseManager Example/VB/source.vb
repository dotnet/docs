' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

' Adds the LicenseProviderAttribute to the control.
<LicenseProvider(GetType(LicFileLicenseProvider))> _
Public Class MyControl
    Inherits Control
    
    ' Creates a new, null license.
    Private license As License = Nothing    
    
    Public Sub New()        
    
        ' Adds Validate to the control's constructor.
        license = LicenseManager.Validate(GetType(MyControl), Me)

        ' Insert code to perform other instance creation tasks here.
        
    End Sub
    
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            If (license IsNot Nothing) Then
                license.Dispose()
                license = Nothing
            End If
        End If

    End Sub    
    
End Class

' </snippet1>
