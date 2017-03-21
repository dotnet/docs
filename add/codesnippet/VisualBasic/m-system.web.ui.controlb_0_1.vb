    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class MyControlControlBuilder
      Inherits ControlBuilder
        
        Private _innerText As String
        
        Overrides Public Function NeedsTagInnerText() As Boolean
          Return InDesigner
        End Function
        
        Overrides Public Sub SetTagInnerText(ByVal text As String)        
           If InDesigner = False
             Throw New System.Exception("The control is not in design mode.")
           Else
             _innerText = text
           End If
        End Sub
        
    End Class