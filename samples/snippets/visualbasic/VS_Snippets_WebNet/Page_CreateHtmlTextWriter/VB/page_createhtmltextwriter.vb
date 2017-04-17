'   The following program demonstrates the 'CreateHtmlTextWriter' method and constructor of 'Page' class. 
'  
'   This program creates a custom 'TextWriter' derived from 'HtmlTextWriter' called 
'   'MyHtmlTextWriter'. The 'CreateHtmlTextWriter' method is overriden in the 'MyPage' 
'   class, derived from 'Page', so that the instance of 'MyHtmlTextWriter' is used in
'   rendering the WebControls. The 'Render' method is overridden in  'MyPage' class 
'   which will print the current time.

' <Snippet1>	
' <Snippet2>
Imports System
Imports System.IO
Imports System.Web.UI

Namespace WebPage

	
   Public Class MyPage
      Inherits Page
      
      Public Sub New()
         MyBase.New()
      End Sub 'New

      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Function CreateHtmlTextWriter(ByVal writer As TextWriter) As HtmlTextWriter
         Return New MyHtmlTextWriter(writer)
      End Function 'CreateHtmlTextWriter

      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
         ' Writes a Font control.
         writer.AddAttribute("color", "red")
         writer.AddAttribute("size", "6pt")
         writer.RenderBeginTag(HtmlTextWriterTag.Font)
         writer.Write(("<br>" + "The time on the server:<br> " + System.DateTime.Now.ToLongTimeString()))
         writer.RenderEndTag()
      End Sub 'Render
   End Class 'MyPage
	

   Public Class MyHtmlTextWriter
      Inherits HtmlTextWriter
      
      Public Sub New(writer As TextWriter)
         MyBase.New(writer)
         writer.Write("<font color=blue> 'MyHtmlTextWriter' is used for rendering.</font>")
      End Sub 'New
   End Class 'MyHtmlTextWriter
End Namespace 'WebPage
' </Snippet2>	
' </Snippet1>