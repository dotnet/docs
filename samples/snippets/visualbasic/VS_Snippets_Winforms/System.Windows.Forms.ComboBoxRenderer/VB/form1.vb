' This sample can go in ComboBoxRenderer class overview.
' - Snippet2 can go in IsSupported
' - Snippet4 can go in DrawTextBox and DrawDropDownButton

' It renders the pieces of a combo box with visual styles, provided
' that visual styles are enabled in the Display Panel. 

' For simplicity, this sample doesn't handle runtime switching of visual styles.


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace ComboBoxRendererSample
    Class Form1
        Inherits Form

        Public Sub New()
            Me.Size = New Size(300, 300)
            Dim ComboBox1 As New CustomComboBox()
            Controls.Add(ComboBox1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' The call to EnableVisualStyles below does not affect
            ' whether ComboBoxRenderer.IsSupported is true; as long as visual
            ' styles are enabled by the operating system, IsSupported is true.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomComboBox
        Inherits Control

        Private arrowSize As Size
        Private arrowRectangle As Rectangle
        Private topTextBoxRectangle As Rectangle
        Private bottomTextBoxRectangle As Rectangle
        Private textBoxState As ComboBoxState = ComboBoxState.Normal
        Private arrowState As ComboBoxState = ComboBoxState.Normal
        Private bottomText As String = "Using ComboBoxRenderer"
        Private isActivated As Boolean = False
        Private minHeight As Integer = 38
        Private minWidth As Integer = 40

        Public Sub New()
            Me.Location = New Point(10, 10)
            Me.Size = New Size(140, 38)
            Me.Font = SystemFonts.IconTitleFont
            Me.Text = "Click the button"

            ' Initialize the rectangles to look like the standard combo 
            ' box control.
            arrowSize = New Size(18, 20)
            arrowRectangle = New Rectangle(Me.ClientRectangle.X + _
                Me.ClientRectangle.Width - arrowSize.Width - 1, _
                Me.ClientRectangle.Y + 1, arrowSize.Width, _
                arrowSize.Height)
            topTextBoxRectangle = New Rectangle(Me.ClientRectangle.X, _
                Me.ClientRectangle.Y, Me.ClientRectangle.Width, _
                arrowSize.Height + 2)
            bottomTextBoxRectangle = New Rectangle(Me.ClientRectangle.X, _
                Me.ClientRectangle.Y + topTextBoxRectangle.Height, _
                Me.ClientRectangle.Width, topTextBoxRectangle.Height - 6)
        End Sub

        '<Snippet4>
        '<Snippet2>
        ' Draw the combo box in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not ComboBoxRenderer.IsSupported Then
                Me.Parent.Text = "Visual Styles	Disabled"
                Return
            End If

            Me.Parent.Text = "CustomComboBox Enabled"

            ' Always draw the main text box and drop down arrow in their 
            ' current states.
            ComboBoxRenderer.DrawTextBox(e.Graphics, topTextBoxRectangle, _
                Me.Text, Me.Font, textBoxState)
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, arrowRectangle, _
                arrowState)

            ' Only draw the bottom text box if the arrow has been clicked.
            If isActivated Then
                ComboBoxRenderer.DrawTextBox(e.Graphics, _
                    bottomTextBoxRectangle, bottomText, Me.Font, textBoxState)
            End If
        End Sub
        '</Snippet2>

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            ' Check whether the user clicked the arrow.
            If arrowRectangle.Contains(e.Location) And _
                ComboBoxRenderer.IsSupported Then

                ' Draw the arrow in the pressed state.
                arrowState = ComboBoxState.Pressed

                ' The user has activated the combo box.
                If Not isActivated Then
                    Me.Text = "Clicked!"
                    textBoxState = ComboBoxState.Pressed
                    isActivated = True

                ' The user has deactivated the combo box.
                Else
                    Me.Text = "Click here"
                    textBoxState = ComboBoxState.Normal
                    isActivated = False
                End If

                ' Redraw the control.
                Invalidate()
            End If
        End Sub
        '</Snippet4>

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            If arrowRectangle.Contains(e.Location) And _
                ComboBoxRenderer.IsSupported Then
                arrowState = ComboBoxState.Normal
                Invalidate()
            End If
        End Sub

    End Class
End Namespace
'</Snippet0>



