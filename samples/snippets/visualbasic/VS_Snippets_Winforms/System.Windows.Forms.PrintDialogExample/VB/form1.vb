Imports System.Windows.Forms
Imports System.Drawing

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
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Print"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    <System.STAThread()> Public Shared Sub main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>

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
    '</snippet1>


End Class
