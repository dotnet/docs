' <snippet10>
' <snippet20>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet20>

' <snippet97>
' This defines the possible values for the MarqueeBorder
' control's SpinDirection property.
Public Enum MarqueeSpinDirection
   CW
   CCW
End Enum

' <snippet98>
' This defines the possible values for the MarqueeBorder
' control's LightShape property.
Public Enum MarqueeLightShape
    Square
    Circle
End Enum
' </snippet98>
' </snippet97>

' <snippet30>
<Designer(GetType(MarqueeControlLibrary.Design.MarqueeBorderDesigner)), _
ToolboxItemFilter("MarqueeControlLibrary.MarqueeBorder", _
ToolboxItemFilterType.Require)> _
Partial Public Class MarqueeBorder
    Inherits Panel
    Implements IMarqueeWidget
    ' </snippet30>

    ' <snippet40>
    Public Shared MaxLightSize As Integer = 10

    ' These fields back the public properties.
    Private updatePeriodValue As Integer = 50
    Private lightSizeValue As Integer = 5
    Private lightPeriodValue As Integer = 3
    Private lightSpacingValue As Integer = 1
    Private lightColorValue As Color
    Private darkColorValue As Color
    Private spinDirectionValue As MarqueeSpinDirection = MarqueeSpinDirection.CW
    Private lightShapeValue As MarqueeLightShape = MarqueeLightShape.Square

    ' These brushes are used to paint the light and dark
    ' colors of the marquee lights.
    Private lightBrush As Brush
    Private darkBrush As Brush

    ' This field tracks the progress of the "first" light as it
    ' "travels" around the marquee border.
    Private currentOffset As Integer = 0

    ' This component updates the control asynchronously.
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker


    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' Initialize light and dark colors 
        ' to the control's default values.
        Me.lightColorValue = Me.ForeColor
        Me.darkColorValue = Me.BackColor
        Me.lightBrush = New SolidBrush(Me.lightColorValue)
        Me.darkBrush = New SolidBrush(Me.darkColorValue)

        ' The MarqueeBorder control manages its own padding,
        ' because it requires that any contained controls do
        ' not overlap any of the marquee lights.
        Dim pad As Integer = 2 * (Me.lightSizeValue + Me.lightSpacingValue)
        Me.Padding = New Padding(pad, pad, pad, pad)

        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    ' </snippet40>

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "IMarqueeWidget implementation"

    ' <snippet50>
    Public Overridable Sub StartMarquee() _
    Implements IMarqueeWidget.StartMarquee
        ' The MarqueeBorder control may contain any number of 
        ' controls that implement IMarqueeWidget, so find
        ' each IMarqueeWidget child and call its StartMarquee
        ' method.
        Dim cntrl As Control
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is IMarqueeWidget Then
                Dim widget As IMarqueeWidget = CType(cntrl, IMarqueeWidget)

                widget.StartMarquee()
            End If
        Next cntrl

        ' Start the updating thread and pass it the UpdatePeriod.
        Me.backgroundWorker1.RunWorkerAsync(Me.UpdatePeriod)
    End Sub


    Public Overridable Sub StopMarquee() _
    Implements IMarqueeWidget.StopMarquee
        ' The MarqueeBorder control may contain any number of 
        ' controls that implement IMarqueeWidget, so find
        ' each IMarqueeWidget child and call its StopMarquee
        ' method.
        Dim cntrl As Control
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is IMarqueeWidget Then
                Dim widget As IMarqueeWidget = CType(cntrl, IMarqueeWidget)

                widget.StopMarquee()
            End If
        Next cntrl

        ' Stop the updating thread.
        Me.backgroundWorker1.CancelAsync()
    End Sub


    <Category("Marquee"), Browsable(True)> _
    Public Overridable Property UpdatePeriod() As Integer _
    Implements IMarqueeWidget.UpdatePeriod

        Get
            Return Me.updatePeriodValue
        End Get

        Set(ByVal Value As Integer)
            If Value > 0 Then
                Me.updatePeriodValue = Value
            Else
                Throw New ArgumentOutOfRangeException("UpdatePeriod", _
                "must be > 0")
            End If
        End Set

    End Property
    ' </snippet50>

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Public Properties"

    ' <snippet60>
    <Category("Marquee"), Browsable(True)> _
    Public Property LightSize() As Integer
        Get
            Return Me.lightSizeValue
        End Get

        Set(ByVal Value As Integer)
            If Value > 0 AndAlso Value <= MaxLightSize Then
                Me.lightSizeValue = Value
                Me.DockPadding.All = 2 * Value
            Else
                Throw New ArgumentOutOfRangeException("LightSize", _
                "must be > 0 and < MaxLightSize")
            End If
        End Set
    End Property


    <Category("Marquee"), Browsable(True)> _
    Public Property LightPeriod() As Integer
        Get
            Return Me.lightPeriodValue
        End Get

        Set(ByVal Value As Integer)
            If Value > 0 Then
                Me.lightPeriodValue = Value
            Else
                Throw New ArgumentOutOfRangeException("LightPeriod", _
                "must be > 0 ")
            End If
        End Set
    End Property


    <Category("Marquee"), Browsable(True)> _
    Public Property LightColor() As Color
        Get
            Return Me.lightColorValue
        End Get

        Set(ByVal Value As Color)
            ' The LightColor property is only changed if the 
            ' client provides a different value. Comparing values 
            ' from the ToArgb method is the recommended test for
            ' equality between Color structs.
            If Me.lightColorValue.ToArgb() <> Value.ToArgb() Then
                Me.lightColorValue = Value
                Me.lightBrush = New SolidBrush(Value)
            End If
        End Set
    End Property


    <Category("Marquee"), Browsable(True)> _
    Public Property DarkColor() As Color
        Get
            Return Me.darkColorValue
        End Get

        Set(ByVal Value As Color)
            ' The DarkColor property is only changed if the 
            ' client provides a different value. Comparing values 
            ' from the ToArgb method is the recommended test for
            ' equality between Color structs.
            If Me.darkColorValue.ToArgb() <> Value.ToArgb() Then
                Me.darkColorValue = Value
                Me.darkBrush = New SolidBrush(Value)
            End If
        End Set
    End Property


    <Category("Marquee"), Browsable(True)> _
    Public Property LightSpacing() As Integer
        Get
            Return Me.lightSpacingValue
        End Get

        Set(ByVal Value As Integer)
            If Value >= 0 Then
                Me.lightSpacingValue = Value
            Else
                Throw New ArgumentOutOfRangeException("LightSpacing", _
                "must be >= 0")
            End If
        End Set
    End Property


    <Category("Marquee"), Browsable(True), _
    EditorAttribute(GetType(LightShapeEditor), _
    GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property LightShape() As MarqueeLightShape

        Get
            Return Me.lightShapeValue
        End Get

        Set(ByVal Value As MarqueeLightShape)
            Me.lightShapeValue = Value
        End Set

    End Property


    <Category("Marquee"), Browsable(True)> _
    Public Property SpinDirection() As MarqueeSpinDirection

        Get
            Return Me.spinDirectionValue
        End Get

        Set(ByVal Value As MarqueeSpinDirection)
            Me.spinDirectionValue = Value
        End Set

    End Property
    ' </snippet60>

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Implementation"

    ' <snippet70>
    Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
        MyBase.OnLayout(levent)

        ' Repaint when the layout has changed.
        Me.Refresh()
    End Sub


    ' This method paints the lights around the border of the 
    ' control. It paints the top row first, followed by the
    ' right side, the bottom row, and the left side. The color
    ' of each light is determined by the IsLit method and
    ' depends on the light's position relative to the value
    ' of currentOffset.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Me.BackColor)

        MyBase.OnPaint(e)

        ' If the control is large enough, draw some lights.
        If Me.Width > MaxLightSize AndAlso Me.Height > MaxLightSize Then
            ' The position of the next light will be incremented 
            ' by this value, which is equal to the sum of the
            ' light size and the space between two lights.
            Dim increment As Integer = _
            Me.lightSizeValue + Me.lightSpacingValue

            ' Compute the number of lights to be drawn along the
            ' horizontal edges of the control.
            Dim horizontalLights As Integer = _
            (Me.Width - increment) / increment

            ' Compute the number of lights to be drawn along the
            ' vertical edges of the control.
            Dim verticalLights As Integer = _
            (Me.Height - increment) / increment

            ' These local variables will be used to position and
            ' paint each light.
            Dim xPos As Integer = 0
            Dim yPos As Integer = 0
            Dim lightCounter As Integer = 0
            Dim brush As Brush

            ' Draw the top row of lights.
            Dim i As Integer
            For i = 0 To horizontalLights - 1
                brush = IIf(IsLit(lightCounter), Me.lightBrush, Me.darkBrush)

                DrawLight(g, brush, xPos, yPos)

                xPos += increment
                lightCounter += 1
            Next i

            ' Draw the lights flush with the right edge of the control.
            xPos = Me.Width - Me.lightSizeValue

            ' Draw the right column of lights.
            'Dim i As Integer
            For i = 0 To verticalLights - 1
                brush = IIf(IsLit(lightCounter), Me.lightBrush, Me.darkBrush)

                DrawLight(g, brush, xPos, yPos)

                yPos += increment
                lightCounter += 1
            Next i

            ' Draw the lights flush with the bottom edge of the control.
            yPos = Me.Height - Me.lightSizeValue

            ' Draw the bottom row of lights.
            'Dim i As Integer
            For i = 0 To horizontalLights - 1
                brush = IIf(IsLit(lightCounter), Me.lightBrush, Me.darkBrush)

                DrawLight(g, brush, xPos, yPos)

                xPos -= increment
                lightCounter += 1
            Next i

            ' Draw the lights flush with the left edge of the control.
            xPos = 0

            ' Draw the left column of lights.
            'Dim i As Integer
            For i = 0 To verticalLights - 1
                brush = IIf(IsLit(lightCounter), Me.lightBrush, Me.darkBrush)

                DrawLight(g, brush, xPos, yPos)

                yPos -= increment
                lightCounter += 1
            Next i
        End If
    End Sub
    ' </snippet70>

    ' <snippet80>
    ' This method determines if the marquee light at lightIndex
    ' should be lit. The currentOffset field specifies where
    ' the "first" light is located, and the "position" of the
    ' light given by lightIndex is computed relative to this 
    ' offset. If this position modulo lightPeriodValue is zero,
    ' the light is considered to be on, and it will be painted
    ' with the control's lightBrush. 
    Protected Overridable Function IsLit(ByVal lightIndex As Integer) As Boolean
        Dim directionFactor As Integer = _
        IIf(Me.spinDirectionValue = MarqueeSpinDirection.CW, -1, 1)

        Return (lightIndex + directionFactor * Me.currentOffset) Mod Me.lightPeriodValue = 0
    End Function


    Protected Overridable Sub DrawLight( _
    ByVal g As Graphics, _
    ByVal brush As Brush, _
    ByVal xPos As Integer, _
    ByVal yPos As Integer)

        Select Case Me.lightShapeValue
            Case MarqueeLightShape.Square
                g.FillRectangle( _
                brush, _
                xPos, _
                yPos, _
                Me.lightSizeValue, _
                Me.lightSizeValue)
                Exit Select
            Case MarqueeLightShape.Circle
                g.FillEllipse( _
                brush, _
                xPos, _
                yPos, _
                Me.lightSizeValue, _
                Me.lightSizeValue)
                Exit Select
            Case Else
                Trace.Assert(False, "Unknown value for light shape.")
                Exit Select
        End Select

    End Sub
    ' </snippet80>

    ' <snippet90>
    ' This method is called in the worker thread's context, 
    ' so it must not make any calls into the MarqueeBorder
    ' control. Instead, it communicates to the control using 
    ' the ProgressChanged event.
    '
    ' The only work done in this event handler is
    ' to sleep for the number of milliseconds specified 
    ' by UpdatePeriod, then raise the ProgressChanged event.
    Private Sub backgroundWorker1_DoWork( _
    ByVal sender As Object, _
    ByVal e As System.ComponentModel.DoWorkEventArgs) _
    Handles backgroundWorker1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        ' This event handler will run until the client cancels
        ' the background task by calling CancelAsync.
        While Not worker.CancellationPending
            ' The Argument property of the DoWorkEventArgs
            ' object holds the value of UpdatePeriod, which 
            ' was passed as the argument to the RunWorkerAsync
            ' method. 
            Thread.Sleep(Fix(e.Argument))

            ' The DoWork eventhandler does not actually report
            ' progress; the ReportProgress event is used to 
            ' periodically alert the control to update its state.
            worker.ReportProgress(0)
        End While
    End Sub


    ' The ProgressChanged event is raised by the DoWork method.
    ' This event handler does work that is internal to the
    ' control. In this case, the currentOffset is incremented,
    ' and the control is told to repaint itself.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, _
    ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
    Handles backgroundWorker1.ProgressChanged
        Me.currentOffset += 1
        Me.Refresh()
    End Sub
    ' </snippet90>

    ' <snippet91>
    ' <snippet96>
    ' This class demonstrates the use of a custom UITypeEditor. 
    ' It allows the MarqueeBorder control's LightShape property
    ' to be changed at design time using a customized UI element
    ' that is invoked by the Properties window. The UI is provided
    ' by the LightShapeSelectionControl class.
    Friend Class LightShapeEditor
        Inherits UITypeEditor
        ' </snippet96>

        ' <snippet92>
        Private editorService As IWindowsFormsEditorService = Nothing
        ' </snippet92>

        ' <snippet93>
        Public Overrides Function GetEditStyle( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext) _
        As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.DropDown
        End Function

        ' </snippet93>

        ' <snippet94>
        Public Overrides Function EditValue( _
        ByVal context As ITypeDescriptorContext, _
        ByVal provider As IServiceProvider, _
        ByVal value As Object) As Object
            If (provider IsNot Nothing) Then
                editorService = _
                CType(provider.GetService(GetType(IWindowsFormsEditorService)), _
                IWindowsFormsEditorService)
            End If

            If (editorService IsNot Nothing) Then
                Dim selectionControl As _
                New LightShapeSelectionControl( _
                CType(value, MarqueeLightShape), _
                editorService)

                editorService.DropDownControl(selectionControl)

                value = selectionControl.LightShape
            End If

            Return value
        End Function
        ' </snippet94>

        ' <snippet99>
        ' This method indicates to the design environment that
        ' the type editor will paint additional content in the
        ' LightShape entry in the PropertyGrid.
        Public Overrides Function GetPaintValueSupported( _
        ByVal context As ITypeDescriptorContext) As Boolean

            Return True

        End Function

        ' This method paints a graphical representation of the 
        ' selected value of the LightShpae property.
        Public Overrides Sub PaintValue( _
        ByVal e As PaintValueEventArgs)

            Dim shape As MarqueeLightShape = _
            CType(e.Value, MarqueeLightShape)
            Using p As Pen = Pens.Black

                If shape = MarqueeLightShape.Square Then

                    e.Graphics.DrawRectangle(p, e.Bounds)

                Else

                    e.Graphics.DrawEllipse(p, e.Bounds)

                End If

            End Using

        End Sub
        ' </snippet99>

    End Class
    ' </snippet91>

    Private Sub InitializeComponent()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker

        ' 
        ' backgroundWorker1
        ' 
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True
    End Sub

#End Region

End Class
' </snippet10>