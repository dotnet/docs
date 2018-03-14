' <Snippet1>
' Create a custom WebControl class, named AttribRender, that overrides 
' the Render method to write two introductory strings. Then call the
' AttributeCollection.Render method, which allows the control to write the
' attribute values that are added to it when it is included in a page.
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

' Create the namespace that contains the AttribRender and the
' page that accesses it.
Namespace AC_Render

 ' This is the custom WebControl class.
    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class AttribRender
        Inherits WebControl

        ' This is the overridden WebControl.Render method.
        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            output.Write("<h2>An AttributeCollection.Render Method Example</h2>")
            output.Write("The attributes, and their values, added to the ctl1 control are <br><br>")
            ' This is the AttributeCollection.Render method call. When the
            ' page that contains this control is requested, the
            ' attributes that the page adds, and their values,
            ' are rendered to the page.
            Attributes.Render(output)
        End Sub 'Render
    End Class 'AttribRender

End Namespace 'AC_Render
' </Snippet1>