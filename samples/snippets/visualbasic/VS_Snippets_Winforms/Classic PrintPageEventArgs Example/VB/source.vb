Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    public WithEvents printButton as new Button()
    public WithEvents pd as new PrintDocument()
    
' <Snippet1>
    ' Specifies what happens when the user clicks the Button.
    Private Sub printButton_Click(sender As Object, e As EventArgs) _
	Handles printButton.Click
        Try
           pd.Print()
        Catch ex As Exception
            MessageBox.Show("An error occurred while printing", _
                ex.ToString())
        End Try
    End Sub    
    
    ' Specifies what happens when the PrintPage event is raised.
    Private Sub pd_PrintPage(sender As Object, ev As PrintPageEventArgs) _
	Handles pd.PrintPage

        ' Draw a picture.
        ev.Graphics.DrawImage(Image.FromFile("C:\My Folder\MyFile.bmp"), _
            ev.Graphics.VisibleClipBounds)
        
        ' Indicate that this is the last page to print.
        ev.HasMorePages = False
    End Sub

' </Snippet1>

Public Shared Sub Main()
Application.Run(new Form1())
End Sub
End Class

