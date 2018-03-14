' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.IO

Namespace Examples.VB.WebControls.Design

    ' The MyLoginView is a copy of the LoginView.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyLoginViewDesigner))> _
    Public Class MyLoginView
        Inherits LoginView
    End Class ' MyLoginView

    ' Override members of the LoginViewDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyLoginViewDesigner
        Inherits LoginViewDesigner

        ' <snippet2>
        ' Generate the design-time markup for the control when an error occurs.
        Protected Overrides Function GetErrorDesignTimeHtml( _
            ByVal ex As Exception) As String

            ' Write the error message text in red, bold.
            Dim errorRendering As String = _
                "<span style=""font-weight:bold; color:Red; "">" & _
                ex.Message & "</span>"

            Return CreatePlaceHolderDesignTimeHtml(errorRendering)

        End Function ' GetErrorDesignTimeHtml
        ' </snippet2>

        ' <snippet5>
        ' Generate the design-time markup for the control 
        ' when the template is empty.
        Protected Overrides Function GetEmptyDesignTimeHtml() As String

            ' Generate a design-time placeholder containing the names of all
            ' the role groups.
            Dim myLoginViewCtl As MyLoginView = CType(ViewControl, MyLoginView)
            Dim roleGroups As RoleGroupCollection = myLoginViewCtl.RoleGroups
            Dim RoleNames As String = Nothing
            Dim rgX As Integer

            ' If there are any role groups, form a string of their names.
            If roleGroups.Count > 0 Then

                roleNames = "Role Groups: <br /> &nbsp;&nbsp;" & _
                    roleGroups(0).ToString()

                For rgX = 1 To roleGroups.Count - 1
                    roleNames &= "<br /> &nbsp;&nbsp;" & _
                        roleGroups(rgX).ToString()
                Next rgX
            End If

            Return CreatePlaceHolderDesignTimeHtml(roleNames)

        End Function ' GetEmptyDesignTimeHtml
        ' </snippet5>

        ' <snippet3>
        ' Shadow control properties with design-time properties.
        Protected Overrides Sub PreFilterProperties( _
            ByVal properties As IDictionary)

            ' Call the base method first.
            MyBase.PreFilterProperties(properties)

            ' Make the NamingContainer visible in the Properties grid.
            Dim selectProp As PropertyDescriptor = _
                CType(properties("NamingContainer"), PropertyDescriptor)
            properties("NamingContainer") = _
                TypeDescriptor.CreateProperty(selectProp.ComponentType, _
                    selectProp, BrowsableAttribute.Yes)

        End Sub ' PreFilterProperties
        ' </snippet3>

        ' <snippet4>
        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml( _
            ByVal regions As DesignerRegionCollection) As String

            ' Make the control more visible in the designer.  
            ' Enclose the markup in a table with an orange border. 
            Dim openTableMarkup As String = _
                "<table><tr><td style=""border:4 solid #FF7F00;"">"
            Dim closeTableMarkup As String = "</td></tr></table>"

            ' Call the base method to generate the markup.
            Dim markup As String = MyBase.GetDesignTimeHtml(regions)

            Return openTableMarkup & markup & closeTableMarkup

        End Function ' GetDesignTimeHtml
        ' </snippet4>

        ' <snippet6>
        ' Generate the design time markup.
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyLoginView can be created in this designer. 
            If Not TypeOf component Is MyLoginView Then
                Throw New ArgumentException()
            End If

            ' Call the base method to generate the markup.
            MyBase.Initialize(component)

        End Sub ' Initialize
        ' </snippet6>
    End Class ' MyLoginViewDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
