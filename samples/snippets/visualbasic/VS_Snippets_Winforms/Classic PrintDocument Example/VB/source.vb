' <Snippet1>
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private WithEvents printButton As System.Windows.Forms.Button
    Private printFont As Font
    Private streamToPrint As StreamReader

    Public Sub New()
        ' The Windows Forms Designer requires the following call.
        InitializeComponent()
        InitializeForm()
    End Sub

    ' The Click event is raised when the user clicks the Print button.
    Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printButton.Click
        Try
            streamToPrint = New StreamReader("C:\My Documents\MyFile.txt")
            Try
                printFont = New Font("Arial", 10)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

    Private Sub InitializeForm()
        Me.components = New System.ComponentModel.Container()
        Me.printButton = New System.Windows.Forms.Button()

        Me.ClientSize = New System.Drawing.Size(504, 381)
        Me.Text = "Print Example"

        printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        printButton.Location = New System.Drawing.Point(32, 110)
        printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        printButton.TabIndex = 0
        printButton.Text = "Print the file."
        printButton.Size = New System.Drawing.Size(136, 40)
        AddHandler printButton.Click, AddressOf printButton_Click

        Me.Controls.Add(printButton)
    End Sub


    ' This is the main entry point for the application.    
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

End Class

' </Snippet1>