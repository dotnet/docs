' <snippet410>
' <snippet420>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet420>

' <snippet430>
Namespace MarqueeControlLibrary.Design

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class MarqueeBorderDesigner
        Inherits ParentControlDesigner
        ' </snippet430>

        Public Sub New()
            Trace.WriteLine("MarqueeBorderDesigner")
        End Sub

        ' <snippet440>
        Public Property Visible() As Boolean
            Get
                Return CBool(ShadowProperties("Visible"))
            End Get
            Set(ByVal Value As Boolean)
                Me.ShadowProperties("Visible") = Value
            End Set
        End Property


        Public Property Enabled() As Boolean
            Get
                Return CBool(ShadowProperties("Enabled"))
            End Get
            Set(ByVal Value As Boolean)
                Me.ShadowProperties("Enabled") = Value
            End Set
        End Property
        ' </snippet440>

        ' <snippet450>
        Protected Overrides Sub PreFilterProperties( _
        ByVal properties As IDictionary)

            MyBase.PreFilterProperties(properties)

            If properties.Contains("Padding") Then
                properties.Remove("Padding")
            End If

            properties("Visible") = _
            TypeDescriptor.CreateProperty(GetType(MarqueeBorderDesigner), _
            CType(properties("Visible"), PropertyDescriptor), _
            New Attribute(-1) {})

            properties("Enabled") = _
            TypeDescriptor.CreateProperty(GetType(MarqueeBorderDesigner), _
            CType(properties("Enabled"), _
            PropertyDescriptor), _
            New Attribute(-1) {})

        End Sub
        ' </snippet450>

        ' <snippet460>
        Private Sub OnVerbRunTest( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            Dim widget As IMarqueeWidget = CType(Me.Control, IMarqueeWidget)
            widget.StartMarquee()

        End Sub


        Private Sub OnVerbStopTest( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            Dim widget As IMarqueeWidget = CType(Me.Control, IMarqueeWidget)
            widget.StopMarquee()

        End Sub
        ' </snippet460>

    End Class
End Namespace
' </snippet410>