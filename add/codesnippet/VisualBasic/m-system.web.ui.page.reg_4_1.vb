   ' Create a custom HtmlForm server control named MyForm.
   Public Class MyForm
      Inherits HtmlForm
      
      ' MyForm inherits all the base funcitionality
      ' of the HtmlForm control.
      Public Sub New()
      End Sub 'New
      
      ' Override the OnInit method that MyForm inherited from HtmlForm.
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub OnInit(e As EventArgs)
         ' Save the view state if there are server controls on
         ' a page that calls MyForm.
         Page.RegisterViewStateHandler()
      End Sub 'OnInit
   End Class 'MyForm
