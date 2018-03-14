
Imports System
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design


'<snippet1>

Namespace CustomControls

  <DataBindingHandler(GetType(MyDataBindingHandler)), ToolboxData("<{0}:MyLabel runat=server></{0}:MyLabel>")>  _
    Public Class MyLabel
      Inherits Label
      
      Public Sub New()
        'Insert your code here.
      End Sub 'New
      
    End Class 'MyLabel
   
    Public Class MyDataBindingHandler
      Inherits DataBindingHandler
      
      Public Overrides Sub DataBindControl(host As IDesignerHost, control As Control)
         CType(control, Label).Text = "Added by data binding handler."
      End Sub 'DataBindControl
      
    End Class 'MyDataBindingHandler
    
End Namespace 'CustomControls 

'</snippet1>
