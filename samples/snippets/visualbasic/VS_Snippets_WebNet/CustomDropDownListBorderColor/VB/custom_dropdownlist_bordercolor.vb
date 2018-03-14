' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomDropDownListBorderColor
        Inherits System.Web.UI.WebControls.DropDownList

        Public Overrides Property BorderColor() As System.Drawing.Color
            ' NOTE: The BorderColor property is inherited from the WebControl 
            ' class and is not applicable to the DropDownList control. 
            Get
                Return MyBase.BorderColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.BorderColor = Value
            End Set
        End Property

        Public Overrides Property BorderStyle() As System.Web.UI.WebControls.BorderStyle
            ' NOTE: The BorderStyle property is inherited from the WebControl 
            ' class and is not applicable to the DropDownList control. 
            Get
                Return MyBase.BorderStyle
            End Get
            Set(ByVal Value As System.Web.UI.WebControls.BorderStyle)
                MyBase.BorderStyle = Value
            End Set
        End Property

        Public Overrides Property BorderWidth() As System.Web.UI.WebControls.Unit
            ' NOTE: The BorderWidth property is inherited from the WebControl 
            ' class and is not applicable to the DropDownList control. 
            Get
                Return MyBase.BorderWidth
            End Get
            Set(ByVal Value As System.Web.UI.WebControls.Unit)
                MyBase.BorderWidth = Value
            End Set
        End Property

        Public Overrides Property ToolTip() As String
            ' NOTE: The ToolTip property is inherited from the WebControl 
            ' class and is not applicable to the DropDownList control. 
            Get
                Return MyBase.ToolTip
            End Get
            Set(ByVal Value As String)
                MyBase.ToolTip = Value
            End Set
        End Property
    End Class
End Namespace
' </Snippet2>