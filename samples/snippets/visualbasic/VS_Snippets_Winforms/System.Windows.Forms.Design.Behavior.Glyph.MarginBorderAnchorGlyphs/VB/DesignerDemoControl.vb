 ' <snippet1>
' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.Design.Behavior
' </snippet2>

Public Class Form1
   Inherits Form
   Private demoControl1 As DemoControl
   Private demoControl2 As DemoControl
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
    End Sub
   
   
   Private Sub InitializeComponent()
        Me.demoControl2 = New DemoControl
        Me.demoControl1 = New DemoControl
        Me.SuspendLayout()
        '
        'demoControl2
        '
        Me.demoControl2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.demoControl2.BackColor = System.Drawing.Color.LightBlue
        Me.demoControl2.Location = New System.Drawing.Point(116, 119)
        Me.demoControl2.Margin = New System.Windows.Forms.Padding(20)
        Me.demoControl2.Name = "demoControl2"
        Me.demoControl2.Padding = New System.Windows.Forms.Padding(20)
        Me.demoControl2.Size = New System.Drawing.Size(135, 143)
        Me.demoControl2.TabIndex = 1
        '
        'demoControl1
        '
        Me.demoControl1.BackColor = System.Drawing.Color.LightBlue
        Me.demoControl1.Location = New System.Drawing.Point(282, 31)
        Me.demoControl1.Margin = New System.Windows.Forms.Padding(10)
        Me.demoControl1.Name = "demoControl1"
        Me.demoControl1.Padding = New System.Windows.Forms.Padding(10)
        Me.demoControl1.Size = New System.Drawing.Size(268, 251)
        Me.demoControl1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(594, 352)
        Me.Controls.Add(Me.demoControl2)
        Me.Controls.Add(Me.demoControl1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.Text = "a"
        Me.ResumeLayout(False)

    End Sub

    Private Sub demoControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

' This control demonstrates the use of a custom designer.
<DesignerAttribute(GetType(DemoControlDesigner))>  _
Public Class DemoControl
   Inherits UserControl
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   
   Private Sub InitializeComponent()
    End Sub
End Class


' This class demonstrates how to build a custom designer.
' When an instance of the associated control type is created
' in a design environment like Visual Studio, this designer
' provides custom design-time behavior.
'
' When you drop an instance of DemoControl onto a form,
' this designer creates two adorner windows: one is used
' for glyphs that represent the Margin and Padding properties
' of the control, and the other is used for glyphs that
' represent the Anchor property.
'
' The AnchorGlyph type defines an AnchorBehavior type that
' allows you to change the value of the Anchor property 
' by double-clicking on an AnchorGlyph.
'
' This designer also offers a smart tag for changing the 
' Anchor property.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class DemoControlDesigner
    Inherits ControlDesigner

    ' This adorner holds the glyphs that represent the Anchor property.
    Private anchorAdorner As Adorner = Nothing

    ' This adorner holds the glyphs that represent the Margin and
    ' Padding properties.
    Private marginAndPaddingAdorner As Adorner = Nothing

    ' This defines the size of the anchor glyphs.
    Private Const glyphSize As Integer = 6

    ' This defines the size of the hit bounds for an AnchorGlyph.
    Private Const hitBoundSize As Integer = glyphSize + 4

    ' References to designer services, for convenience.
    Private changeService As IComponentChangeService = Nothing
    Private selectionService As ISelectionService = Nothing
    Private behaviorSvc As BehaviorService = Nothing

    ' This is the collection of DesignerActionLists that
    ' defines the smart tags offered on the control. 
    Private actionListColl As DesignerActionListCollection = Nothing


    Public Sub New()
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            If (Me.behaviorSvc IsNot Nothing) Then
                ' Remove the adorners added by this designer from
                ' the BehaviorService.Adorners collection.
                Me.behaviorSvc.Adorners.Remove(Me.marginAndPaddingAdorner)
                Me.behaviorSvc.Adorners.Remove(Me.anchorAdorner)
            End If
        End If

        MyBase.Dispose(disposing)

    End Sub


    ' <snippet7>
    ' This method is where the designer initializes its state when
    ' it is created.
    Public Overrides Sub Initialize(ByVal component As IComponent)
        MyBase.Initialize(component)

        ' Connect to various designer services.
        InitializeServices()

        ' Initialize adorners.
        Me.InitializeMarginAndPaddingAdorner()
        Me.InitializeAnchorAdorner()
    End Sub
    ' </snippet7>

    ' <snippet3>
    ' This demonstrates changing the appearance of a control while
    ' it is being designed. In this case, the BackColor property is
    ' set to LightBlue. 
    Public Overrides Sub InitializeNewComponent( _
    ByVal defaultValues As IDictionary)

        MyBase.InitializeNewComponent(defaultValues)

        Dim colorPropDesc As PropertyDescriptor = _
        TypeDescriptor.GetProperties(Component)("BackColor")

        If colorPropDesc IsNot Nothing AndAlso _
           colorPropDesc.PropertyType Is GetType(Color) AndAlso _
           Not colorPropDesc.IsReadOnly AndAlso _
           colorPropDesc.IsBrowsable Then
            colorPropDesc.SetValue(Component, Color.LightBlue)
        End If
    End Sub
    ' </snippet3>

    ' <snippet8>
    ' This utility method creates an adorner for the anchor glyphs.
    ' It then creates four AnchorGlyph objects and adds them to 
    ' the adorner's Glyphs collection.
    Private Sub InitializeAnchorAdorner()
        Me.anchorAdorner = New Adorner()
        Me.behaviorSvc.Adorners.Add(Me.anchorAdorner)

        Me.anchorAdorner.Glyphs.Add(New AnchorGlyph( _
        AnchorStyles.Left, _
        Me.behaviorSvc, _
        Me.changeService, _
        Me.selectionService, _
        Me, _
        Me.anchorAdorner))

        Me.anchorAdorner.Glyphs.Add(New AnchorGlyph( _
        AnchorStyles.Top, _
        Me.behaviorSvc, _
        Me.changeService, _
        Me.selectionService, _
        Me, _
        Me.anchorAdorner))

        Me.anchorAdorner.Glyphs.Add(New AnchorGlyph( _
        AnchorStyles.Right, _
        Me.behaviorSvc, _
        Me.changeService, _
        Me.selectionService, _
        Me, _
        Me.anchorAdorner))

        Me.anchorAdorner.Glyphs.Add(New AnchorGlyph( _
        AnchorStyles.Bottom, _
        Me.behaviorSvc, _
        Me.changeService, _
        Me.selectionService, _
        Me, _
        Me.anchorAdorner))

    End Sub
    ' </snippet8>

    ' <snippet9>
    ' This utility method creates an adorner for the margin and 
    ' padding glyphs. It then creates a MarginAndPaddingGlyph and 
    ' adds it to the adorner's Glyphs collection.
    Private Sub InitializeMarginAndPaddingAdorner()

        Me.marginAndPaddingAdorner = New Adorner()
        Me.behaviorSvc.Adorners.Add(Me.marginAndPaddingAdorner)

        Me.marginAndPaddingAdorner.Glyphs.Add(New MarginAndPaddingGlyph( _
        Me.behaviorSvc, _
        Me.changeService, _
        Me.selectionService, _
        Me, _
        Me.marginAndPaddingAdorner))

    End Sub
    ' </snippet9>

    ' This utility method connects the designer to various services.
    ' These references are cached for convenience.
    Private Sub InitializeServices()

        ' Acquire a reference to IComponentChangeService.
        Me.changeService = GetService(GetType(IComponentChangeService))

        ' Acquire a reference to ISelectionService.
        Me.selectionService = GetService(GetType(ISelectionService))

        ' Acquire a reference to BehaviorService.
        Me.behaviorSvc = GetService(GetType(BehaviorService))

    End Sub

    ' This method creates the DesignerActionList on demand, causing
    ' smart tags to appear on the control being designed.

    Public Overrides ReadOnly Property ActionLists() As _
    DesignerActionListCollection

        Get
            If actionListColl Is Nothing Then
                actionListColl = New DesignerActionListCollection()
                actionListColl.Add(New AnchorActionList(Me.Component))
            End If

            Return actionListColl
        End Get

    End Property

    ' This class defines the smart tags that appear on the control
    ' being designed. In this case, the Anchor property appears
    ' on the smart tag and its value can be changed through a 
    ' UI Type Editor created automatically by the 
    ' DesignerActionService.

    Public Class AnchorActionList
        Inherits System.ComponentModel.Design.DesignerActionList

        ' Cache a reference to the control.
        Private relatedControl As DemoControl

        'The constructor associates the control 
        'with the smart tag list.
        Public Sub New(ByVal component As IComponent)

            MyBase.New(component)
            Me.relatedControl = component

        End Sub

        ' Properties that are targets of 
        ' DesignerActionPropertyItem entries.
        Public Property Anchor() As AnchorStyles
            Get
                Return Me.relatedControl.Anchor
            End Get
            Set(ByVal value As AnchorStyles)
                Dim pdAnchor As PropertyDescriptor = _
                TypeDescriptor.GetProperties(Me.relatedControl)("Anchor")
                pdAnchor.SetValue(Me.relatedControl, Value)
            End Set
        End Property

        ' This method creates and populates the 
        ' DesignerActionItemCollection which is used to 
        ' display smart tag items.
        Public Overrides Function GetSortedActionItems() As _
        DesignerActionItemCollection

            Dim items As New DesignerActionItemCollection()

            ' Add a descriptive header.
            items.Add(New DesignerActionHeaderItem("Anchor Styles"))

            ' Add a DesignerActionPropertyItem for the Anchor
            ' property. This will be displayed in a panel using
            ' the AnchorStyles UI Type Editor.
            items.Add(New DesignerActionPropertyItem( _
            "Anchor", _
            "Anchor Style"))

            Return items
        End Function
    End Class


#Region "Glyph Implementations"

    '<snippet14>
    ' This class implements a MarginAndPaddingGlyph, which draws 
    ' borders highlighting the value of the control's Margin 
    ' property and the value of the control's Padding property.
    '
    ' This glyph has no mouse or keyboard interaction, so its
    ' related behavior class, MarginAndPaddingBehavior, has no
    ' implementation.

    Public Class MarginAndPaddingGlyph
        Inherits Glyph
        Private behaviorService As BehaviorService = Nothing
        Private changeService As IComponentChangeService = Nothing
        Private selectionService As ISelectionService = Nothing
        Private relatedDesigner As IDesigner = Nothing
        Private marginAndPaddingAdorner As Adorner = Nothing
        Private relatedControl As Control = Nothing


        Public Sub New( _
        ByVal behaviorService As BehaviorService, _
        ByVal changeService As IComponentChangeService, _
        ByVal selectionService As ISelectionService, _
        ByVal relatedDesigner As IDesigner, _
        ByVal marginAndPaddingAdorner As Adorner)

            MyBase.New(New MarginAndPaddingBehavior())
            Me.behaviorService = behaviorService
            Me.changeService = changeService
            Me.selectionService = selectionService
            Me.relatedDesigner = relatedDesigner
            Me.marginAndPaddingAdorner = marginAndPaddingAdorner

            Me.relatedControl = Me.relatedDesigner.Component

            AddHandler Me.changeService.ComponentChanged, _
            AddressOf changeService_ComponentChanged

        End Sub

        ' <snippet13>
        Private Sub changeService_ComponentChanged( _
        ByVal sender As Object, _
        ByVal e As ComponentChangedEventArgs)

            If Object.ReferenceEquals( _
            e.Component, _
            Me.relatedControl) Then
                If e.Member.Name = "Margin" OrElse _
                   e.Member.Name = "Padding" Then
                    Me.marginAndPaddingAdorner.Invalidate()
                End If
            End If

        End Sub
        ' </snippet13>

        ' This glyph has no mouse or keyboard interaction, so 
        ' GetHitTest can return null.
        Public Overrides Function GetHitTest( _
        ByVal p As Point) As Cursor
            Return Nothing
        End Function

        ' This method renders the glyph as a simple focus rectangle.
        Public Overrides Sub Paint(ByVal e As PaintEventArgs)
            ControlPaint.DrawFocusRectangle(e.Graphics, Me.Bounds)

            ControlPaint.DrawFocusRectangle( _
            e.Graphics, _
            Me.PaddingBounds)
        End Sub

        ' This glyph's Bounds property is a Rectangle defined by 
        ' the value of the control's Margin property.

        Public Overrides ReadOnly Property Bounds() As Rectangle
            Get
                Dim c As Control = Me.relatedControl
                Dim controlRect As Rectangle = _
                Me.behaviorService.ControlRectInAdornerWindow( _
                Me.relatedControl)

                Dim boundsVal As New Rectangle( _
                controlRect.Left - c.Margin.Left, _
                controlRect.Top - c.Margin.Top, _
                controlRect.Width + c.Margin.Right * 2, _
                controlRect.Height + c.Margin.Bottom * 2)

                Return boundsVal

            End Get
        End Property

        ' The PaddingBounds property is a Rectangle defined by 
        ' the value of the control's Padding property.

        Public ReadOnly Property PaddingBounds() As Rectangle
            Get
                Dim c As Control = Me.relatedControl
                Dim controlRect As Rectangle = _
                Me.behaviorService.ControlRectInAdornerWindow( _
                Me.relatedControl)

                Dim boundsVal As New Rectangle( _
                controlRect.Left + c.Padding.Left, _
                controlRect.Top + c.Padding.Top, _
                controlRect.Width - c.Padding.Right * 2, _
                controlRect.Height - c.Padding.Bottom * 2)

                Return boundsVal

            End Get
        End Property

        ' There are no keyboard or mouse behaviors associated with 
        ' this glyph, but you could add them to this class.

        Friend Class MarginAndPaddingBehavior
            Inherits System.Windows.Forms.Design.Behavior.Behavior
        End Class

    End Class
    '</snippet14>

    ' <snippet5>
    ' This class implements an AnchorGlyph, which draws grab handles
    ' that represent the value of the control's Anchor property.
    '
    ' This glyph has mouse and keyboard interactions, which are
    ' handled by the related behavior class, AnchorBehavior.
    ' Double-clicking on an AnchorGlyph causes its value to be 
    ' toggled between enabled and disable states. 

    Public Class AnchorGlyph
        Inherits Glyph

        ' This defines the bounds of the anchor glyph.
        Protected boundsValue As Rectangle

        ' This defines the bounds used for hit testing.
        ' These bounds are typically different than the bounds 
        ' of the glyph itself.
        Protected hitBoundsValue As Rectangle

        ' This is the cursor returned if hit test is positive.
        Protected hitTestCursor As Cursor = Cursors.Hand

        ' Cache references to services that will be needed.
        Private behaviorService As BehaviorService = Nothing
        Private changeService As IComponentChangeService = Nothing
        Private selectionService As ISelectionService = Nothing

        ' Keep a reference to the designer for convenience.
        Private relatedDesigner As IDesigner = Nothing

        ' Keep a reference to the adorner for convenience.
        Private anchorAdorner As Adorner = Nothing

        ' Keep a reference to the control being designed.
        Private relatedControl As Control = Nothing

        ' This defines the AnchorStyle which this glyph represents.
        Private anchorStyle As AnchorStyles


        ' <snippet4>
        Public Sub New( _
        ByVal anchorStyle As AnchorStyles, _
        ByVal behaviorService As BehaviorService, _
        ByVal changeService As IComponentChangeService, _
        ByVal selectionService As ISelectionService, _
        ByVal relatedDesigner As IDesigner, _
        ByVal anchorAdorner As Adorner)

            MyBase.New(New AnchorBehavior(relatedDesigner))
            ' Cache references for convenience.
            Me.anchorStyle = anchorStyle
            Me.behaviorService = behaviorService
            Me.changeService = changeService
            Me.selectionService = selectionService
            Me.relatedDesigner = relatedDesigner
            Me.anchorAdorner = anchorAdorner

            ' Cache a reference to the control being designed.
            Me.relatedControl = Me.relatedDesigner.Component

            ' Hook the SelectionChanged event. 
            AddHandler Me.selectionService.SelectionChanged, _
            AddressOf selectionService_SelectionChanged

            ' Hook the ComponentChanged event so the anchor glyphs
            ' can correctly track the control's bounds.
            AddHandler Me.changeService.ComponentChanged, _
            AddressOf changeService_ComponentChanged

        End Sub
        ' </snippet4>

#Region "Overrides"

        Public Overrides ReadOnly Property Bounds() As Rectangle
            Get
                Return Me.boundsValue
            End Get
        End Property


        ' This method renders the AnchorGlyph as a filled rectangle
        ' if the glyph is enabled, or as an open rectangle if the
        ' glyph is disabled.
        Public Overrides Sub Paint(ByVal e As PaintEventArgs)
            If Me.IsEnabled Then
                Dim b As New SolidBrush(Color.Tomato)
                Try
                    e.Graphics.FillRectangle(b, Me.Bounds)
                Finally
                    b.Dispose()
                End Try
            Else
                Dim p As New Pen(Color.Tomato)
                Try
                    e.Graphics.DrawRectangle(p, Me.Bounds)
                Finally
                    p.Dispose()
                End Try
            End If
        End Sub


        ' An AnchorGlyph has keyboard and mouse interaction, so it's
        ' important to return a cursor when the mouse is located in 
        ' the glyph's hit region. When this occurs, the 
        ' AnchorBehavior becomes active.
        Public Overrides Function GetHitTest( _
        ByVal p As Point) As Cursor

            If hitBoundsValue.Contains(p) Then
                Return hitTestCursor
            End If

            Return Nothing

        End Function

#End Region

#Region "Event Handlers"


        ' <snippet12>
        ' The AnchorGlyph objects should mimic the resize glyphs;
        ' they should only be visible when the control is the 
        ' primary selection. The adorner is enabled when the 
        ' control is the primary selection and disabled when 
        ' it is not.
        Private Sub selectionService_SelectionChanged( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            If Object.ReferenceEquals( _
            Me.selectionService.PrimarySelection, _
            Me.relatedControl) Then
                Me.ComputeBounds()
                Me.anchorAdorner.Enabled = True
            Else
                Me.anchorAdorner.Enabled = False
            End If

        End Sub
        ' </snippet12>

        ' If any of several properties change, the bounds of the 
        ' AnchorGlyph must be computed again.
        Private Sub changeService_ComponentChanged( _
        ByVal sender As Object, _
        ByVal e As ComponentChangedEventArgs)

            If Object.ReferenceEquals( _
            e.Component, Me.relatedControl) Then
                If e.Member.Name = "Anchor" OrElse _
                   e.Member.Name = "Size" OrElse _
                   e.Member.Name = "Height" OrElse _
                   e.Member.Name = "Width" OrElse _
                   e.Member.Name = "Location" Then

                    ' Compute the bounds of this glyph.
                    Me.ComputeBounds()

                    ' Tell the adorner to repaint itself.
                    Me.anchorAdorner.Invalidate()

                End If
            End If
        End Sub

#End Region

#Region "Implementation"


        ' This utility method computes the position and size of 
        ' the AnchorGlyph in the Adorner window's coordinates.
        ' It also computes the hit test bounds, which are
        ' slightly larger than the glyph's bounds.
        Private Sub ComputeBounds()
            Dim translatedBounds As New Rectangle( _
            Me.behaviorService.ControlToAdornerWindow(Me.relatedControl), _
            Me.relatedControl.Size)

            If (Me.anchorStyle And AnchorStyles.Top) = AnchorStyles.Top Then
                Me.boundsValue = New Rectangle( _
                translatedBounds.X + translatedBounds.Width / 2 - glyphSize / 2, _
                translatedBounds.Y + glyphSize, _
                glyphSize, _
                glyphSize)
            End If

            If (Me.anchorStyle And AnchorStyles.Bottom) = AnchorStyles.Bottom Then
                Me.boundsValue = New Rectangle( _
                translatedBounds.X + translatedBounds.Width / 2 - glyphSize / 2, _
                translatedBounds.Bottom - 2 * glyphSize, _
                glyphSize, _
                glyphSize)
            End If

            If (Me.anchorStyle And AnchorStyles.Left) = AnchorStyles.Left Then
                Me.boundsValue = New Rectangle( _
                translatedBounds.X + glyphSize, _
                translatedBounds.Y + translatedBounds.Height / 2 - glyphSize / 2, _
                glyphSize, _
                glyphSize)
            End If

            If (Me.anchorStyle And AnchorStyles.Right) = AnchorStyles.Right Then
                Me.boundsValue = New Rectangle( _
                translatedBounds.Right - 2 * glyphSize, _
                translatedBounds.Y + translatedBounds.Height / 2 - glyphSize / 2, _
                glyphSize, _
                glyphSize)
            End If

            Me.hitBoundsValue = New Rectangle( _
            Me.Bounds.Left - hitBoundSize / 2, _
            Me.Bounds.Top - hitBoundSize / 2, _
            hitBoundSize, _
            hitBoundSize)

        End Sub

        ' This utility property determines if the AnchorGlyph is 
        ' enabled, according to the value specified by the 
        ' control's Anchor property.

        Private ReadOnly Property IsEnabled() As Boolean
            Get
                Return (Me.anchorStyle And Me.relatedControl.Anchor) = Me.anchorStyle
            End Get
        End Property

#End Region

        ' </snippet5>


#Region "Behavior Implementation"

        ' <snippet6>
        ' This Behavior specifies mouse and keyboard handling when
        ' an AnchorGlyph is active. This happens when 
        ' AnchorGlyph.GetHitTest returns a non-null value.

        Friend Class AnchorBehavior
            Inherits System.Windows.Forms.Design.Behavior.Behavior
            Private relatedDesigner As IDesigner = Nothing
            Private relatedControl As Control = Nothing


            Friend Sub New(ByVal relatedDesigner As IDesigner)
                Me.relatedDesigner = relatedDesigner
                Me.relatedControl = relatedDesigner.Component
            End Sub

            ' <snippet10>
            ' When you double-click on an AnchorGlyph, the value of 
            ' the control's Anchor property is toggled.
            '
            ' Note that the value of the Anchor property is not set
            ' by direct assignment. Instead, the 
            ' PropertyDescriptor.SetValue method is used. This 
            ' enables notification of the design environment, so 
            ' related events can be raised, for example, the
            ' IComponentChangeService.ComponentChanged event.
            Public Overrides Function OnMouseDoubleClick( _
            ByVal g As Glyph, _
            ByVal button As MouseButtons, _
            ByVal mouseLoc As Point) As Boolean

                MyBase.OnMouseDoubleClick(g, button, mouseLoc)

                If button = MouseButtons.Left Then
                    Dim ag As AnchorGlyph = g

                    Dim pdAnchor As PropertyDescriptor = _
                    TypeDescriptor.GetProperties(ag.relatedControl)("Anchor")

                    If ag.IsEnabled Then
                        ' The glyph is enabled. 
                        ' Clear the AnchorStyle flag to disable the Glyph.
                        pdAnchor.SetValue(ag.relatedControl, _
                        ag.relatedControl.Anchor Xor ag.anchorStyle)
                    Else
                        ' The glyph is disabled. 
                        ' Set the AnchorStyle flag to enable the Glyph.
                        pdAnchor.SetValue(ag.relatedControl, _
                        ag.relatedControl.Anchor Or ag.anchorStyle)
                    End If
                End If

                Return True

            End Function
            ' </snippet10>

        End Class

#End Region

    End Class
    ' </snippet6>

#End Region
End Class

' </snippet1>