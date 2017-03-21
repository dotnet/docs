Imports System.Drawing
Imports System.IO
Imports System.Resources
Imports System.Runtime.Serialization.Formatters.Binary

Imports System.Text

Module Example
   Public Sub Main()
      ' Bitmap as stream.
      Dim bitmapStream As New MemoryStream()
      Dim bmp As New Bitmap(".\ContactsIcon.jpg")
      bmp.Save(bitmapStream, Imaging.ImageFormat.jpeg)
          
      ' Define resources to be written.
      Using rw As New ResourceWriter(".\ContactResources.resources")
         rw.AddResource("Title", "Contact List")
         rw.AddResource("NColumns", 5)         
         rw.AddResource("Icon", bitmapStream)         
         rw.AddResource("Header1", "Name")
         rw.AddResource("Header2", "City")
         rw.AddResource("Header3", "State")  
         rw.AddResource("VersionDate", New DateTimeTZI(#05/18/2012#, 
                                                       TimeZoneInfo.Local))
         rw.AddResource("ClientVersion", True)
         rw.Generate()
      End Using
   End Sub
End Module