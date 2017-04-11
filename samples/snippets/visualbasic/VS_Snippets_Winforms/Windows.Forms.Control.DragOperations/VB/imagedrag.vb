Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Namespace DragDrop
    
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private components As System.ComponentModel.Container = Nothing
      
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main

      Private Sub InitializeComponent()
         Me.SuspendLayout()
         ' 
         ' ImageDrag
         ' 
         Me.AllowDrop = True
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Name = "ImageDrag"
         Me.Text = "ImageDrag"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent 



'<snippet1>
Private picture As Image
Private pictureLocation As Point

Public Sub New()
   ' Enable drag-and-drop operations.
   Me.AllowDrop = True
End Sub

Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
   MyBase.OnPaint(e)

   ' If there is an image and it has a location, 
   ' paint it when the Form is repainted.
   If (Me.picture IsNot Nothing) And _
     Not (Me.pictureLocation.Equals(Point.Empty)) Then
      e.Graphics.DrawImage(Me.picture, Me.pictureLocation)
   End If
End Sub

Private Sub Form1_DragDrop(ByVal sender As Object, _
  ByVal e As DragEventArgs) Handles MyBase.DragDrop
   ' Handle FileDrop data.
   If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      ' Assign the file names to a string array, in 
      ' case the user has selected multiple files.
      Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
      Try
         ' Assign the first image to the 'picture' variable.
         Me.picture = Image.FromFile(files(0))
         ' Set the picture location equal to the drop point.
         Me.pictureLocation = Me.PointToClient(New Point(e.X, e.Y))
      Catch ex As Exception
         MessageBox.Show(ex.Message)
         Return
      End Try
   End If

   ' Handle Bitmap data.
   If e.Data.GetDataPresent(DataFormats.Bitmap) Then
      Try
         ' Create an Image and assign it to the picture variable.
         Me.picture = CType(e.Data.GetData(DataFormats.Bitmap), Image)
         ' Set the picture location equal to the drop point.
         Me.pictureLocation = Me.PointToClient(New Point(e.X, e.Y))
      Catch ex As Exception
         MessageBox.Show(ex.Message)
         Return
      End Try
   End If

   ' Force the form to be redrawn with the image.
   Me.Invalidate()
End Sub

Private Sub Form1_DragEnter(ByVal sender As Object, _
  ByVal e As DragEventArgs) Handles MyBase.DragEnter
   ' If the data is a file or a bitmap, display the copy cursor.
   If e.Data.GetDataPresent(DataFormats.Bitmap) _
      Or e.Data.GetDataPresent(DataFormats.FileDrop) Then
      e.Effect = DragDropEffects.Copy
   Else
      e.Effect = DragDropEffects.None
   End If
End Sub
'</snippet1>


   End Class 'ImageDrag 
End Namespace 'DragDrop