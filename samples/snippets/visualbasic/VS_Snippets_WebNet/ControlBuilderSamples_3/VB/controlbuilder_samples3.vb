Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Web.SessionState
Imports System.Web.Caching
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions
Imports Debug = System.Diagnostics.Debug

Namespace MS.ASPNET.Samples
 ' <snippet1>
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
 ' </snippet1>
End Namespace
