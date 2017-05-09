' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO
Imports System.Resources

Module Example
   Public Sub Main()                      
      ' Get the image as an array of bytes.
      Dim byteStream As New FileStream("AppIcon.jpg", Filemode.Open)
      Dim bytes(CInt(byteStream.Length - 1)) As Byte
      byteStream.Read(bytes, 0, CInt(byteStream.Length))
      
      ' Create the resource file.
      Using rw As New ResourceWriter(".\UIImages.resources")
         rw.AddResource("AppIcon", byteStream)
         ' Add any other resources.
      End Using
   End Sub
End Module
' </Snippet4>
