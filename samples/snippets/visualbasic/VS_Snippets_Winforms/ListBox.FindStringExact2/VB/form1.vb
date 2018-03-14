Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'ListBox1
      '
      Me.ListBox1.Items.AddRange(New Object() {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Alpha2", "Alpha3", "Bravo2", "Charlie2", "Delta3", "Echo2", "Delta2", "Foxtrot2"})
      Me.ListBox1.Location = New System.Drawing.Point(32, 24)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(224, 134)
      Me.ListBox1.TabIndex = 0
      '
      'TextBox1
      '
      Me.TextBox1.Location = New System.Drawing.Point(32, 184)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.TabIndex = 1
      Me.TextBox1.Text = "TextBox1"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(144, 184)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 2
      Me.Button1.Text = "Button1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.TextBox1, Me.ListBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   '<Snippet1>
   Private Sub FindAllOfMyExactStrings(ByVal searchString As String)
      ' Set the SelectionMode property of the ListBox to select multiple items.
      ListBox1.SelectionMode = SelectionMode.MultiExtended

      ' Set our intial index variable to -1.
      Dim x As Integer = -1
      ' If the search string is empty exit.
      If searchString.Length <> 0 Then
         ' Loop through and find each item that matches the search string.
         Do
            ' Retrieve the item based on the previous index found. Starts with -1 which searches start.
            x = ListBox1.FindStringExact(searchString, x)
            ' If no item is found that matches exit.
            If x <> -1 Then
               ' Since the FindStringExact loops infinitely, determine if we found first item again and exit.
               If ListBox1.SelectedIndices.Count > 0 Then
                  If x = ListBox1.SelectedIndices(0) Then
                     Return
                  End If
               End If
               ' Select the item in the ListBox once it is found.
               ListBox1.SetSelected(x, True)
            End If
         Loop While x <> -1
      End If
   End Sub
   '</Snippet1>

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      FindAllOfMyExactStrings(TextBox1.Text)
   End Sub
End Class
