
    ' Declare the dialog.
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog

    ' Declare a PrintDocument object named document.
    Private WithEvents document As New System.Drawing.Printing.PrintDocument

    ' Initalize the dialog.
    Private Sub InitializePrintPreviewDialog()

        ' Create a new PrintPreviewDialog using constructor.
        Me.PrintPreviewDialog1 = New PrintPreviewDialog

        'Set the size, location, and name.
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Location = New System.Drawing.Point(29, 29)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"

        ' Set the minimum size the dialog can be resized to.
        Me.PrintPreviewDialog1.MinimumSize = New System.Drawing.Size(375, 250)

        ' Set the UseAntiAlias property to true, which will allow the 
        ' operating system to smooth fonts.
        Me.PrintPreviewDialog1.UseAntiAlias = True
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If (TreeView1.SelectedNode IsNot Nothing) Then

            ' Set the PrintDocument object's name to the selectedNode
            ' object's  tag, which in this case contains the 
            ' fully-qualified name of the document. This value will 
            ' show when the dialog reports progress.
            document.DocumentName = TreeView1.SelectedNode.Tag
        End If

        ' Set the PrintPreviewDialog.Document property to
        ' the PrintDocument object selected by the user.
        PrintPreviewDialog1.Document = document

        ' Call the ShowDialog method. This will trigger the document's
        '  PrintPage event.
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub document_PrintPage(ByVal sender As Object, _
        ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
            Handles document.PrintPage

        ' Insert code to render the page here.
        ' This code will be called when the PrintPreviewDialog.Show 
        ' method is called.

        ' The following code will render a simple
        ' message on the document in the dialog.
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)

        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 0, 0)

    End Sub