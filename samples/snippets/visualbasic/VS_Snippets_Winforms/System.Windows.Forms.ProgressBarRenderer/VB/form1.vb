 ' This sample can go in ProgressBarRenderer class overview.
' - Snippet2 can go in DrawVerticalBar and IsSupported
' - Snippet4 can go in ChunkSpaceThickness and ChunkThickness
' - Snippet6 can go in DrawVerticalChunks
' This sample draws a vertical progress bar, something that the regular ProgressBar control
' cannot do. Because it draws a vertical bar, if visual styles aren't enabled, I simply
' don't draw a bar at all, instead of trying to expose a system ProgressBar control.
' The SetupProgressBar method uses the thickness defined by the current visual 
' style to calculate the height of each rectangle. Note that the Y coordinate of 
' each rectangle is near the bottom of the client rectangle and the height of 
' each rectangle is negative, so the bar progresses upward. The size adjustments 
' ensure that the chunks don't paint over the frame.
' For simplicity, this sampel does not handle run-time switching of visual styles.

'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles



Public Class Form1
    Inherits Form
    Private bar1 As New VerticalProgressBar()
    Private button1 As New Button()
    
    
    Public Sub New() 
        Me.Size = New Size(500, 500)
        bar1.NumberChunks = 30
        button1.Location = New Point(150, 10)
        button1.Size = New Size(150, 30)
        button1.Text = "Start VerticalProgressBar"
        AddHandler button1.Click, AddressOf button1_Click
        Controls.AddRange(New Control() {button1, bar1})
    
    End Sub 'New
    
    
    <STAThread()>  _
    Public Shared Sub Main() 
        ' The call to EnableVisualStyles below does not affect
        ' whether ProgressBarRenderer.IsSupported is true; as 
        ' long as visual styles are enabled by the operating system, 
        ' IsSupported is true.
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    ' Start the VerticalProgressBar.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) 
        bar1.Start()
    
    End Sub 'button1_Click
End Class 'Form1


Public Class VerticalProgressBar
    Inherits Control
    Private numberChunksValue As Integer
    Private ticks As Integer
    Private progressTimer As New Timer()
    Private progressBarRectangles() As Rectangle
    
    
    Public Sub New() 
        Me.Location = New Point(10, 10)
        Me.Width = 50
        
        ' The progress bar will update every second.
        progressTimer.Interval = 1000
        AddHandler progressTimer.Tick, AddressOf progressTimer_Tick
        
        ' This property also calls SetupProgressBar to initialize 
        ' the progress bar rectangles if styles are enabled.
        NumberChunks = 20
        
        ' Set the default height if visual styles are not enabled.
        If Not ProgressBarRenderer.IsSupported Then
            Me.Height = 100
        End If
    
    End Sub 'New
    
    ' Specify the number of progress bar chunks to base the height on.
    
    Public Property NumberChunks() As Integer 
        Get
            Return numberChunksValue
        End Get
        
        Set
            If value <= 50 AndAlso value > 0 Then
                numberChunksValue = value
            Else
                MessageBox.Show("Number of chunks must be between " + "0 and 50; defaulting to 10")
                numberChunksValue = 10
            End If
            
            ' Recalculate the progress bar size, if visual styles 
            ' are active.
            If ProgressBarRenderer.IsSupported Then
                SetupProgressBar()
            End If
        End Set
    End Property
    
    
    '<Snippet2>
    ' Draw the progress bar in its normal state.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs) 
        MyBase.OnPaint(e)
        
        If ProgressBarRenderer.IsSupported Then
            ProgressBarRenderer.DrawVerticalBar(e.Graphics, ClientRectangle)
            Me.Parent.Text = "VerticalProgressBar Enabled"
        Else
            Me.Parent.Text = "VerticalProgressBar Disabled"
        End If
    
    End Sub 'OnPaint
    
    '</Snippet2>
    '<Snippet4>
    ' Initialize the rectangles used to paint the states of the 
    ' progress bar.
    Private Sub SetupProgressBar() 
        If Not ProgressBarRenderer.IsSupported Then
            Return
        End If
        
        ' Determine the size of the progress bar frame.
        Me.Size = New Size(ClientRectangle.Width, NumberChunks *(ProgressBarRenderer.ChunkThickness + 2 * ProgressBarRenderer.ChunkSpaceThickness) + 6)
        
        ' Initialize the rectangles to draw each step of the 
        ' progress bar.
        progressBarRectangles = New Rectangle(NumberChunks) {}
        
        Dim i As Integer
        For i = 0 To NumberChunks
            ' Use the thickness defined by the current visual style 
            ' to calculate the height of each rectangle. The size 
            ' adjustments ensure that the chunks do not paint over 
            ' the frame.
            Dim filledRectangleHeight As Integer = (i + 1)  _
		*(ProgressBarRenderer.ChunkThickness + 2 * ProgressBarRenderer.ChunkSpaceThickness)
            
            progressBarRectangles(i) = New Rectangle(ClientRectangle.X + 3, _
                ClientRectangle.Y + ClientRectangle.Height - 3 - filledRectangleHeight, _
                ClientRectangle.Width - 6, filledRectangleHeight)
        Next i
    
    End Sub 'SetupProgressBar
    
    '</Snippet4>
    '<Snippet6>
    ' Handle the timer tick; draw each progressively larger rectangle.
    Private Sub progressTimer_Tick(ByVal myObject As [Object], ByVal e As EventArgs) 
        If ticks < NumberChunks Then
            Dim g As Graphics = Me.CreateGraphics()
            Try
                ProgressBarRenderer.DrawVerticalChunks(g, progressBarRectangles(ticks))
                ticks += 1
            Finally
                g.Dispose()
            End Try
        Else
            progressTimer.Enabled = False
        End If
    
    End Sub 'progressTimer_Tick
    
    '</Snippet6>
    ' Start the progress bar.
    Public Sub Start() 
        If ProgressBarRenderer.IsSupported Then
            progressTimer.Start()
        Else
            MessageBox.Show("VerticalScrollBar requires visual styles")
        End If
    
    End Sub 'Start
End Class 'VerticalProgressBar
'</Snippet0>