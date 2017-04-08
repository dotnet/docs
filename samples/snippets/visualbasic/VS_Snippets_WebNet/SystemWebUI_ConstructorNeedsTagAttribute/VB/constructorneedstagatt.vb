 ' <snippet1>
' File name: constructorneedstagatt.cs. 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel


Namespace MyUserControl
   <ConstructorNeedsTagAttribute(True)>  _
   Public Class Simple
      Inherits WebControl
      Private NameTag As [String] = ""
      
      Public Sub New(tag As [String])
        Me.NameTag = tag
      End Sub 'New
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(output As HtmlTextWriter)
        output.Write(("<br>The TagName used for the 'Simple' control is " + "'" + NameTag + "'"))
      End Sub 'Render
   End Class 'Simple
End Namespace 'MyUserControl
' </snippet1>
