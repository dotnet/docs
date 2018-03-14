' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Drawing
Imports System.IO
Imports System.Resources
Imports System.Windows.Forms

Module Example
   Public Sub Main()
      Dim rm As New ResourceManager("AppResources", GetType(Example).Assembly)
      Dim screen As Bitmap = CType(Image.FromStream(rm.GetStream("SplashScreen")), Bitmap)
      
      Dim frm As New Form()
      frm.Size = new Size(300, 300)

      Dim pic As New PictureBox()
      pic.Bounds = frm.RestoreBounds
      pic.BorderStyle = BorderStyle.Fixed3D 
      pic.Image = screen
      pic.SizeMode = PictureBoxSizeMode.StretchImage

      frm.Controls.Add(pic)
      pic.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or
                   AnchorStyles.Left Or AnchorStyles.Right

      frm.ShowDialog()
   End Sub
End Module
' </Snippet5>

