Imports System.Windows.Forms

Public Class MDIParent1

  '******************************************************************************
  '<Snippet31>
  ' Visual Basic
  Private Sub MDIForm1_Load(
    ByVal sender As System.Object, 
    ByVal e As System.EventArgs) Handles MyBase.Load

    Dim i As Integer = 0
    For i = 0 To 4
        Dim F As New FormChild
        F.Text = "Form " & CStr(i + 1)
        F.Show()
    Next
  End Sub
  '</Snippet31>


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt"
        OpenFileDialog.ShowDialog(Me)

        Dim FileName As String = OpenFileDialog.FileName
        ' TODO: Add code here to open the file.
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt"
        SaveFileDialog.ShowDialog(Me)

        Dim FileName As String = SaveFileDialog.FileName
        ' TODO: Add code here to save the current contents of the form to a file.
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub


  '******************************************************************************
  '<Snippet32>
  ' Visual Basic
  Private Sub CascadeToolStripMenuItem_Click(
    ) Handles CascadeToolStripMenuItem.Click

    Me.LayoutMdi(MdiLayout.Cascade)
  End Sub
  '</Snippet32>


  '******************************************************************************
  '<Snippet33>
  ' Visual Basic
  Private Sub TileVerticleToolStripMenuItem_Click(
    ) Handles TileVerticalToolStripMenuItem.Click

    Me.LayoutMdi(MdiLayout.TileVertical)
  End Sub
  '</Snippet33>


  '******************************************************************************
  '<Snippet34>
  ' Visual Basic
  Private Sub TileHorizontalToolStripMenuItem_Click(
    ) Handles TileHorizontalToolStripMenuItem.Click

    Me.LayoutMdi(MdiLayout.TileHorizontal)
  End Sub
  '</Snippet34>


    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

End Class
