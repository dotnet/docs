' <snippet1>
' Create a simple class, named StringEncoder,
' that performs HTML and URL encoding of strings.
Imports System
Imports System.Web
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class StringEncoder
      Inherits WebControl
      
        Overrides Protected Sub Render(writer As HtmlTextWriter)

          ' Create variables and assign them values.
          Dim url As String 
          Dim param As String
          Dim colHeads As String 
 ' <snippet2>         
          ' Assign a value to a string variable,
          ' encode it, and write it to a page.
          colHeads = "<custID> & <invoice#>" 
          writer.WriteEncodedText(colHeads)
          writer.WriteBreak()
  ' </snippet2>
  
  ' <snippet3>          
          ' Assign a value to a string variable
          ' and URL-encode it to a page.
          url = "http://localhost/SampleFolder/Sample + File.txt" 
          writer.WriteBreak()
          writer.WriteEncodedUrl(url)
          writer.WriteBreak()
  ' </snippet3>
  
  ' <snippet4> 
          ' Assign a value to a string variable
          ' and encode it to a page as a 
          ' URL parameter.      
          param = "ID=City State"
          writer.WriteBreak()
          writer.WriteEncodedUrlParameter(param)
  ' </snippet4>
        End Sub
    End Class
End Namespace
 ' </snippet1>
