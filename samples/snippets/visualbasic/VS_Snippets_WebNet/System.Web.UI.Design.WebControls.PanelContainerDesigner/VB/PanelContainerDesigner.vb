' PanelContainerDesigner.vb
' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' <snippet2>
    ' The MyPanelContainer is a copy of the PanelContainer.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyPanelContainerDesigner))> _
    Public Class MyPanelContainer
        Inherits Panel
    End Class ' MyPanelContainer
    ' </snippet2>

    ' Override members of the PanelContainerDesigner.
    Public Class MyPanelContainerDesigner
        Inherits PanelContainerDesigner

        ' <snippet3>
        ' Provide a design-time caption for the panel.
        Public Overrides ReadOnly Property FrameCaption() As String
            Get
                ' If the FrameCaption is empty, use the panel control ID.
                Dim localCaption As String = MyBase.FrameCaption
                If localCaption Is Nothing Or localCaption = "" Then
                    localCaption = CType(Component, Panel).ID.ToString()
                End If

                Return localCaption
            End Get
        End Property ' FrameCaption
        ' </snippet3>

        ' <snippet4>
        ' Provide a design-time border style for the panel.
        Public Overrides ReadOnly Property FrameStyle() As Style
            Get
                Dim styleOfFrame As Style = MyBase.FrameStyle

                ' If no border style is defined, define one.
                If (styleOfFrame.BorderStyle = BorderStyle.NotSet Or _
                    styleOfFrame.BorderStyle = BorderStyle.None) Then
                    styleOfFrame.BorderStyle = BorderStyle.Outset
                End If

                Return styleOfFrame
            End Get
        End Property ' FrameStyle
        ' </snippet4>

        ' <snippet5>
        ' Initialize the designer.
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyPanelContainer can be created   
            ' in this designer. 
            If Not TypeOf component Is MyPanelContainer Then
                Throw New ArgumentException()
            End If

            MyBase.Initialize(component)

        End Sub ' Initialize
        ' </snippet5>
    End Class ' MyPanelContainerDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
