Public Class Form3


'*************************************************************************
'<Snippet72>
' Visual Basic
Private Sub Form1_Load2() Handles MyBase.Load
    TextBox1.MaxLength = 5
End Sub
Private Sub SetText()
    ' Truncate the string to equal MaxLength.
    TextBox1.Text = Strings.Left("Hello World", TextBox1.MaxLength)
End Sub
'</Snippet72>


'*************************************************************************
'<Snippet71>
' Visual Basic
Private Sub Form1_Load() Handles MyBase.Load
    TextBox1.Text = "Two of the peak human experiences are "
    TextBox1.Text = TextBox1.Text & "good food and classical music."
End Sub
Private Sub Form1_Click() Handles Me.Click
    Dim Search As String
    Dim Where As String
    ' Get search string from user.
    Search = InputBox("Enter text to be found:")
    ' Find string in text.
    Where = InStr(TextBox1.Text, Search)
    If Where Then
        TextBox1.Focus()
        TextBox1.SelectionStart = Where - 1
        TextBox1.SelectionLength = Len(Search)
    Else
        MsgBox("String not found.")
    End If
End Sub
'</Snippet71>


'*************************************************************************
Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  '<Snippet60>
  ' Assign the first image (Picture) to the Image property.
  CheckBox1.Image = ImageList1.Images(0)
  '</Snippet60>
End Sub


'*************************************************************************
Private Sub Test2()
  '<Snippet62>
  If CheckBox1.Enabled = False Then
    ' Assign the third image (DisabledPicture) to the Image property.
    CheckBox1.Image = ImageList1.Images(2)
  ElseIf CheckBox1.Checked = True Then
    ' Assign the second image (DownPicture) to the Image property
    CheckBox1.Image = ImageList1.Images(1)
  Else
    ' Assign the first image (Picture)to the Image property
    CheckBox1.Image = ImageList1.Images(0)
  End If
  '</Snippet62>
End Sub


'*************************************************************************
Private Sub Test()
  '<Snippet61>
  If CheckBox1.Checked = True Then
    ' Assign the second image (DownPicture) to the Image property.
    CheckBox1.Image = ImageList1.Images(1)
  Else
    ' Assign the first image (Picture) to the Image property.
    CheckBox1.Image = ImageList1.Images(0)
  End If
  '</Snippet61>


  '<Snippet79>
  ' Visual Basic
  ' Specify the color to be used as a mask and use the mask.
  ImageList1.TransparentColor = Color.White
  ' Don't use the mask.
  ImageList1.TransparentColor = Color.Transparent
  '</Snippet79>


End Sub



'******************************************************************************
'<Snippet17>
' Visual Basic
Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ' Create a new TextBox control.
    Dim TextBox1 As New System.Windows.Forms.TextBox
    TextBox1.Name = "TextBox1"
    ' Add the new control to the form's Controls collection.
    Me.Controls.Add(TextBox1)
    ' No need to set Visible property.
    ' Set the initial text.
    TextBox1.Text = "Hello"
    ' Retrieve the text from the new TextBox.
    If Me.Controls.Count > 1 Then
        MsgBox(Me.Controls("TextBox1").Text)
    End If
    ' Remove the new control.
    Me.Controls.Remove(TextBox1)
    ' Remove the control added at design time.
    Me.Controls.Remove(Button1)
End Sub
'</Snippet17>


'******************************************************************************
'<Snippet18>
' Visual Basic
Private Sub ClearChecks(ByVal Container As Control)
    Dim ctl As Control
    Dim chk As CheckBox
    For Each ctl In Container.Controls
        If TypeOf ctl Is CheckBox Then
            chk = ctl
            chk.Checked = False
        End If
        ' Recursively call this function for any container controls.
        If ctl.HasChildren Then
            ClearChecks(ctl)
        End If
    Next
End Sub
'</Snippet18>


Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
  ClearChecks(Me.GroupBox1)
End Sub


'******************************************************************************
'<Snippet20>
' Visual Basic
Private Sub TextBox1_Validating(
    ByVal sender As Object, 
    ByVal e As System.ComponentModel.CancelEventArgs
  ) Handles TextBox1.Validating

    If TextBox1.Text = "" Then
        MsgBox("Please enter a name")
        e.Cancel = True
    End If
End Sub
'</Snippet20>


'******************************************************************************
'<Snippet21>
Private Sub Form1_FormClosing(
    ByVal sender As System.Object, 
    ByVal e As System.Windows.Forms.FormClosingEventArgs
  ) Handles MyBase.FormClosing
    ' If validation failed cancel the Closing event.
    If Me.Validate = False Then
        e.Cancel = True
    End If
End Sub
'</Snippet21>
End Class