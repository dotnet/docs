' <snippet110>
' <snippet120>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet120>

' <snippet130>
<ToolboxItemFilter("MarqueeControlLibrary.MarqueeText", _
ToolboxItemFilterType.Require)> _
Partial Public Class MarqueeText
    Inherits Label
    Implements IMarqueeWidget
    ' </snippet130>

    ' <snippet140>
    ' When isLit is true, the text is painted in the light color;
    ' When isLit is false, the text is painted in the dark color.
    ' This value changes whenever the BackgroundWorker component
    ' raises the ProgressChanged event.
    Private isLit As Boolean = True

    ' These fields back the public properties.
    Private updatePeriodValue As Integer = 50
    Private lightColorValue As Color
    Private darkColorValue As Color

    ' These brushes are used to paint the light and dark
    ' colors of the text.
    Private lightBrush As Brush
    Private darkBrush As Brush

    ' This component updates the control asynchronously.
    Private WithEvents backgroundWorker1 As BackgroundWorker


    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' Initialize light and dark colors 
        ' to the control's default values.
        Me.lightColorValue = Me.ForeColor
        Me.darkColorValue = Me.BackColor
        Me.lightBrush = New SolidBrush(Me.lightColorValue)
        Me.darkBrush = New SolidBrush(Me.darkColorValue)
    End Sub 'New
    ' </snippet140>

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "IMarqueeWidget implementation"


    ' <snippet150>
    Public Overridable Sub StartMarquee() _
    Implements IMarqueeWidget.StartMarquee
        ' Start the updating thread and pass it the UpdatePeriod.
        Me.backgroundWorker1.RunWorkerAsync(Me.UpdatePeriod)
    End Sub

    Public Overridable Sub StopMarquee() _
    Implements IMarqueeWidget.StopMarquee
        ' Stop the updating thread.
        Me.backgroundWorker1.CancelAsync()
    End Sub


    <Category("Marquee"), Browsable(True)> _
    Public Property UpdatePeriod() As Integer _
    Implements IMarqueeWidget.UpdatePeriod

        Get
            Return Me.updatePeriodValue
        End Get

        Set(ByVal Value As Integer)
            If Value > 0 Then
                Me.updatePeriodValue = Value
            Else
                Throw New ArgumentOutOfRangeException("UpdatePeriod", "must be > 0")
            End If
        End Set

    End Property
    ' </snippet150>

#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Public Properties"

    ' <snippet160>
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
    ' </snippet160>
#End Region

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
#Region "Implementation"

    ' <snippet170>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' The text is painted in the light or dark color,
        ' depending on the current value of isLit.
        Me.ForeColor = IIf(Me.isLit, Me.lightColorValue, Me.darkColorValue)

        MyBase.OnPaint(e)
    End Sub
    ' </snippet170>

    ' <snippet180>
    ' This method is called in the worker thread's context, 
    ' so it must not make any calls into the MarqueeText control.
    ' Instead, it communicates to the control using the 
    ' ProgressChanged event.
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
    ' control. In this case, the text is toggled between its
    ' light and dark state, and the control is told to 
    ' repaint itself.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, _
    ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
    Handles backgroundWorker1.ProgressChanged
        Me.isLit = Not Me.isLit
        Me.Refresh()
    End Sub
    ' </snippet180>

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
' </snippet110>