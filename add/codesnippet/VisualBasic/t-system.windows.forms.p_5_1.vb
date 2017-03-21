
    ' Declare the PrintDocument object.
    Private WithEvents docToPrint As New Printing.PrintDocument

    ' This method will set properties on the PrintDialog object and
    ' then display the dialog.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Allow the user to choose the page range he or she would
        ' like to print.
        PrintDialog1.AllowSomePages = True

        ' Show the help button.
        PrintDialog1.ShowHelp = True

        ' Set the Document property to the PrintDocument for 
        ' which the PrintPage Event has been handled. To display the
        ' dialog, either this property or the PrinterSettings property 
        ' must be set 
        PrintDialog1.Document = docToPrint

        Dim result As DialogResult = PrintDialog1.ShowDialog()

        ' If the result is OK then print the document.
        If (result = DialogResult.OK) Then
            docToPrint.Print()
        End If
	
    End Sub

    ' The PrintDialog will print the document
    ' by handling the document's PrintPage event.
    Private Sub document_PrintPage(ByVal sender As Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
           Handles docToPrint.PrintPage

        ' Insert code to render the page here.
        ' This code will be called when the control is drawn.

        ' The following code will render a simple
        ' message on the printed document.
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)

        ' Draw the content.
        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 10, 10)
    End Sub