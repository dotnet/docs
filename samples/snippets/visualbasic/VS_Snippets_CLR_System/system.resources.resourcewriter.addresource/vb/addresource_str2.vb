' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Drawing
Imports System.IO
Imports System.Resources

Module Example
   Public Sub Main()
      ' Bitmap as stream
      Dim bitmapStream As New MemoryStream()
      Dim bmp As New Bitmap(".\\AppImage.jpg")
      bmp.Save(bitmapStream, Imaging.ImageFormat.Jpeg)
          
      Dim rw As New ResourceWriter(".\UIImages.resources")
      rw.AddResource("Bitmap", bitmapStream, True)
      ' Add other resources.
      rw.Generate()
   End Sub
End Module
' </Snippet3>
