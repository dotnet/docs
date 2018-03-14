 '
 'File Name: tagPrefixAttribute'
 'Purpose: Show the use ot the TagPrefixAttribute class to define an assembly-level attribute that enables a control '
 'developer to specify a tag prefix alias for her custom controls. This attribute is used by tool such as Visual Studio.NET '
 'to automatically generate the following  Register directive in Web page where the custom control is used:'
 ' <%@ Register TagPrefix="tag prefix" Assembly="assembly name" Namespace="name space" %>.'
 'This directive registers the tag prefix with a name space, moreover it specifies the assembly where the custom control '
 'code implementation resides. All this information is used by the runtime to allow the custom control compilation. With this '
 'directive in place, the user of your custom controls can include them in the Web page declaratively with the pre-specified '
 'tag prefix as follows: <tagprefix:controlname  runat = "server" /> '
 

'<snippet1>

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<assembly: TagPrefix("CustomControls", "custom")> _

Namespace CustomControls
   
   ' Simple custom control
   Public Class MyVB_Control 
   Inherits Control
      Private message As String = "Hello"
      
      Public  Property getMessage() As String
         Get
            Return message
         End Get
         Set (ByVal value As String)
            message = value
         End Set
      End Property
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         writer.Write(("<span style='background-color:aqua; font:8pt tahoma, verdana;'> " + Me.getMessage + "<br>" + "VB version. The time on the server is " + System.DateTime.Now.ToLongTimeString() + "</span>"))
      End Sub 'Render
   End Class 'MyControl
End Namespace 'CustomControls 

'</snippet1>
