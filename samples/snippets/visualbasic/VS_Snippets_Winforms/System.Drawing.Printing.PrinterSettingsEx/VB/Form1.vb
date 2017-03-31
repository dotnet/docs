

Imports System.Drawing.Printing
Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Shared Sub main()
        Application.Run(New Form1())
    End Sub
'<snippet1>

    Private WithEvents comboInstalledPrinters As New ComboBox
    Private WithEvents printDoc As New PrintDocument

    Private Sub PopulateInstalledPrintersCombo()
        comboInstalledPrinters.Dock = DockStyle.Top
        Controls.Add(comboInstalledPrinters)

        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            comboInstalledPrinters.Items.Add(pkInstalledPrinters)
            If (printDoc.PrinterSettings.IsDefaultPrinter()) Then
                comboInstalledPrinters.Text = printDoc.PrinterSettings.PrinterName
            End If
        Next
    End Sub

'</snippet1>

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateInstalledPrintersCombo()
    End Sub
End Class


