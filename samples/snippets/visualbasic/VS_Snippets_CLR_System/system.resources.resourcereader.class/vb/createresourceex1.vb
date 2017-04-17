' Visual Basic .NET Document
Option Strict On

' AddResource:
'   String, Byte
'   String, Stream
'   STring, Object
'   String, String

' <Snippet5>
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
' </Snippet5>

' This type is included only so that the example compiles without /r.
<Serializable> Public Structure DateTimeTZI
  Dim [Date] As DateTime
  Dim TimeZone As TimeZoneInfo
   
  Public Sub New([date] As DateTime, tz As TimeZoneInfo)
     Me.[Date] = [date]
     Me.TimeZone = tz
  End Sub
  
  Public Overrides Function ToString() As String
     Return String.Format("{0:dd/MM/yyyy hh:mm:ss tt} {1}", 
                          [Date], TimeZone.StandardName)
  End Function
End Structure