Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim printDoc As New PrintDocument()

#Region " Windows Form Designer generated code "

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        MyBase.New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
        Dim i as Integer
        '<Snippet1>
        ' Add list of supported paper sizes found on the printer. 
        ' The DisplayMember property is used to identify the property that will provide the display string.
        comboPaperSize.DisplayMember = "PaperName"

        Dim pkSize As PaperSize
        For i = 0 to printDoc.PrinterSettings.PaperSizes.Count - 1
            pkSize = printDoc.PrinterSettings.PaperSizes.Item(i)
            comboPaperSize.Items.Add(pkSize)
        Next

        ' Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
        Dim pkCustomSize1 As New PaperSize("Custom Paper Size", 100, 200)

        comboPaperSize.Items.Add(pkCustomSize1)
        '</Snippet1>

        '<Snippet2>
        ' Add list of paper sources found on the printer to the combo box.
        ' The DisplayMember property is used to identify the property that will provide the display string.
        comboPaperSource.DisplayMember = "SourceName"
        
        Dim pkSource As PaperSource
        For i = 0 to printDoc.PrinterSettings.PaperSources.Count - 1
            pkSource = printDoc.PrinterSettings.PaperSources.Item(i)
            comboPaperSource.Items.Add(pkSource)
        Next
        '</Snippet2>

        '<Snippet3>
        ' Add list of printer resolutions found on the printer to the combobox.
        ' The PrinterResolution's ToString() method will be used to provide the display string.
        Dim pkResolution As PrinterResolution
        For i = 0 to printDoc.PrinterSettings.PrinterResolutions.Count - 1
            pkResolution = printDoc.PrinterSettings.PrinterResolutions.Item(i)
            comboPrintResolution.Items.Add(pkResolution)
        Next
        '</Snippet3>

        PopulateInstalledPrintersCombo()
    End Sub

    ' Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comboPaperSize As System.Windows.Forms.ComboBox
    Friend WithEvents comboPaperSource As System.Windows.Forms.ComboBox
    Friend WithEvents comboPrintResolution As System.Windows.Forms.ComboBox
    Friend WithEvents MyButtonPrint As System.Windows.Forms.Button
    Friend WithEvents comboInstalledPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.comboPaperSize = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MyButtonPrint = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.comboPrintResolution = New System.Windows.Forms.ComboBox()
        Me.comboPaperSource = New System.Windows.Forms.ComboBox()
        Me.comboInstalledPrinters = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' comboPaperSize
        '
        Me.comboPaperSize.DropDownWidth = 121
        Me.comboPaperSize.Location = New System.Drawing.Point(80, 96)
        Me.comboPaperSize.Name = "comboPaperSize"
        Me.comboPaperSize.Size = New System.Drawing.Size(121, 21)
        Me.comboPaperSize.TabIndex = 3
        '
        ' Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PaperSource"
        '
        ' Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PaperSize"
        '
        ' MyButtonPrint
        '
        Me.MyButtonPrint.Location = New System.Drawing.Point(200, 32)
        Me.MyButtonPrint.Name = "MyButtonPrint"
        Me.MyButtonPrint.TabIndex = 6
        Me.MyButtonPrint.Text = "Print"
        '
        ' Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "PrintResolution"
        '
        ' comboPrintResolution
        '
        Me.comboPrintResolution.DropDownWidth = 121
        Me.comboPrintResolution.Location = New System.Drawing.Point(80, 176)
        Me.comboPrintResolution.Name = "comboPrintResolution"
        Me.comboPrintResolution.Size = New System.Drawing.Size(121, 21)
        Me.comboPrintResolution.TabIndex = 5
        '
        ' comboPaperSource
        '
        Me.comboPaperSource.DropDownWidth = 121
        Me.comboPaperSource.Location = New System.Drawing.Point(80, 136)
        Me.comboPaperSource.Name = "comboPaperSource"
        Me.comboPaperSource.Size = New System.Drawing.Size(121, 21)
        Me.comboPaperSource.TabIndex = 4
        '
        ' comboInstalledPrinters
        '
        Me.comboInstalledPrinters.DropDownWidth = 120
        Me.comboInstalledPrinters.Location = New System.Drawing.Point(80, 216)
        Me.comboInstalledPrinters.Name = "comboInstalledPrinters"
        Me.comboInstalledPrinters.Size = New System.Drawing.Size(120, 21)
        Me.comboInstalledPrinters.TabIndex = 7
        '
        ' Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "InstalledPrinters"
        '
        ' Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.comboInstalledPrinters, Me.MyButtonPrint, Me.comboPrintResolution, Me.comboPaperSource, Me.comboPaperSize, Me.Label3, Me.Label2, Me.Label1, Me.Label4})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)


    End Sub

#End Region
    ' <Snippet4>
    Private Sub MyButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonPrint.Click

        ' Set the paper size based upon the selection in the combo box.
        If comboPaperSize.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PaperSize = _
            printDoc.PrinterSettings.PaperSizes.Item(comboPaperSize.SelectedIndex)
        End If

        ' Set the paper source based upon the selection in the combo box.
        If comboPaperSource.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PaperSource = _
            printDoc.PrinterSettings.PaperSources.Item(comboPaperSource.SelectedIndex)
        End If

        ' Set the printer resolution based upon the selection in the combo box.
        If comboPrintResolution.SelectedIndex <> -1 Then
            printDoc.DefaultPageSettings.PrinterResolution = _
            printDoc.PrinterSettings.PrinterResolutions.Item(comboPrintResolution.SelectedIndex)
        End If

        ' Print the document with the specified paper size and source.
        printDoc.Print()

    End Sub
    '</Snippet4>

    '<Snippet5>
    Private Sub PopulateInstalledPrintersCombo()
        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i as Integer
        Dim pkInstalledPrinters As String

        For i = 0 to PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            comboInstalledPrinters.Items.Add(pkInstalledPrinters)
        Next
    End Sub

    Private Sub comboInstalledPrinters_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboInstalledPrinters.SelectedIndexChanged
        ' Set the printer to a printer in the combo box when the selection changes.

        If comboInstalledPrinters.SelectedIndex <> -1 Then
            ' The combo box's Text property returns the selected item's text, which is the printer name.
            printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text
        End If


    End Sub
    '</Snippet5>

    Protected currentPageNumber As Integer = 1
    '<Snippet6>

    Private Sub MyButtonPrint_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Set the printer name and ensure it is valid. If not, provide a message to the user.
        printDoc.PrinterSettings.PrinterName = "\\mynetworkprinter"

        If printDoc.PrinterSettings.IsValid Then

            ' If the printer supports printing in color, then override the printer's default behavior.
            if printDoc.PrinterSettings.SupportsColor then

                ' Set the page default's to not print in color.
                printDoc.DefaultPageSettings.Color = False
            End If

            ' Provide a friendly name, set the page number, and print the document.
            printDoc.DocumentName = "My Presentation"
            currentPageNumber = 1
            printDoc.Print()
        Else
            MessageBox.Show("Printer is not valid")
        End If
    End Sub

    Private Sub MyPrintQueryPageSettingsEvent(ByVal sender As Object, ByVal e As QueryPageSettingsEventArgs)

        ' Determines if the printer supports printing in color.
        If printDoc.PrinterSettings.SupportsColor Then

            ' If the printer supports color printing, use color.
            If currentPageNumber = 1 Then

                e.PageSettings.Color = True
            End If

        End If
    End Sub

    '</Snippet6>

    Private Sub MyPrintPageEvent(ByVal sender As Object, ByVal e As PrintPageEventArgs)

    End Sub


End Class
