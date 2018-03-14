'File name: myDataBoundLiteralControl

' <Snippet1> 
Imports System
Imports System.Web
Imports System.Web.UI


Namespace Samples.AspNet.VB.Controls 
   
   Public Class MyControlVB
      Inherits Control     

      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(Output As HtmlTextWriter)
         ' Checks if a DataBoundLiteralControl object is present.
         If HasControls() And TypeOf Controls(0) Is DataBoundLiteralControl Then            

            ' Obtains the DataBoundLiteralControl instance.
            Dim boundLiteralControl As DataBoundLiteralControl = CType(Controls(0), DataBoundLiteralControl)
            ' Retrieves the text in the boundLiteralControl object.
            Dim text As String = boundLiteralControl.Text
            output.Write(("<h4>Your Message: " + text + "</h4>"))
         End If 
      End Sub 'Render  

   End Class 'MyControl
End Namespace 'MyUserControl
' </Snippet1>