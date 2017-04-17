'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace MouseEvent
    ' Summary description for Form1.
    Public NotInheritable Class Form1
        Inherits System.Windows.Forms.Form

        Friend WithEvents panel1 As System.Windows.Forms.Panel
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private label6 As System.Windows.Forms.Label
        Private label7 As System.Windows.Forms.Label
        Private label8 As System.Windows.Forms.Label
        Private label9 As System.Windows.Forms.Label
        Friend WithEvents clearButton As System.Windows.Forms.Button
        Private mousePath As System.Drawing.Drawing2D.GraphicsPath
        Private groupBox1 As System.Windows.Forms.GroupBox

        Private fontSize As Integer = 20
        
        <System.STAThread()>  _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Form1())
        End Sub 'Main

        Public Sub New()

            mousePath = New System.Drawing.Drawing2D.GraphicsPath()

            Me.panel1 = New System.Windows.Forms.Panel()
            Me.label1 = New System.Windows.Forms.Label()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.label7 = New System.Windows.Forms.Label()
            Me.label8 = New System.Windows.Forms.Label()
            Me.label9 = New System.Windows.Forms.Label()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()

            ' Mouse Events Label
            Me.label1.Location = New System.Drawing.Point(24, 504) 
            Me.label1.Size = New System.Drawing.Size(392, 23) 
            ' DoubleClickSize Label
            Me.label2.AutoSize = True 
            Me.label2.Location = New System.Drawing.Point(24, 48) 
            Me.label2.Size = New System.Drawing.Size(35, 13) 
            ' DoubleClickTime Label
            Me.label3.AutoSize = True 
            Me.label3.Location = New System.Drawing.Point(24, 72) 
            Me.label3.Size = New System.Drawing.Size(35, 13) 
            ' MousePresent Label
            Me.label4.AutoSize = True 
            Me.label4.Location = New System.Drawing.Point(24, 96) 
            Me.label4.Size = New System.Drawing.Size(35, 13) 
            ' MouseButtons Label
            Me.label5.AutoSize = True 
            Me.label5.Location = New System.Drawing.Point(24, 120) 
            Me.label5.Size = New System.Drawing.Size(35, 13) 
            ' MouseButtonsSwapped Label
            Me.label6.AutoSize = True 
            Me.label6.Location = New System.Drawing.Point(320, 48) 
            Me.label6.Size = New System.Drawing.Size(35, 13) 
            ' MouseWheelPresent Label
            Me.label7.AutoSize = True 
            Me.label7.Location = New System.Drawing.Point(320, 72) 
            Me.label7.Size = New System.Drawing.Size(35, 13) 
            ' MouseWheelScrollLines Label
            Me.label8.AutoSize = True 
            Me.label8.Location = New System.Drawing.Point(320, 96) 
            Me.label8.Size = New System.Drawing.Size(35, 13) 
            ' NativeMouseWheelSupport Label
            Me.label9.AutoSize = True 
            Me.label9.Location = New System.Drawing.Point(320, 120) 
            Me.label9.Size = New System.Drawing.Size(35, 13) 

            ' Mouse Panel
            Me.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top Or _
                                    System.Windows.Forms.AnchorStyles.Left Or _
                                    System.Windows.Forms.AnchorStyles.Right
            Me.panel1.BackColor = System.Drawing.SystemColors.ControlDark
            Me.panel1.Location = New System.Drawing.Point(16, 160)
            Me.panel1.Size = New System.Drawing.Size(664, 320)

            ' Clear Button
            Me.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Top Or _
                                    System.Windows.Forms.AnchorStyles.Right
            Me.clearButton.Location = New System.Drawing.Point(592, 504)
            Me.clearButton.TabIndex = 1
            Me.clearButton.Text = "Clear"

            ' GroupBox
            Me.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or _
                                  System.Windows.Forms.AnchorStyles.Left Or _
                                  System.Windows.Forms.AnchorStyles.Right
            Me.groupBox1.Location = New System.Drawing.Point(16, 24)
            Me.groupBox1.Size = New System.Drawing.Size(664, 128)
            Me.groupBox1.Text = "System.Windows.Forms.SystemInformation"

            ' Set up how the form should be displayed and add the controls to the form.
            Me.ClientSize = New System.Drawing.Size(696, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label9, _
                            Me.label8, Me.label7, Me.label6, Me.label5, Me.label4, _
                            Me.label3, Me.label2, Me.clearButton, Me.panel1, Me.label1, Me.groupBox1})

            Me.Text = "Mouse Event Example"

            '<Snippet6>
            ' Display information about the system mouse.
            label2.Text = "SystemInformation.DoubleClickSize: " + SystemInformation.DoubleClickSize.ToString()
            label3.Text = "SystemInformation.DoubleClickTime: " + SystemInformation.DoubleClickTime.ToString()
            label4.Text = "SystemInformation.MousePresent: " + SystemInformation.MousePresent.ToString()
            label5.Text = "SystemInformation.MouseButtons: " + SystemInformation.MouseButtons.ToString()
            label6.Text = "SystemInformation.MouseButtonsSwapped: " + SystemInformation.MouseButtonsSwapped.ToString()
            label7.Text = "SystemInformation.MouseWheelPresent: " + SystemInformation.MouseWheelPresent.ToString()
            label8.Text = "SystemInformation.MouseWheelScrollLines: " + SystemInformation.MouseWheelScrollLines.ToString()
            label9.Text = "SystemInformation.NativeMouseWheelSupport: " + SystemInformation.NativeMouseWheelSupport.ToString()
            '</Snippet6>
        End Sub 'New

        '<Snippet2>    
        Private Sub panel1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles panel1.MouseDown
            ' Update the mouse path with the mouse information
            Dim mouseDownLocation As New Point(e.X, e.Y)
            
            Dim eventString As String = Nothing
            Select Case e.Button
                Case MouseButtons.Left
                    eventString = "L"
                Case MouseButtons.Right
                    eventString = "R"
                Case MouseButtons.Middle
                    eventString = "M"
                Case MouseButtons.XButton1
                    eventString = "X1"
                Case MouseButtons.XButton2
                    eventString = "X2"
                Case MouseButtons.None:
                     eventString = Nothing              
            End Select
            
            If (eventString IsNot Nothing) Then
                mousePath.AddString(eventString, FontFamily.GenericSerif, CInt(FontStyle.Bold), fontSize, mouseDownLocation, StringFormat.GenericDefault)
            Else
                mousePath.AddLine(mouseDownLocation, mouseDownLocation)
            End If

            panel1.Focus()
            panel1.Invalidate()
        End Sub 
        '</Snippet2>
        
        '<Snippet3>
        Private Sub panel1_MouseEnter(sender As Object, e As System.EventArgs) Handles panel1.MouseEnter
            ' Update the mouse event label to indicate the MouseEnter event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseEnter"
        End Sub
        
        Private Sub panel1_MouseHover(sender As Object, e As System.EventArgs) Handles panel1.MouseHover
            ' Update the mouse event label to indicate the MouseHover event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseHover"
        End Sub
        
        Private Sub panel1_MouseLeave(sender As Object, e As System.EventArgs) Handles panel1.MouseLeave
            ' Update the mouse event label to indicate the MouseLeave event occurred.
            label1.Text = sender.GetType().ToString() + ": MouseLeave"
        End Sub
        
        Private Sub panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles panel1.MouseMove
            ' Update the mouse path that is drawn onto the Panel.
            Dim mouseX As Integer = e.X
            Dim mouseY As Integer = e.Y
            
            mousePath.AddLine(mouseX, mouseY, mouseX, mouseY)
        End Sub
        '</Snippet3>
        '<Snippet4>        
        Private Sub panel1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles panel1.MouseWheel
            ' Update the drawing based upon the mouse wheel scrolling.
            Dim numberOfTextLinesToMove As Integer = CInt(e.Delta * SystemInformation.MouseWheelScrollLines / 120) 
            Dim numberOfPixelsToMove As Integer = numberOfTextLinesToMove * fontSize
            
            If numberOfPixelsToMove <> 0 Then
                Dim translateMatrix As New System.Drawing.Drawing2D.Matrix()
                translateMatrix.Translate(0, numberOfPixelsToMove)
                mousePath.Transform(translateMatrix)
            End If

            panel1.Invalidate()
        End Sub
        '</Snippet4>
        '<Snippet5>         
        Private Sub panel1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles panel1.MouseUp
            Dim mouseUpLocation As New System.Drawing.Point(e.X, e.Y)
            
            ' Show the number of clicks in the path graphic.
            Dim numberOfClicks As Integer = e.Clicks
            mousePath.AddString("     " + numberOfClicks.ToString(), _
                                FontFamily.GenericSerif, CInt(FontStyle.Bold), _
                                fontSize, mouseUpLocation, StringFormat.GenericDefault)

            panel1.Invalidate()
        End Sub
        '</Snippet5>
        
        Private Sub panel1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles panel1.Paint
            ' Perform the painting of the Panel.
            e.Graphics.DrawPath(System.Drawing.Pens.DarkRed, mousePath)
        End Sub
        
        Private Sub clearButton_Click(sender As Object, e As System.EventArgs) Handles clearButton.Click
            ' Clear the Panel display.
            mousePath.Dispose()
            mousePath = New System.Drawing.Drawing2D.GraphicsPath()
            panel1.Invalidate()
        End Sub
        
    End Class 'Form1
End Namespace
'</Snippet1>
