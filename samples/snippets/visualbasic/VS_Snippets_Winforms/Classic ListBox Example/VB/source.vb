Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub button1_Click(sender As Object, e As System.EventArgs)
     ' Create an instance of the ListBox.
     Dim listBox1 As New ListBox()
     ' Set the size and location of the ListBox.
     listBox1.Size = New System.Drawing.Size(200, 100)
     listBox1.Location = New System.Drawing.Point(10, 10)
     ' Add the ListBox to the form.
     Me.Controls.Add(listBox1)
     ' Set the ListBox to display items in multiple columns.
     listBox1.MultiColumn = True
     ' Set the selection mode to multiple and extended.
     listBox1.SelectionMode = SelectionMode.MultiExtended
     
     ' Shutdown the painting of the ListBox as items are added.
     listBox1.BeginUpdate()
     ' Loop through and add 50 items to the ListBox.
     Dim x As Integer
     For x = 1 To 50
         listBox1.Items.Add("Item " & x.ToString())
     Next x
     ' Allow the ListBox to repaint and display the new items.
     listBox1.EndUpdate()
     
     ' Select three items from the ListBox.
     listBox1.SetSelected(1, True)
     listBox1.SetSelected(3, True)
     listBox1.SetSelected(5, True)
        
     ' Display the second selected item in the ListBox to the console.
     System.Diagnostics.Debug.WriteLine(listBox1.SelectedItems(1).ToString())
     ' Display the index of the first selected item in the ListBox.
     System.Diagnostics.Debug.WriteLine(listBox1.SelectedIndices(0).ToString())
 End Sub

' </Snippet1>
End Class

