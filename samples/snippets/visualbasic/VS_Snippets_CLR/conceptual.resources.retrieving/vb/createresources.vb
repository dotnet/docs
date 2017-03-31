' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Resources

Module Example
   Public Sub Main()
      Dim bmp As New Bitmap(".\SplashScreen.jpg")
      Dim imageStream As New MemoryStream()
      bmp.Save(imageStream, ImageFormat.Jpeg)
      
      Dim writer As New ResXResourceWriter("AppResources.resx")
      writer.AddResource("SplashScreen", imageStream)
      writer.Generate()
      writer.Close()      
   End Sub
End Module
' </Snippet4>

