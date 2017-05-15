Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace CompositionSampleControls
    _
   
   Public Class Composition1
      Inherits Control
      Implements INamingContainer 
      
      ' <snippet1>
      ' Ensure the current control has children,
      ' then get or set the Text property.
      
      Public Property Value() As Integer
         Get
            Me.EnsureChildControls()
            Return Int32.Parse(CType(Controls(1), TextBox).Text)
         End Get
         Set
            Me.EnsureChildControls()
            CType(Controls(1), TextBox).Text = value.ToString()
         End Set
      End Property
      
      
      ' </snippet1>
      
      ' <snippet2>
      ' Override CreateChildControls to create the control tree.
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="Execution")> _
      Protected Overrides Sub CreateChildControls()
         
         ' Add a LiteralControl to the current ControlCollection.
         Me.Controls.Add(New LiteralControl("<h3>Value: "))
         
         
         ' Create a text box control, set the default Text property, 
         ' and add it to the ControlCollection.
         Dim box As New TextBox()
         box.Text = "0"
         Me.Controls.Add(box)
         
         Me.Controls.Add(New LiteralControl("</h3>"))
      End Sub 'CreateChildControls
      ' </snippet2>
   End Class 'Composition1 
End Namespace 'CompositionSampleControls 
  