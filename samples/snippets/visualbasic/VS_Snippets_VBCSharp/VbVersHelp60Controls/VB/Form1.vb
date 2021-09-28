Public Class Form1


'*************************************************************************
'<Snippet73>
' Visual Basic
Public Sub TimerOn(ByRef Interval As Short)
    If Interval > 0 Then
            ' Start the timer.
            Me.Timer1.Enabled = True
        Else
            ' Stop the timer
            Me.Timer1.Enabled = False
        End If
    End Sub
    '</Snippet73>


    '*************************************************************************
    '<Snippet66>
    ' Visual Basic
    Private Sub DataGridView1_EditingControlShowing(
    sender As Object,
    e As System.Windows.Forms.
    DataGridViewEditingControlShowingEventArgs
    ) Handles DataGridView1.EditingControlShowing

        CType(e.Control, TextBox).SelectionStart = 0
        CType(e.Control, TextBox).SelectionLength = Len(CType(e.Control,
      TextBox).Text)
        MsgBox("The selected text is " & CType(e.Control,
      TextBox).SelectedText)
    End Sub
    '</Snippet66>


    '*************************************************************************
    '<Snippet64>
    Sub Form_Load()
        Dim answer As MsgBoxResult
        answer = MsgBox("Do you want to quit now?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            MsgBox("Terminating program")
            '<Snippet65>
            End
            '</Snippet65>
        End If
    End Sub
    '</Snippet64>


    '*************************************************************************
    '<Snippet56>
    ' Visual Basic
    Private Sub ClearText(container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If TypeOf (ctrl) Is TextBox Then
                ctrl.Text = ""
            End If
            If ctrl.HasChildren Then
                Me.ClearText(ctrl)
            End If
        Next
    End Sub
    '</Snippet56>


    '*************************************************************************
    '<Snippet55>
    ' Visual Basic
    Private Sub TextBoxes_TextChanged(sender As Object,
e As System.EventArgs) Handles TextBox1.TextChanged,
TextBox2.TextChanged, TextBox3.TextChanged
        Select Case DirectCast(sender, TextBox).Name
            Case Me.TextBox1.Name
                MsgBox("The text in the first TextBox has changed")
            Case Me.TextBox2.Name
                MsgBox("The text in the second TextBox has changed")
            Case Me.TextBox3.Name
                MsgBox("The text in the third TextBox has changed")
        End Select
    End Sub
    '</Snippet55>


    '*************************************************************************
    '<Snippet59>
    ' Visual Basic
    ' Assumes a ToolTip component has been added to the form.
    Private Sub TextBox1_TextChanged(sender As Object,
e As System.EventArgs) Handles TextBox1.TextChanged
        Me.ToolTip1.SetToolTip(Me.TextBox1, "The text has changed")
    End Sub
    '</Snippet59>


    Sub Test2()
        '<Snippet69>
        ' Visual Basic
        Dim i As Integer
        For i = 0 To My.Application.OpenForms.Count - 1
            If My.Application.OpenForms.Item(i).ContainsFocus Then
                My.Application.OpenForms.Item(i).Text =
        "This is the selected form"
            End If
        Next
        '</Snippet69>


        '<Snippet70>
        ' Visual Basic
        Me.ActiveMdiChild.Text = "This is the selected child form"
        '</Snippet70>
    End Sub


    Sub Test1()
        '<Snippet68>
        ' Visual Basic
        Dim i As Integer
        For i = 0 To My.Application.OpenForms.Count - 1
            If My.Application.OpenForms.Item(i).ContainsFocus Then
                If TypeOf (My.Application.OpenForms.Item(i).ActiveControl) Is
        TextBox Then
                    My.Computer.Clipboard.SetText(My.Application.OpenForms.
            Item(i).ActiveControl.Text)
                End If
            End If
        Next
        '</Snippet68>
    End Sub


    '*************************************************************************
    Private Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click


        '<Snippet67>
        ' Visual Basic
        Dim i As Integer
        Dim pkInstalledPrinters As String
        For i = 0 To System.Drawing.Printing.PrinterSettings.
    InstalledPrinters.Count - 1

            pkInstalledPrinters = System.Drawing.Printing.PrinterSettings.
      InstalledPrinters.Item(i)
            Me.ListBox1.Items.Add(pkInstalledPrinters)
        Next
        '</Snippet67>


        '<Snippet58>
        ' Visual Basic
        ' Assumes a HelpProvider component has been added to the form.
        If Me.RadioButton1.Checked = True Then
            Me.HelpProvider1.HelpNamespace = My.Application.Info.DirectoryPath &
          "\EnglishHelp.chm"
        Else
            Me.HelpProvider1.HelpNamespace = My.Application.Info.DirectoryPath &
          "\FrenchHelp.chm"
        End If
        '</Snippet58>


        '****************************
        'Form2.Show()


        Me.Button1.BackgroundImage = System.Drawing.Bitmap.FromFile("C:\ntcheck.bmp")

        '<Snippet54>
        ' Visual Basic
        ' Assumes a picture has been assigned to the BackgroundImage property.
        Dim g As New System.Drawing.Bitmap(Me.Button1.BackgroundImage)
        g.MakeTransparent(System.Drawing.Color.White)
        Me.Button1.BackgroundImage = g
        '</Snippet54>


        '<Snippet52>
        ' Visual Basic
        Me.TextBox1.BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0)
        '</Snippet52>

        '<Snippet51>
        ' Visual Basic
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        '</Snippet51>


        '<Snippet53>
        ' Visual Basic
        ' Command1's BackColor is left at its default (gray).
        ' Command2's BackColor is explicitly set.
        Me.Command2.BackColor = System.Drawing.Color.Black
        ' Explicitly set the BackColor of the form.
        Me.BackColor = System.Drawing.Color.Red
        '</Snippet53>

    End Sub


    '*************************************************************************
    '<Snippet50>
    ' Visual Basic
    Private Sub TextBox2_MouseEnter(sender As Object,
e As System.EventArgs) Handles TextBox2.MouseEnter
        Me.TextBox2.Cursor = New System.Windows.Forms.Cursor(
      "C:\mypath\mycursor.cur")
    End Sub
    '</Snippet50>


    '*************************************************************************
    '<Snippet49>
    ' Visual Basic
    Private Sub TextBox1_MouseEnter(sender As Object,
e As System.EventArgs) Handles TextBox1.MouseEnter
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor
    End Sub
    '</Snippet49>


    '*************************************************************************
    '<Snippet44>
    ' Visual Basic
    Private Sub Form3_Paint(sender As Object,
                            e As System.Windows.Forms.PaintEventArgs
        ) Handles MyBase.Paint

        ' Draw a 70 pixel diameter red circle.
        e.Graphics.DrawEllipse(Pens.Red, 0, 0, 70, 70)
    End Sub
    '</Snippet44>


    '*************************************************************************
    '<Snippet43>
    ' Visual Basic
    ' Using Graphics methods.
    Private Sub Form2_Paint(sender As Object,
                        e As System.Windows.Forms.PaintEventArgs
     ) Handles MyBase.Paint

        ' Draw a solid blue rectangle below the red rectangle.
        e.Graphics.FillRectangle(Brushes.Blue, 14, 120, 200, 100)
    End Sub
    '</Snippet43>


    '*************************************************************************
    '<Snippet42>
    ' Visual Basic
    ' Using a Label control.
    Private Sub Form2_Load(sender As Object,
                       e As System.EventArgs) Handles MyBase.Load

        ' Show a solid red rectangle 14 pixels from the top left.
        Dim Shape1 As New System.Windows.Forms.Label With {
            .Location = New System.Drawing.Point(14, 14),
            .Size = New System.Drawing.Size(200, 100),
            .BorderStyle = BorderStyle.None,
            .BackColor = System.Drawing.Color.Red,
            .Text = ""
        }
        Me.Controls.Add(Shape1)
    End Sub
    '</Snippet42>


    '*************************************************************************
    Private Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click

        '<Snippet47>
        ' Visual Basic
        ' Measurements are in pixels.
        Me.Size = New System.Drawing.Size(640, 480)
        '</Snippet47>


        '<Snippet48>
        ' Visual Basic
        ' Move and retain original size.
        Me.Button2.SetBounds(20, 10, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)
        ' Move and resize to 120 by 80 pixels.
        Me.Button1.SetBounds(0, 0, 120, 80)
        '</Snippet48>


        '<Snippet45>
        ' Visual Basic
        ' Give a TextBox a flat look with a single border.
        Me.TextBox1.BorderStyle = BorderStyle.None
        ' Give a TextBox a three-dimensional appearance.
        Me.TextBox2.BorderStyle = BorderStyle.Fixed3D
        ' Give a Button a flat look
        Me.Button1.FlatStyle = FlatStyle.Flat
        ' Give a ListBox a flat look
        Me.ListBox1.BorderStyle = BorderStyle.FixedSingle
        '</Snippet45>


        '<Snippet39>
        ' Visual Basic
        Me.PictureBox1.Image = System.Drawing.Bitmap.FromFile(
    My.Application.Info.DirectoryPath & "\somepicture.jpg")
        '</Snippet39>


        '<Snippet40>
        ' Visual Basic
        If Not (Me.PictureBox1.Image Is Nothing) Then
            Me.PictureBox1.Image.Dispose()
            Me.PictureBox1.Image = Nothing
        End If
        '</Snippet40>


        '<Snippet37>
        ' Visual Basic
        If Me.RadioButton1.Checked = True Then
            Me.RadioButton2.Checked = True
        Else
            Me.RadioButton1.Checked = True
        End If
        '</Snippet37>


        'MDIParent1.Show()


        '<Snippet30>
        ' Visual Basic
        ' Determine if there are any items checked.
        If Me.CheckedListBox1.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and print results.
            Dim x As Integer
            Dim s As String = ""
            For x = 0 To Me.CheckedListBox1.CheckedItems.Count - 1
                s = s & "Checked Item " & CStr(x + 1) & " = " &
        CStr(Me.CheckedListBox1.CheckedItems(x)) & ControlChars.CrLf
            Next x
            MessageBox.Show(s)
        End If
        '</Snippet30>

        '<Snippet28>
        'Visual Basic
        ' Add an item at the end of the list.
        Me.ListBox1.Items.Add("Tokyo")
        ' Insert an item at the top of the list.
        Me.ListBox1.Items.Insert(0, "Copenhagen")
        ' Remove the first item.
        Me.ListBox1.Items.RemoveAt(0)
        '</Snippet28>


        'MakeTransparent()
        'MessageBox.Show(GetItemText(0))
    End Sub



    '*************************************************************************
    '<Snippet41>
    ' Visual Basic
    Private Sub PictureBox1_Paint(sender As Object,
                              e As System.Windows.Forms.PaintEventArgs
    ) Handles PictureBox1.Paint

        Dim radius As Integer = 20
        Dim diameter As Integer = radius * 2
        Dim x As Integer = (Me.PictureBox1.Width / 2) - radius
        Dim y As Integer = (Me.PictureBox1.Height / 2) - radius
        e.Graphics.DrawEllipse(Pens.Red, x, y, diameter, diameter)
    End Sub
    '</Snippet41>


    '*************************************************************************
    '<Snippet38>
    ' Visual Basic
    ' The CheckChanged event fires each time the RadioButton's Checked 
    ' value changes to either True or False.
    Private Sub RadioButton1_CheckedChanged(sender As Object,
                                        e As System.EventArgs
    ) Handles RadioButton1.CheckedChanged,
              RadioButton2.CheckedChanged

        ' Only execute if the Checked value is True.
        If sender.Checked = True Then
            MsgBox(sender.Name & " was clicked")
        End If
    End Sub
    '</Snippet38>


    '*************************************************************************
    '<Snippet35>
    ' Visual Basic
    ' You must first add a ContextMenuStrip component to the form at design 
    ' time and add Cut, Copy, and Paste menu items named 
    ' CutContextMenuItem, CopyContextMenuItem, and PasteContextMenuItem.

    Private Sub CutToolStripMenuItem_Click(sender As Object,
e As System.EventArgs) Handles CutToolStripMenuItem.Click
        MsgBox("Cut")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object,
e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        MsgBox("Copy")
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object,
e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        MsgBox("Paste")
    End Sub
    '</Snippet35>


    '*************************************************************************
    '<Snippet36>
    Private Sub Form1_MouseDown(sender As Object,
                            e As System.Windows.Forms.MouseEventArgs
    ) Handles Me.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStrip = Me.ContextMenuStrip1

            AddHandler Me.CutContextMenuItem.Click,
      AddressOf Me.CutToolStripMenuItem_Click

            AddHandler Me.CopyContextMenuItem.Click,
      AddressOf Me.CopyToolStripMenuItem_Click

            AddHandler Me.PasteContextMenuItem.Click,
      AddressOf Me.PasteToolStripMenuItem_Click
        End If
    End Sub
    '</Snippet36>


    '******************************************************************************
    '<Snippet27>
    ' Visual Basic
    Private Sub FormPaint(sender As Object,
e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ' Draw a diagonal line from the top left to the lower right.
        e.Graphics.DrawLine(Pens.Black, 0, 0, Me.ClientSize.Width,
    Me.ClientSize.Height)
    End Sub
    '</Snippet27>


    '******************************************************************************
    '<Snippet26>
    ' Visual Basic
    ' Using Graphics methods.
    Private Sub Form1Paint(sender As Object,
e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ' Draw a horizontal line 28 pixels from the top of the form.
        e.Graphics.DrawLine(Pens.Red, 0, 28, Me.Width, 28)
        ' Draw a vertical line 28 pixels from the left of the form.
        e.Graphics.DrawLine(Pens.Blue, 28, 0, 28, Me.Height)
    End Sub
    '</Snippet26>


    '******************************************************************************
    '<Snippet24>
    ' Visual Basic
    Private Sub MakeTransparent()
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        ' Let controls behind the label show through.
        Me.Label1.SendToBack()
        ' Make the portion of controls behind the label transparent
        Me.Label1.BringToFront()
    End Sub
    '</Snippet24>


    '******************************************************************************
    '<Snippet29>
    ' Visual Basic
    Private Function GetItemText(i As Integer) As String
        ' Return the text of the item using the index:
        GetItemText = CStr(Me.ListBox1.Items(i))
    End Function
    '</Snippet29>


    '******************************************************************************
    Private Sub cmdTest_Click(sender As Object, e As System.EventArgs) Handles cmdTest.Click


        '****************************
        '<Snippet16>
        ' Visual Basic
        ' Uses the Help.ShowHelp method.
        Help.ShowHelp(Me, "file://C:\Windows\Help\calc.chm",
  HelpNavigator.TableOfContents)
        '</Snippet16>


        '****************************
        '<Snippet15>
        ' Visual Basic
        ' Uses PrintDocument and PrintDialog components.
        Me.PrintDocument1.DocumentName = My.Application.Info.DirectoryPath &
    "MyFile.txt"
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.ShowDialog()
        '</Snippet15>


        '****************************
        '<Snippet14>
        ' Visual Basic
        ' Uses a SaveFileDialog component.
        Me.SaveFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath
        Me.SaveFileDialog1.ShowDialog()
        '</Snippet14>


        '****************************
        '<Snippet13>
        ' Visual Basic
        ' Uses a OpenFileDialog component.
        Me.OpenFileDialog1.InitialDirectory = "C:\Program Files"
        Me.OpenFileDialog1.ShowDialog()
        '</Snippet13>


        Me.Button1.BackgroundImage = System.Drawing.Bitmap.FromFile("C:\ntcheck.bmp")

        '****************************
        '<Snippet12>
        ' Visual Basic
        ' Assumes a picture has been assigned to the BackgroundImage property.
        Dim ButtonBitmap As New System.Drawing.Bitmap(Me.Button1.BackgroundImage)
        ButtonBitmap.MakeTransparent(System.Drawing.Color.White)
        Me.Button1.BackgroundImage = ButtonBitmap
        '</Snippet12>


        '****************************
        '<Snippet7>
        ' Visual Basic
        Dim i As Integer
        i = Me.ComboBox1.Items.Add("This is a new item")
        Me.ComboBox1.SelectedIndex = i
        '</Snippet7>


        '****************************
        '<Snippet6>
        ' Visual Basic
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        '</Snippet6>


        '****************************
        '<Snippet5>
        ' Visual Basic
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText("Hello")
        If My.Computer.Clipboard.ContainsText Then
            Me.TextBox1.Text = My.Computer.Clipboard.GetText
        End If
        '</Snippet5>


        '****************************
        '<Snippet4>
        ' Visual Basic
        Select Case Me.CheckBox1.CheckState
            Case CheckState.Unchecked
                Me.CheckBox1.Text = "Unchecked"
            Case CheckState.Checked
                Me.CheckBox1.Text = "Checked"
            Case CheckState.Indeterminate
                Me.CheckBox1.Text = "Disabled"
        End Select
        '</Snippet4>


    End Sub


    '*************************************************************************
    '<Snippet63>
    ' Visual Basic
    Private Sub CheckBox1_CheckStateChanged(sender As Object,
e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If Me.CheckBox1.Checked = True Then
            Me.CheckBox1.Text = "Checked"
        Else
            Me.CheckBox1.Text = "Unchecked"
        End If
    End Sub
    '</Snippet63>


    '*************************************************************************
    '<Snippet25>
    ' Visual Basic
    ' Using Label controls.
    Private Sub Form1_Load(sender As Object,
e As System.EventArgs) Handles MyBase.Load
        Dim Line1 As New System.Windows.Forms.Label
        Dim Line2 As New System.Windows.Forms.Label
        ' Draw a horizontal line 14 pixels from the top of the form.
        Line1.Location = New System.Drawing.Point(0, 14)
        Line1.Size = New System.Drawing.Size(Me.Width, 1)
        Line1.BorderStyle = BorderStyle.None
        Line1.BackColor = System.Drawing.Color.Red
        Line1.Text = ""
        Me.Controls.Add(Line1)
        ' Draw a vertical line 14 pixels from the left of the form.
        Line2.Location = New System.Drawing.Point(14, 0)
        Line2.Size = New System.Drawing.Size(1, Me.Height)
        Line2.BorderStyle = BorderStyle.None
        Line2.BackColor = System.Drawing.Color.Blue
        Line2.Text = ""
        Me.Controls.Add(Line2)
    End Sub
    '</Snippet25>


    '******************************************************************************
    Private Sub TestLoad(sender As Object, e As System.EventArgs) Handles MyBase.Load


        '****************************
        '<Snippet11>
        ' Visual Basic
        ' Set the first button to respond to the Enter key.
        Me.AcceptButton = Me.Button1
        ' Set the second button to respond to the Esc key.
        Me.CancelButton = Me.Button2
        '</Snippet11>


        '****************************
        '<Snippet2>
        ' Visual Basic
        Me.PictureBox1.Image = System.Drawing.Bitmap.FromFile(
    My.Application.Info.DirectoryPath & "\Logo.jpg")
        '</Snippet2>


        '****************************
        '<Snippet1>
        ' Visual Basic
        Me.Label1.Text = My.Application.Info.Version.ToString()
        '</Snippet1>

    End Sub


    '******************************************************************************
    '<Snippet19>
    ' Visual Basic
    Private Sub Form1_FormClosing(sender As Object,
                              e As System.Windows.Forms.FormClosingEventArgs
    ) Handles MyBase.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
    End Sub
    '</Snippet19>


    '******************************************************************************
    'IN APPLICATION EVENTS.vb
    ' '' Visual Basic
    ' '' Assumes that the Make Single Instance Application checkbox in the 
    ' '' Project Designer has been checked.
    ''Private Sub MyApplication_StartupNextInstance(
    ''    ByVal sender As Object, 
    ''    ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs
    ''    ) Handles Me.StartupNextInstance
    ''
    ''    MsgBox("The application is already running!")
    ''End Sub


    '******************************************************************************
    Private Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub


    '******************************************************************************
    Private Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click

        '<Snippet22>
        ' Visual Basic
        MsgBox(CStr(My.Application.OpenForms.Count))
        '</Snippet22>


        '<Snippet23>
        ' Visual Basic
        For Each f As Form In My.Application.OpenForms
            f.Text = "Hello"
        Next
        '</Snippet23>

    End Sub

End Class
