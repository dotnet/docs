'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design

Namespace ASPNet.Design.Samples

    ' Set an attribute reference to the designer, and define 
    ' the HTML markup that the toolbox will write into the source.
    <Designer(GetType(TemplateGroupsSampleDesigner)), _
        ToolboxData("<{0}:TemplateGroupsSample runat=server></{0}:TemplateGroupsSample>")> _
    Public Class TemplateGroupsSample
        Inherits WebControl
        Implements INamingContainer

        ' Field for the templates
        Private _templates() As ITemplate

        ' Constructor
        Public Sub New()
            ReDim _templates(4)
        End Sub

        ' For each template property, set the designer attributes 
        ' so the property does not appear in the property grid, but 
        ' changes to the template are persisted in the control.
        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Property Template1() As ITemplate
            Get
                Return _templates(0)
            End Get
            Set(ByVal Value As ITemplate)
                _templates(0) = Value
            End Set
        End Property
        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Property Template2() As ITemplate
            Get
                Return _templates(1)
            End Get
            Set(ByVal Value As ITemplate)
                _templates(1) = Value
            End Set
        End Property
        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Property Template3() As ITemplate
            Get
                Return _templates(2)
            End Get
            Set(ByVal Value As ITemplate)
                _templates(2) = Value
            End Set
        End Property
        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Property Template4() As ITemplate
            Get
                Return _templates(3)
            End Get
            Set(ByVal Value As ITemplate)
                _templates(3) = Value
            End Set
        End Property

        Protected Overrides Sub CreateChildControls()
            ' Instantiate the template inside the panel
            ' then add the panel to the Controls collection
            Dim i As Integer

            For i = 0 To 3
                Dim pan As New Panel()
                _templates(i).InstantiateIn(pan)
                Me.Controls.Add(pan)
            Next
        End Sub

    End Class

    ' Designer for the TemplateGroupsSample class
    Public Class TemplateGroupsSampleDesigner
        Inherits System.Web.UI.Design.ControlDesigner

        Private col As TemplateGroupCollection = Nothing

        '<Snippet5>
        Public Overrides Sub Initialize(ByVal Component As IComponent)
            ' Initialize the base
            MyBase.Initialize(Component)
            ' Turn on template editing
            SetViewFlags(ViewFlags.TemplateEditing, True)
        End Sub
        '</Snippet5>

        '<Snippet4>
        ' Add instructions to the placeholder view of the control
        Public Overloads Overrides Function GetDesignTimeHtml() As String
            Return CreatePlaceHolderDesignTimeHtml("Click here and use " & _
                "the task menu to edit the templates.")
        End Function
        '</Snippet4>

        Public Overrides ReadOnly Property TemplateGroups() As TemplateGroupCollection
            Get
                If IsNothing(col) Then
                    ' Get the base collection
                    col = MyBase.TemplateGroups

                    ' Create variables
                    Dim tempGroup As TemplateGroup
                    Dim tempDef As TemplateDefinition
                    Dim ctl As TemplateGroupsSample

                    ' Get reference to the component as TemplateGroupsSample
                    ctl = CType(Component, TemplateGroupsSample)

                    ' Create a TemplateGroup
                    tempGroup = New TemplateGroup("Template Set A")

                    ' Create a TemplateDefinition
                    tempDef = New TemplateDefinition(Me, "Template A1", ctl, "Template1", True)

                    ' Add the TemplateDefinition to the TemplateGroup
                    tempGroup.AddTemplateDefinition(tempDef)

                    ' Create another TemplateDefinition
                    tempDef = New TemplateDefinition(Me, "Template A2", ctl, "Template2", True)

                    ' Add the TemplateDefinition to the TemplateGroup
                    tempGroup.AddTemplateDefinition(tempDef)

                    ' Add the TemplateGroup to the TemplateGroupCollection
                    col.Add(tempGroup)

                    ' Create another TemplateGroup and populate it
                    tempGroup = New TemplateGroup("Template Set B")
                    tempDef = New TemplateDefinition(Me, "Template B1", ctl, "Template3", True)
                    tempGroup.AddTemplateDefinition(tempDef)
                    tempDef = New TemplateDefinition(Me, "Template B2", ctl, "Template4", True)
                    tempGroup.AddTemplateDefinition(tempDef)

                    ' Add the TemplateGroup to the TemplateGroupCollection
                    col.Add(tempGroup)
                End If

                Return col
            End Get
        End Property

        '<Snippet3>
        ' Do not allow direct resizing unless in TemplateMode
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                If Me.InTemplateMode Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        '</Snippet3>
    End Class
End Namespace
'</Snippet1>