' <Snippet1>
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design

Namespace Samples.AspNet.VB.Controls
    < _
    AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    Designer(GetType(VacationHomeDesigner)), _
    DefaultProperty("Title"), _
    ToolboxData( _
        "<{0}:VacationHome runat=""server""> </{0}:VacationHome>") _
    > _
    Public Class VacationHome
        Inherits CompositeControl
        Private _template As ITemplate
        Private _owner As TemplateOwner

        < _
        Bindable(True), _
        Category("Data"), _
        DefaultValue(""), _
        Description("Caption") _
        > _
        Public Overridable Property Caption() As String
            Get
                Dim s As String = CStr(ViewState("Caption"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Caption") = value
            End Set
        End Property

        < _
        Browsable(False), _
        DesignerSerializationVisibility( _
            DesignerSerializationVisibility.Hidden) _
        > _
        Public ReadOnly Property Owner() As TemplateOwner
            Get
                Return _owner
            End Get
        End Property

        < _
        Browsable(False), _
        PersistenceMode(PersistenceMode.InnerProperty), _
    DefaultValue(GetType(ITemplate), ""), _
    Description("Control template"), _
        TemplateContainer(GetType(VacationHome)) _
        > _
        Public Overridable Property Template() As ITemplate
            Get
                Return _template
            End Get
            Set(ByVal value As ITemplate)
                _template = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Data"), _
        DefaultValue(""), _
        Description("Title"), _
        Localizable(True) _
        > _
        Public Property Title() As String
            Get
                Dim s As String = CStr(ViewState("Title"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Title") = value
            End Set
        End Property


        Protected Overrides Sub CreateChildControls()
            Controls.Clear()
            _owner = New TemplateOwner()

            Dim temp As ITemplate = _template
            If temp Is Nothing Then
                temp = New DefaultTemplate
            End If

            temp.InstantiateIn(_owner)
            Me.Controls.Add(_owner)
        End Sub

        Public Overrides Sub DataBind()
            CreateChildControls()
            ChildControlsCreated = True
            MyBase.DataBind()
        End Sub


    End Class

    <ToolboxItem(False)> _
    Public Class TemplateOwner
        Inherits WebControl
    End Class

#Region "DefaultTemplate"
    NotInheritable Class DefaultTemplate
        Implements ITemplate

        Sub InstantiateIn(ByVal owner As Control) _
            Implements ITemplate.InstantiateIn
            Dim title As New Label
            AddHandler title.DataBinding, AddressOf title_DataBinding
            Dim linebreak As New LiteralControl("<br/>")
            Dim caption As New Label
            AddHandler caption.DataBinding, _
                AddressOf caption_DataBinding
            owner.Controls.Add(title)
            owner.Controls.Add(linebreak)
            owner.Controls.Add(caption)
        End Sub

        Sub caption_DataBinding(ByVal sender As Object, _
            ByVal e As EventArgs)
            Dim source As Label = CType(sender, Label)
            Dim container As VacationHome = _
                CType(source.NamingContainer, VacationHome)
            source.Text = container.Caption
        End Sub


        Sub title_DataBinding(ByVal sender As Object, _
            ByVal e As EventArgs)
            Dim source As Label = CType(sender, Label)
            Dim container As VacationHome = _
                CType(source.NamingContainer, VacationHome)
            source.Text = container.Caption
        End Sub
    End Class
#End Region


    Public Class VacationHomeDesigner
        Inherits ControlDesigner

        Public Overrides Sub Initialize(ByVal Component As IComponent)
            MyBase.Initialize(Component)
            SetViewFlags(ViewFlags.TemplateEditing, True)
        End Sub

        Public Overloads Overrides Function GetDesignTimeHtml() As String
            Return "<span>This is design-time HTML</span>"
        End Function

        Public Overrides ReadOnly Property TemplateGroups() As TemplateGroupCollection
            Get
                Dim collection As New TemplateGroupCollection
                Dim group As TemplateGroup
                Dim template As TemplateDefinition
                Dim control As VacationHome

                control = CType(Component, VacationHome)
                group = New TemplateGroup("Item")
                template = New TemplateDefinition(Me, "Template", control, "Template", True)
                group.AddTemplateDefinition(template)
                collection.Add(group)
                Return collection
            End Get
        End Property
    End Class

End Namespace
' </Snippet1>
