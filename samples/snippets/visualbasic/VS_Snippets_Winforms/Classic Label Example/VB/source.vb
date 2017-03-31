Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected imageList1 As ImageList
    
' <Snippet1>
 Public Sub CreateMyLabel()
     ' Create an instance of a Label.
     Dim label1 As New Label()
        
     ' Set the border to a three-dimensional border.
     label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
     ' Set the ImageList to use for displaying an image.
     label1.ImageList = imageList1
     ' Use the second image in imageList1.
     label1.ImageIndex = 1
     ' Align the image to the top left corner.
     label1.ImageAlign = ContentAlignment.TopLeft
      
     ' Specify that the text can display mnemonic characters.
     label1.UseMnemonic = True
     ' Set the text of the control and specify a mnemonic character.
     label1.Text = "First &Name:"
        
     ' Set the size of the control based on the PreferredHeight and PreferredWidth values. 
     label1.Size = New Size(label1.PreferredWidth, label1.PreferredHeight)

     '...Code to add the control to the form...
 End Sub

' </Snippet1>
End Class 'Form1 


