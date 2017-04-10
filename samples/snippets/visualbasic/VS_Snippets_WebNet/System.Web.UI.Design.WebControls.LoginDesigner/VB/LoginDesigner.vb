' <snippet1>
Imports System
Imports System.Web
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The MyLogin is a copy of the Login.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyLoginDesigner))> _
    Public Class MyLogin
        Inherits Login
    End Class ' MyLogin

    ' Override members of the LoginDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyLoginDesigner
        Inherits LoginDesigner

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

        ' <snippet3>
        ' Shadow the control properties with design-time properties.
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
        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the control more visible in the designer.  If the border 
            ' style is None or NotSet, change the border to a blue dashed line. 
            Dim myLoginCtl As MyLogin = CType(ViewControl, MyLogin)
            Dim markup As String = Nothing

            ' Check if the border style should be changed.
            If (myLoginCtl.BorderStyle = BorderStyle.NotSet Or _
                myLoginCtl.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myLoginCtl.BorderStyle
                Dim oldBorderColor As Color = myLoginCtl.BorderColor

                ' Set the design time properties and catch any exceptions.
                Try
                    myLoginCtl.BorderStyle = BorderStyle.Dashed
                    myLoginCtl.BorderColor = Color.Blue

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' It is not necessary to restore the border properties 
                    ' to their original values because the ViewControl 
                    ' was used to reference the associated control and the 
                    ' UsePreviewControl was not overridden.  

                    ' myLoginCtl.BorderStyle = oldBorderStyle
                    ' myLoginCtl.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup

        End Function ' GetDesignTimeHtml
        ' </snippet4>
    End Class ' MyLoginDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
