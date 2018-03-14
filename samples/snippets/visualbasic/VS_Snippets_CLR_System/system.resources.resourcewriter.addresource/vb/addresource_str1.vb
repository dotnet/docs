' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Drawing
Imports System.IO
Imports System.Resources

Module Example
   Public Sub Main()
      ' Bitmap as stream
      Dim bitmapStream As New MemoryStream()
      Dim bmp As New Bitmap(".\\AppImage.jpg")
      bmp.Save(bitmapStream, Imaging.ImageFormat.Jpeg)
          
      Using rw As New ResourceWriter(".\UIImages.resources")
         rw.AddResource("Bitmap", bitmapStream)
         ' Add other resources.
      End Using
   End Sub
End Module
' </Snippet2>
