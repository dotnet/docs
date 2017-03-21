    <LicenseProvider(GetType(LicFileLicenseProvider))> _
    Public Class MyControl
        Inherits Control
        
        ' Insert code here.
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            ' All components must dispose of the licenses they grant.
            ' Insert code here to dispose of the license.
        End Sub        

    End Class