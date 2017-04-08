' <snippet1>

' File name: emptyControlCollection.vb.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections


Namespace CustomControls 

  Public Class MyVB_EmptyControl 
    Inherits Control
    
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Function CreateControlCollection() As ControlCollection
    ' Function Name: CreateControlCollection.
    ' Denies the creation of any child control by creating an empty collection.
    ' Generates an exception if an attempt to create a child control is made.
      Return New EmptyControlCollection(Me)
    End Function 
    
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _  
    Protected Overrides Sub CreateChildControls()
    ' Sub Name: CreateChildControls.
    ' Populates the child control collection (Controls). 
    ' Note: This function will cause an exception because the control does not allow 
    ' child controls.
      Dim text As LiteralControl
      text = New LiteralControl("<h5>Composite Controls</h5>")
      Controls.Add(text)
    End Sub 
  End Class 

End Namespace 

'</snippet1>

