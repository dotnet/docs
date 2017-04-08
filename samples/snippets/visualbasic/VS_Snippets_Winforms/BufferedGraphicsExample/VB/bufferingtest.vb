'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class BufferingExample
    Inherits Form
    Private context As BufferedGraphicsContext
    Private grafx As BufferedGraphics
    
    Private bufferingMode As Byte
    Private bufferingModeStrings As String() = _
        {"Draw to Form without OptimizedDoubleBufferring control style", _
         "Draw to Form using OptimizedDoubleBuffering control style", _
         "Draw to HDC for form"}
    
    Private timer1 As System.Windows.Forms.Timer
    Private count As Byte    
    
    Public Sub New()
        ' Configure the Form for this example.
        Me.Text = "User double buffering"
        AddHandler Me.MouseDown, AddressOf Me.MouseDownHandler
        AddHandler Me.Resize, AddressOf Me.ResizeHandler
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        
        ' Configure a timer to draw graphics updates.
        timer1 = New System.Windows.Forms.Timer()
        timer1.Interval = 200
        AddHandler timer1.Tick, AddressOf Me.OnTimer
        
        bufferingMode = 2
        count = 0
        
        ' Retrieves the BufferedGraphicsContext for the 
        ' current application domain.
        context = BufferedGraphicsManager.Current
        
        ' Sets the maximum size for the primary graphics buffer
        ' of the buffered graphics context for the application
        ' domain.  Any allocation requests for a buffer larger 
        ' than this will create a temporary buffered graphics 
        ' context to host the graphics buffer.
        context.MaximumBuffer = New Size(Me.Width + 1, Me.Height + 1)
        
        ' Allocates a graphics buffer the size of this form
        ' using the pixel format of the Graphics created by 
        ' the Form.CreateGraphics() method, which returns a 
        ' Graphics object that matches the pixel format of the form.
        grafx = context.Allocate(Me.CreateGraphics(), _
            New Rectangle(0, 0, Me.Width, Me.Height))
        
        ' Draw the first frame to the buffer.
        DrawToBuffer(grafx.Graphics)
    End Sub    
    
    Private Sub MouseDownHandler(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            ' Cycle the buffering mode.
            bufferingMode = bufferingMode+1
            If bufferingMode > 2 Then
                bufferingMode = 0
            End If 
            ' If the previous buffering mode used 
            ' the OptimizedDoubleBuffering ControlStyle,
            ' disable the control style.
            If bufferingMode = 1 Then
                Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            End If 
            ' If the current buffering mode uses
            ' the OptimizedDoubleBuffering ControlStyle,
            ' enabke the control style.
            If bufferingMode = 2 Then
                Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, False)
            End If 
            ' Cause the background to be cleared and redraw.
            count = 6
            DrawToBuffer(grafx.Graphics)
            Me.Refresh()
        Else
            ' Toggle whether the redraw timer is active.
            If timer1.Enabled Then
                timer1.Stop()
            Else
                timer1.Start()
            End If
        End If
    End Sub
     
    Private Sub OnTimer(sender As Object, e As EventArgs)
        ' Draw randomly positioned ellipses to the buffer.
        DrawToBuffer(grafx.Graphics)
        
        ' If in bufferingMode 2, draw to the form's HDC.
        If bufferingMode = 2 Then
            ' Render the graphics buffer to the form's HDC.
            grafx.Render(Graphics.FromHwnd(Me.Handle))
        ' If in bufferingMode 0 or 1, draw in the paint method.
        Else
            Me.Refresh()
        End If
    End Sub
     
    Private Sub ResizeHandler(sender As Object, e As EventArgs)
        ' Re-create the graphics buffer for a new window size.
        context.MaximumBuffer = New Size(Me.Width + 1, Me.Height + 1)
        If (grafx IsNot Nothing) Then
            grafx.Dispose()
            grafx = Nothing
        End If
        grafx = context.Allocate(Me.CreateGraphics(), New Rectangle(0, 0, Me.Width, Me.Height))
        
        ' Cause the background to be cleared and redraw.
        count = 6
        DrawToBuffer(grafx.Graphics)
        Me.Refresh()
    End Sub    
    
    Private Sub DrawToBuffer(g As Graphics)
        ' Clear the graphics buffer every five updates.
        count = count+1
        If count > 5 Then
            count = 0
            grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, Me.Width, Me.Height)
        End If
        
        ' Draw randomly positioned and colored ellipses.
        Dim rnd As New Random()
        Dim i As Integer
        For i = 0 To 21
            Dim px As Integer = rnd.Next(20, Me.Width - 40)
            Dim py As Integer = rnd.Next(20, Me.Height - 40)
            g.DrawEllipse(New Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), _
                rnd.Next(0, 255)), 1), px, py, px + rnd.Next(0, Me.Width - px - 20), _
                py + rnd.Next(0, Me.Height - py - 20))
        Next i
        
        ' Draw information strings.
        g.DrawString("Buffering Mode: " + bufferingModeStrings(bufferingMode), _
            New Font("Arial", 8), Brushes.White, 10, 10)
        g.DrawString("Right-click to cycle buffering mode", New Font("Arial", 8), _
            Brushes.White, 10, 22)
        g.DrawString("Left-click to toggle timed display refresh", _
            New Font("Arial", 8), Brushes.White, 10, 34)
    End Sub    
    
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        grafx.Render(e.Graphics)
    End Sub   
    
    <STAThread()>  _
    Public Shared Sub Main(args() As String)
        Application.Run(New BufferingExample())
    End Sub

End Class
'</Snippet1>