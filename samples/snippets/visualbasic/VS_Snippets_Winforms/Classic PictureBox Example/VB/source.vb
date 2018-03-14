Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected pictureBox1 As PictureBox
    
' <Snippet1>
 Private MyImage As Bitmap
    
 Public Sub ShowMyImage(fileToDisplay As String, xSize As Integer, _
                        ySize As Integer)
     ' Sets up an image object to be displayed.
     If (MyImage IsNot Nothing) Then
         MyImage.Dispose()
     End If
        
     ' Stretches the image to fit the pictureBox. 
     pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
     MyImage = New Bitmap(fileToDisplay)
     pictureBox1.ClientSize = New Size(xSize, ySize)
     pictureBox1.Image = CType(MyImage, Image)
 End Sub

' </Snippet1>
End Class

