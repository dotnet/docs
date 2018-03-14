 ' This sample can go in GroupBoxRenderer class overview.
' - Snippet2 can go in DrawGroupBox
' This is a custom GroupBox-like control that has a double border
' and uses an internal FlowLayoutPanel to contain added controls.
' TODO: see if you can work DrawParentBackground into here somehow.

'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles



Class Form1
    Inherits Form
    Private WithEvents button1 As Button
    
    
    Public Sub New() 
        Dim GroupBox1 As New CustomGroupBox()
        button1 = New Button()
        
        GroupBox1.Text = "Radio Button Display"
        Me.button1.Location = New System.Drawing.Point(185, 231)
        Me.button1.Size = New System.Drawing.Size(105, 23)
        Me.button1.Text = "Toggle Visual Styles"

        Controls.Add(GroupBox1)
        Me.Controls.Add(Me.button1)
        
        ' Add some radio buttons to test the CustomGroupBox.
        Dim count As Integer = 8
        Dim ButtonArray(count) As RadioButton
        Dim i As Integer
        For i = 0 To count
            ButtonArray(i) = New RadioButton()
            ButtonArray(i).Text = "Button " +(i + 1).ToString()
            GroupBox1.Controls.Add(ButtonArray(i))
        Next i
        
        If Application.RenderWithVisualStyles Then
            Me.Text = "Visual Styles Enabled"
        Else
            Me.Text = "Visual Styles Disabled"
        End If
    
    End Sub 'New
     
    <STAThread()>  _
    Shared Sub Main() 
        ' If you do not call EnableVisualStyles below, then 
        ' GroupBoxRenderer automatically detects this and draws
        ' the group box without visual styles.
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    '<snippet3>
    ' Match application style and toggle visual styles off
    ' and on for the application.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        GroupBoxRenderer.RenderMatchingApplicationState = True

        Application.VisualStyleState = _
            Application.VisualStyleState Xor _
            VisualStyleState.ClientAndNonClientAreasEnabled

        If Application.RenderWithVisualStyles Then
            Me.Text = "Visual Styles Enabled"
        Else
            Me.Text = "Visual Styles Disabled"
        End If

    End Sub
    '</snippet3>
End Class


Public Class CustomGroupBox
    Inherits Control
    Private innerRectangle As New Rectangle()
    Private state As GroupBoxState = GroupBoxState.Normal
    Private panel As New FlowLayoutPanel()
    
    
    Public Sub New() 
        Me.Size = New Size(200, 200)
        Me.Location = New Point(10, 10)
        Me.Controls.Add(panel)
        Me.Text = "CustomGroupBox"
        Me.Font = SystemFonts.IconTitleFont
        
        innerRectangle.X = ClientRectangle.X + 5
        innerRectangle.Y = ClientRectangle.Y + 15
        innerRectangle.Width = ClientRectangle.Width - 10
        innerRectangle.Height = ClientRectangle.Height - 20
        
        panel.FlowDirection = FlowDirection.TopDown
        panel.Location = New Point(innerRectangle.X + 5, innerRectangle.Y + 5)
        panel.Size = New Size(innerRectangle.Width - 10, innerRectangle.Height - 10)
    
    End Sub 'New
    
    
    '<Snippet2>
    ' Draw the group box in the current state.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs) 
        MyBase.OnPaint(e)
        
        GroupBoxRenderer.DrawGroupBox(e.Graphics, ClientRectangle, Me.Text, Me.Font, state)
        
        ' Draw an additional inner border if visual styles are enabled.
        If Application.RenderWithVisualStyles Then
            GroupBoxRenderer.DrawGroupBox(e.Graphics, innerRectangle, state)
        End If
    
    End Sub 'OnPaint
    
    '</Snippet2>
    ' Pass added controls to the internal FlowLayoutPanel.
    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs) 
        MyBase.OnControlAdded(e)
        
        ' Ensure that you do not add the panel itself.
        If e.Control IsNot Me.panel Then
            Me.Controls.Remove(e.Control)
            panel.Controls.Add(e.Control)
        End If
    
    End Sub 'OnControlAdded
End Class 'CustomGroupBox
'</Snippet0>