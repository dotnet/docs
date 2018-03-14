' <snippet310>
' <snippet320>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet320>

' <snippet311>
' This control provides the custom UI for the LightShape property
' of the MarqueeBorder. It is used by the LightShapeEditor.
Public Class LightShapeSelectionControl
    Inherits System.Windows.Forms.UserControl

    ' <snippet330>
   Private lightShapeValue As MarqueeLightShape = MarqueeLightShape.Square
    ' </snippet330>

    Private editorService As IWindowsFormsEditorService
   Private squarePanel As System.Windows.Forms.Panel
   Private circlePanel As System.Windows.Forms.Panel
   
   ' Required designer variable.
   Private components As System.ComponentModel.Container = Nothing
   
   
    ' <snippet340>
   ' This constructor takes a MarqueeLightShape value from the
   ' design-time environment, which will be used to display
   ' the initial state.
    Public Sub New( _
    ByVal lightShape As MarqueeLightShape, _
    ByVal editorService As IWindowsFormsEditorService)
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' Cache the light shape value provided by the 
        ' design-time environment.
        Me.lightShapeValue = lightShape

        ' Cache the reference to the editor service.
        Me.editorService = editorService

        ' Handle the Click event for the two panels. 
        AddHandler Me.squarePanel.Click, AddressOf squarePanel_Click
        AddHandler Me.circlePanel.Click, AddressOf circlePanel_Click
    End Sub
    ' </snippet340>

    ' <snippet350>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then

            ' Be sure to unhook event handlers
            ' to prevent "lapsed listener" leaks.
            RemoveHandler Me.squarePanel.Click, AddressOf squarePanel_Click
            RemoveHandler Me.circlePanel.Click, AddressOf circlePanel_Click

            If (components IsNot Nothing) Then
                components.Dispose()
            End If

        End If
        MyBase.Dispose(disposing)
    End Sub
    ' </snippet350>

    ' <snippet360>
    ' LightShape is the property for which this control provides
    ' a custom user interface in the Properties window.
    Public Property LightShape() As MarqueeLightShape

        Get
            Return Me.lightShapeValue
        End Get

        Set(ByVal Value As MarqueeLightShape)
            If Me.lightShapeValue <> Value Then
                Me.lightShapeValue = Value
            End If
        End Set

    End Property
    ' </snippet360>

    ' <snippet380>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim gCircle As Graphics = Me.circlePanel.CreateGraphics()
        Try
            Dim gSquare As Graphics = Me.squarePanel.CreateGraphics()
            Try
                ' Draw a filled square in the client area of
                ' the squarePanel control.
                gSquare.FillRectangle( _
                Brushes.Red, _
                0, _
                0, _
                Me.squarePanel.Width, _
                Me.squarePanel.Height)

                ' If the Square option has been selected, draw a 
                ' border inside the squarePanel.
                If Me.lightShapeValue = MarqueeLightShape.Square Then
                    gSquare.DrawRectangle( _
                    Pens.Black, _
                    0, _
                    0, _
                    Me.squarePanel.Width - 1, _
                    Me.squarePanel.Height - 1)
                End If

                ' Draw a filled circle in the client area of
                ' the circlePanel control.
                gCircle.Clear(Me.circlePanel.BackColor)
                gCircle.FillEllipse( _
                Brushes.Blue, _
                0, _
                0, _
                Me.circlePanel.Width, _
                Me.circlePanel.Height)

                ' If the Circle option has been selected, draw a 
                ' border inside the circlePanel.
                If Me.lightShapeValue = MarqueeLightShape.Circle Then
                    gCircle.DrawRectangle( _
                    Pens.Black, _
                    0, _
                    0, _
                    Me.circlePanel.Width - 1, _
                    Me.circlePanel.Height - 1)
                End If
            Finally
                gSquare.Dispose()
            End Try
        Finally
            gCircle.Dispose()
        End Try
    End Sub
    ' </snippet380>

    ' <snippet390>
    Private Sub squarePanel_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        Me.lightShapeValue = MarqueeLightShape.Square
        Me.Invalidate(False)
        Me.editorService.CloseDropDown()

    End Sub


    Private Sub circlePanel_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        Me.lightShapeValue = MarqueeLightShape.Circle
        Me.Invalidate(False)
        Me.editorService.CloseDropDown()

    End Sub
    ' </snippet390>

#Region "Component Designer generated code"

    '/ <summary> 
    '/ Required method for Designer support - do not modify 
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.squarePanel = New System.Windows.Forms.Panel
        Me.circlePanel = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        ' 
        ' squarePanel
        ' 
        Me.squarePanel.Location = New System.Drawing.Point(8, 10)
        Me.squarePanel.Name = "squarePanel"
        Me.squarePanel.Size = New System.Drawing.Size(60, 60)
        Me.squarePanel.TabIndex = 2
        ' 
        ' circlePanel
        ' 
        Me.circlePanel.Location = New System.Drawing.Point(80, 10)
        Me.circlePanel.Name = "circlePanel"
        Me.circlePanel.Size = New System.Drawing.Size(60, 60)
        Me.circlePanel.TabIndex = 3
        ' 
        ' LightShapeSelectionControl
        ' 
        Me.Controls.Add(squarePanel)
        Me.Controls.Add(circlePanel)
        Me.Name = "LightShapeSelectionControl"
        Me.Size = New System.Drawing.Size(150, 80)
        Me.ResumeLayout(False)
    End Sub

#End Region

End Class
' </snippet311>
' </snippet310>