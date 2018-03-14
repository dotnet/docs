'<snippet1>
Option Strict On
Option Explicit On 
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace Microsoft.Samples.WinForms.Vb.HelpLabel
    '
    ' <doc>
    ' <desc>
    ' Help Label offers an extender property called
    ' HelpText.  It monitors the active control
    ' and displays the help text for the active control.
    ' </desc>
    ' </doc>
    '

    <ProvideProperty("HelpText", GetType(Control)), Designer(GetType(HelpLabel.HelpLabelDesigner))> _
    Public Class HelpLabel
        Inherits Control
        Implements System.ComponentModel.IExtenderProvider
        ' <summary>
        '    Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container
        Private helpTexts As Hashtable
        Private activeControl As System.Windows.Forms.Control

        '
        ' <doc>
        ' <desc>
        '      Creates a new help label object.
        ' </desc>
        ' </doc>
        '
        Public Sub New()
            '
            ' Required for Windows Form designer support.
            '
            InitializeComponent()
            helpTexts = New Hashtable
        End Sub

        ' <summary>
        '    Clean up any resources being used.
        ' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' <summary>
        '    Required method for designer support. Do not modify
        '    the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.BackColor = System.Drawing.SystemColors.Info
            Me.ForeColor = System.Drawing.SystemColors.InfoText
            Me.TabStop = False
        End Sub
        '
        ' <doc>
        ' <desc>
        '      Overrides the text property of Control.  This label ignores
        '      the text property, so we add additional attributes here so the
        '      property does not show up in the Properties window and is not
        '      persisted.
        ' </desc>
        ' </doc>
        '
        <Browsable(False), _
        EditorBrowsable(EditorBrowsableState.Never), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property [Text]() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal Value As String)
                MyBase.Text = Value
            End Set
        End Property


        '
        ' <doc>
        ' <desc>
        '      This implements the IExtenderProvider.CanExtend method.  The
        '      help label provides an extender property, and the design-time
        '      framework will call this method once for each component to determine
        '      if we are interested in providing our extended properties for the
        '      component.  We return true here if the object is a control and is
        '      not a HelpLabel (because it would not be meaningful to add this property to
        '      ourselves).
        ' </desc>
        ' </doc>
        '
        Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
            If TypeOf target Is Control And Not TypeOf target Is HelpLabel Then

                Return True
            End If
            Return False
        End Function

        '
        ' <doc>
        ' <desc>
        '      This is the extended property for the HelpText property.  Extended
        '      properties are actual methods because they take an additional parameter
        '      that is the object or control to provide the property for.
        ' </desc>
        ' </doc>
        '
        <DefaultValue("")> _
        Public Function GetHelpText(ByVal ctrl As Control) As String
            Dim myText As String = CStr(helpTexts(ctrl))
            If myText Is Nothing Then
                myText = String.Empty
            End If
            Return myText
        End Function

        '
        ' <doc>
        ' <desc>
        '      This is the extended property for the HelpText property.
        ' </desc>
        ' </doc>
        '
        Public Sub SetHelpText(ByVal ctrl As Control, ByVal value As String)
            If value Is Nothing Then
                value = String.Empty
            End If

            If value.Length = 0 Then
                helpTexts.Remove(ctrl)

                RemoveHandler ctrl.Enter, AddressOf OnControlEnter
                RemoveHandler ctrl.Leave, AddressOf OnControlLeave
            Else
                helpTexts(ctrl) = value
                AddHandler ctrl.Enter, AddressOf OnControlEnter
                AddHandler ctrl.Leave, AddressOf OnControlLeave
            End If

            If ctrl Is activeControl Then
                Invalidate()
            End If
        End Sub

        '
        ' <doc>
        ' <desc>
        '      This is an event handler that responds to the OnControlEnter
        '      event.  We attach this to each control we are providing help
        '      text for.
        ' </desc>
        ' </doc>
        '
        Private Sub OnControlEnter(ByVal sender As Object, ByVal e As EventArgs)
            activeControl = CType(sender, Control)
            Invalidate()
        End Sub

        '
        ' <doc>
        ' <desc>
        '      This is an event handler that responds to the OnControlLeave
        '      event.  We attach this to each control we are providing help
        '      text for.
        ' </desc>
        ' </doc>
        '
        Private Sub OnControlLeave(ByVal sender As Object, ByVal e As EventArgs)
            If sender Is activeControl Then
                activeControl = Nothing
                Invalidate()
            End If
        End Sub

        '
        ' <doc>
        ' <desc>
        '      Overrides Control.OnPaint.  Here we draw our
        '      label.
        ' </desc>
        ' </doc>
        '
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            ' Let the base draw.  This will cover our back
            ' color and set any image that the user has
            ' provided.
            '
            MyBase.OnPaint(pe)

            ' Draw a rectangle around the control.
            '
            Dim rect As Rectangle = ClientRectangle

            Dim borderPen As New Pen(ForeColor)
            pe.Graphics.DrawRectangle(borderPen, rect)
            borderPen.Dispose()

            ' Finally, draw the text over the top of the
            ' rectangle.
            '
            If (activeControl IsNot Nothing) Then
                Dim myText As String = CStr(helpTexts(activeControl))
                If (myText IsNot Nothing) And myText.Length > 0 Then
                    rect.Inflate(-2, -2)
                    Dim brush As New SolidBrush(ForeColor)
                    pe.Graphics.DrawString(myText, Font, brush, RectangleF.op_Implicit(rect))
                    brush.Dispose()
                End If
            End If
        End Sub


        ' <doc>
        ' <desc>
        '     Returns true if backColor should be persisted in code gen.  We
        '      override this because we change the default back color.
        ' </desc>
        ' <retvalue>
        '     true if the backColor should be persisted.
        ' </retvalue>
        ' </doc>
        '
        Public Function ShouldSerializeBackColor() As Boolean
            Return Not BackColor.Equals(SystemColors.Info)
        End Function


        ' <doc>
        ' <desc>
        '     Returns true if foreColor should be persisted in code gen.  We
        '      override this because we change the default foreground color.
        ' </desc>
        ' <retvalue>
        '     true if foreColor should be persisted.
        ' </retvalue>
        ' </doc>
        '
        Public Function ShouldSerializeForeColor() As Boolean
            Return Not ForeColor.Equals(SystemColors.InfoText)
        End Function

        '<snippet2>
        '
        ' <doc>
        ' <desc>
        '      This is a designer for the HelpLabel.  This designer provides
        '      design time feedback for the label.  The help label responds
        '      to changes in the active control, but these events do not
        '      occur at design time.  In order to provide some usable feedback
        '      that the control is working the right way, this designer listens
        '      to selection change events and uses those events to trigger active
        '      control changes.
        ' </desc>
        ' </doc>
        '
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Public Class HelpLabelDesigner
            Inherits System.Windows.Forms.Design.ControlDesigner

            Private _trackSelection As Boolean = True

            ' <summary>
            ' This property is added to the control's set of properties in the method
            ' PreFilterProperties below.  Note that on designers, properties that are
            ' explictly declared by TypeDescriptor.CreateProperty can be declared as
            ' private on the designer.  This helps to keep the designer's public
            ' object model clean.
            ' </summary>
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
            Private Property TrackSelection() As Boolean
                Get
                    Return _trackSelection
                End Get
                Set(ByVal Value As Boolean)
                    _trackSelection = Value
                    If _trackSelection Then
                        Dim ss As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                        If (ss IsNot Nothing) Then
                            UpdateHelpLabelSelection(ss)
                        End If
                    Else
                        Dim helpLabel As HelpLabel = CType(Control, HelpLabel)
                        If (helpLabel.activeControl IsNot Nothing) Then
                            helpLabel.activeControl = Nothing
                            helpLabel.Invalidate()
                        End If
                    End If
                End Set
            End Property

            Public Overrides ReadOnly Property Verbs() As DesignerVerbCollection
                Get
                    Dim myVerbs() As DesignerVerb = {New DesignerVerb("Sample Verb", AddressOf OnSampleVerb)}
                    Return New DesignerVerbCollection(myVerbs)
                End Get
            End Property

            '
            ' <doc>
            ' <desc>
            '      Overrides Dispose.  Here we remove our handler for the selection changed
            '      event.  With designers, it is critical that they clean up any events they
            '      have attached.  Otherwise, during the course of an editing session many
            '      designers might get created and never destroyed.
            ' </desc>
            ' </doc>
            '
            Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
                If disposing Then
                    Dim ss As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                    If (ss IsNot Nothing) Then
                        RemoveHandler ss.SelectionChanged, AddressOf OnSelectionChanged
                    End If
                End If
                MyBase.Dispose(disposing)
            End Sub

            '
            ' <doc>
            ' <desc>
            '       Overrides initialize.  Here we add an event handler to the selection service.
            '      Notice that we are very careful not to assume that the selection service is
            '      available.  It is entirely optional that a service is available and you should
            '      always degrade gracefully if a service cannot be found.
            ' </desc>
            ' </doc>
            '
            Public Overrides Sub Initialize(ByVal component As IComponent)
                MyBase.Initialize(component)

                Dim ss As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                If (ss IsNot Nothing) Then
                    AddHandler ss.SelectionChanged, AddressOf OnSelectionChanged
                End If
            End Sub

            Private Sub OnSampleVerb(ByVal sender As Object, ByVal e As EventArgs)
                MessageBox.Show("You have just invoked a sample verb.  Normally, this would do something interesting.")
            End Sub

            '
            ' <doc>
            ' <desc>
            '      The handler for the selection change event.  Here we update the active control within
            '      the help label.
            ' </desc>
            ' </doc>
            '
            Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
                If _trackSelection Then
                    Dim ss As ISelectionService = CType(sender, ISelectionService)
                    UpdateHelpLabelSelection(ss)
                End If
            End Sub

            Protected Overrides Sub PreFilterProperties(ByVal properties As IDictionary)
                ' Always call base first in PreFilter* methods, and last in PostFilter*
                ' methods.
                MyBase.PreFilterProperties(properties)

                ' We add a design-time property called TrackSelection that is used to track
                ' the active selection.  If the user sets this to true (the default), then
                ' we will listen to selection change events and update the control's active
                ' control to point to the current primary selection.
                properties("TrackSelection") = TypeDescriptor.CreateProperty( _
                   Me.GetType(), _
                   "TrackSelection", _
                   GetType(Boolean), _
                   New Attribute() {CategoryAttribute.Design})
            End Sub

            ' <summary>
            ' This is a helper method that, given a selection service, will update the active control
            ' of the help label with the currently active selection.
            ' </summary>
            ' <param name="ss"></param>
            Private Sub UpdateHelpLabelSelection(ByVal ss As ISelectionService)
                Dim c As Control = CType(ss.PrimarySelection, Control)
                Dim helpLabel As HelpLabel = CType(Control, HelpLabel)
                If (c IsNot Nothing) Then
                    helpLabel.activeControl = c
                    helpLabel.Invalidate()
                Else
                    If (helpLabel.activeControl IsNot Nothing) Then
                        helpLabel.activeControl = Nothing
                        helpLabel.Invalidate()
                    End If
                End If
            End Sub

            Public Sub New()

            End Sub
        End Class
        '</snippet2>

    End Class
End Namespace
'</snippet1>