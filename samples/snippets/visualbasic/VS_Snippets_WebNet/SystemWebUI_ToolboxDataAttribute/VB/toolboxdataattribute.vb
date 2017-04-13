'File Name: toolBoxDataAttribute.vb

'<snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace CustomControls
  <ToolboxData("<{0}:MyLabel Text='MyLabel' BorderColor='Yellow' BackColor='Magenta' BorderWidth = '10'  runat='server'></{0}:MyLabel>")>  _
  Public Class MyLabel
    Inherits Label
     
    Public Sub New()
      'Your code goes here.
    End Sub 'New
    
  End Class 'MyLabel
  
End Namespace 'CustomControls


' </snippet1>
