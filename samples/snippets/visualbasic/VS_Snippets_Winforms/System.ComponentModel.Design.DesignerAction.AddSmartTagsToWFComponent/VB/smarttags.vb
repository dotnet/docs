
'<snippet1>
'///////////////////////////////////////////////////////////////////
'Pull model smart tag example.
'Need references to System.dll, System.Windows.Forms.dll, 
' System.Design.dll, and System.Drawing.dll.
'///////////////////////////////////////////////////////////////////
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Text
Imports System.Reflection

Namespace SmartTags

    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private colorLabel2 As ColorLabel

        Public Sub New()
            InitializeComponent()
        End Sub

        'VS Forms Designer generated method
        Private Sub InitializeComponent()
            Me.colorLabel2 = New ColorLabel
            Me.SuspendLayout()
            '
            'colorLabel2
            '
            Me.colorLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.colorLabel2.ColorLocked = False
            Me.colorLabel2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.colorLabel2.Location = New System.Drawing.Point(41, 42)
            Me.colorLabel2.Name = "colorLabel2"
            Me.colorLabel2.Size = New System.Drawing.Size(117, 25)
            Me.colorLabel2.TabIndex = 0
            Me.colorLabel2.Text = "ColorLabel"
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(Me.colorLabel2)
            Me.Name = "Form1"
            Me.ResumeLayout(False)

        End Sub

        <STAThread()> _
        Shared Sub Main()
            Dim f1 As New Form1()
            f1.ShowDialog()
        End Sub
    End Class

    
    '///////////////////////////////////////////////////////////////
    'ColorLabel is a simple extension of the standard Label control,
    ' with color property locking added.
    '///////////////////////////////////////////////////////////////
    <Designer(GetType(ColorLabelDesigner))> _
    Public Class ColorLabel
        Inherits System.Windows.Forms.Label

        Private colorLockedValue As Boolean = False

        Public Property ColorLocked() As Boolean
            Get
                Return colorLockedValue
            End Get
            Set(ByVal value As Boolean)
                colorLockedValue = value
            End Set
        End Property

        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As Color)
                If ColorLocked Then
                    Return
                Else
                    MyBase.BackColor = value
                End If
            End Set
        End Property

        Public Overrides Property ForeColor() As Color
            Get
                Return MyBase.ForeColor
            End Get
            Set(ByVal value As Color)
                If ColorLocked Then
                    Return
                Else
                    MyBase.ForeColor = value
                End If
            End Set
        End Property
    End Class
    
    '///////////////////////////////////////////////////////////////
    'Designer for the ColorLabel control with support for a smart 
    ' tag panel.
    '///////////////////////////////////////////////////////////////
    'Must add reference to System.Design.dll
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class ColorLabelDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        '<snippet8>
        Private lists As DesignerActionListCollection
        '</snippet8>

        'Use pull model to populate smart tag menu.
        '<snippet9>
        Public Overrides ReadOnly Property ActionLists() _
        As DesignerActionListCollection
            Get
                If lists Is Nothing Then
                    lists = New DesignerActionListCollection()
                    lists.Add( _
                    New ColorLabelActionList(Me.Component))
                End If
                Return lists
            End Get
        End Property
        '</snippet9>
    End Class
    
    '///////////////////////////////////////////////////////////////
    'DesignerActionList-derived class defines smart tag entries and
    ' resultant actions.
    '///////////////////////////////////////////////////////////////
    '<snippet2>
    Public Class ColorLabelActionList
        Inherits System.ComponentModel.Design.DesignerActionList
        '</snippet2>

        '<snippet3>
        Private colLabel As ColorLabel
        '</snippet3>

        '<snippet10>
        Private designerActionUISvc As DesignerActionUIService = Nothing
        '</snippet10>

        'The constructor associates the control 
        'with the smart tag list.
        '<snippet4>
        Public Sub New(ByVal component As IComponent)

            MyBase.New(component)
            Me.colLabel = component

            ' Cache a reference to DesignerActionUIService, so the
            ' DesigneractionList can be refreshed.
            Me.designerActionUISvc = _
            CType(GetService(GetType(DesignerActionUIService)), _
            DesignerActionUIService)

        End Sub
        '</snippet4>

        'Helper method to retrieve control properties. Use of 
        ' GetProperties enables undo and menu updates to work properly.
        Private Function GetPropertyByName(ByVal propName As String) _
        As PropertyDescriptor
            Dim prop As PropertyDescriptor
            prop = TypeDescriptor.GetProperties(colLabel)(propName)
            If prop Is Nothing Then
                Throw New ArgumentException( _
                "Matching ColorLabel property not found!", propName)
            Else
                Return prop
            End If
        End Function

        'Properties that are targets of DesignerActionPropertyItem entries.
        Public Property BackColor() As Color
            Get
                Return colLabel.BackColor
            End Get
            Set(ByVal value As Color)
                GetPropertyByName("BackColor").SetValue(colLabel, value)
            End Set
        End Property

        '<snippet5>
        Public Property ForeColor() As Color
            Get
                Return colLabel.ForeColor
            End Get
            Set(ByVal value As Color)
                GetPropertyByName("ForeColor").SetValue(colLabel, value)
            End Set
        End Property
        '</snippet5>

        '<snippet11>
        'Boolean properties are automatically displayed with binary 
        ' UI (such as a checkbox).
        Public Property LockColors() As Boolean
            Get
                Return colLabel.ColorLocked
            End Get
            Set(ByVal value As Boolean)
                GetPropertyByName("ColorLocked").SetValue(colLabel, value)

                ' Refresh the list.
                Me.designerActionUISvc.Refresh(Me.Component)
            End Set
        End Property
        '</snippet11>

        Public Property [Text]() As String
            Get
                Return colLabel.Text
            End Get
            Set(ByVal value As String)
                GetPropertyByName("Text").SetValue(colLabel, value)
            End Set
        End Property


        'Method that is target of a DesignerActionMethodItem
        '<snippet6>
        Public Sub InvertColors()
            Dim currentBackColor As Color = colLabel.BackColor
            BackColor = Color.FromArgb( _
            255 - currentBackColor.R, _
            255 - currentBackColor.G, _
            255 - currentBackColor.B)

            Dim currentForeColor As Color = colLabel.ForeColor
            ForeColor = Color.FromArgb( _
            255 - currentForeColor.R, _
            255 - currentForeColor.G, _
            255 - currentForeColor.B)
        End Sub
        '</snippet6>

        'Implementation of this virtual method creates smart tag  
        ' items, associates their targets, and collects into list.
        '<snippet7>
        Public Overrides Function GetSortedActionItems() _
        As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            'Define static section header entries.
            items.Add(New DesignerActionHeaderItem("Appearance"))
            items.Add(New DesignerActionHeaderItem("Information"))

            'Boolean property for locking color selections.
            items.Add(New DesignerActionPropertyItem( _
            "LockColors", _
            "Lock Colors", _
            "Appearance", _
            "Locks the color properties."))

            If Not LockColors Then
                items.Add( _
                New DesignerActionPropertyItem( _
                "BackColor", _
                "Back Color", _
                "Appearance", _
                "Selects the background color."))

                items.Add( _
                New DesignerActionPropertyItem( _
                "ForeColor", _
                "Fore Color", _
                "Appearance", _
                "Selects the foreground color."))

                'This next method item is also added to the context menu 
                ' (as a designer verb).
                items.Add( _
                New DesignerActionMethodItem( _
                Me, _
                "InvertColors", _
                "Invert Colors", _
                "Appearance", _
                "Inverts the fore and background colors.", _
                True))
            End If
            items.Add( _
            New DesignerActionPropertyItem( _
            "Text", _
            "Text String", _
            "Appearance", _
            "Sets the display text."))

            'Create entries for static Information section.
            Dim location As New StringBuilder("Location: ")
            location.Append(colLabel.Location)
            Dim size As New StringBuilder("Size: ")
            size.Append(colLabel.Size)

            items.Add( _
            New DesignerActionTextItem( _
            location.ToString(), _
            "Information"))

            items.Add( _
            New DesignerActionTextItem( _
            size.ToString(), _
            "Information"))

            Return items
        End Function
        '</snippet7>

    End Class
End Namespace
'</snippet1>
