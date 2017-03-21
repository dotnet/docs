' Note: Access checks must be performed at the component level to allow access
' to private components.

<assembly: ApplicationAccessControl(False, AccessChecksLevel := AccessChecksLevelOption.ApplicationComponent)>


<PrivateComponent()>  _
Public Class PrivateComponentAttribute_Example
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display some output.
        MsgBox("Private component called successfully.")
    
    End Sub 'Example
End Class 'PrivateComponentAttribute_Example