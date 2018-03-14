Imports System
Imports System.Security.Permissions
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls

namespace CustomControls.Design
    '<Snippet2>
    ' Create a control and bind it to the ExampleAccessDataSourceDesigner.
    <AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand, _
        Level:=System.Web.AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, _
        Level:=System.Web.AspNetHostingPermissionLevel.Minimal)> _
    <Designer("CustomControls.Design.ExampleAccessDataSourceDesigner")> _
    Public Class ExampleAccessDataSource
        Inherits AccessDataSource

        ' Does nothing extra
    End Class
    '</Snippet2>

    '<Snippet3>
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class ExampleAccessDataSourceDesigner
        Inherits AccessDataSourceDesigner

        '<Snippet5>
        ' Generate design time markup.
        Public Overrides Function GetDesignTimeHtml() As String
            ' Generate a design-time placeholder containing the 
            ' DataFile and the ConnectionString properties.
            ' Split the ConnectionString into segments so it doesn't make
            ' placeholder too wide.
            Dim connectParts() As String
            connectParts = GetConnectionString().Split((";").ToCharArray())
            Dim connectString As String
            connectString = "&nbsp;&nbsp;" & connectParts(0)

            Dim i As Integer
            For i = 1 To connectParts.Length - 1
                connectString &= ";<br>&nbsp;&nbsp;" & connectParts(i).Trim()
            Next

            Return CreatePlaceHolderDesignTimeHtml( _
                "DataFile: " & DataFile & "<br />" & _
                "Connection string:<br />" & connectString)
        End Function
        '</Snippet5>

        '<Snippet4>
        ' Shadow control properties with design time properties.
        Protected Overrides Sub PreFilterProperties(ByVal properties As IDictionary)

            ' Call the base class method first.
            MyBase.PreFilterProperties(properties)

            ' Add the ConnectionString property to the property grid.
            Dim prop As PropertyDescriptor
            prop = CType(properties("ConnectionString"), PropertyDescriptor)

           Dim atts(1) As Attribute
            atts(0) = New BrowsableAttribute(True)
            atts(1) = New ReadOnlyAttribute(True)

            properties("ConnectionString") = TypeDescriptor.CreateProperty( _
                prop.GetType(), prop, atts)
        End Sub
        '</Snippet4>
    End Class
    '</Snippet3>
end namespace

