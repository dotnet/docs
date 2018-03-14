Imports System
Imports System.IO.Log
Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml

Namespace Snippets
    '<Snippet0>
    Friend Class LogBackup
        Private Shared Sub ArchiveToXML(ByVal logStore As LogStore, ByVal fileName As String)
            Dim snapshot As LogArchiveSnapshot = logStore.CreateLogArchiveSnapshot()

            Dim writer As New XmlTextWriter(fileName, Encoding.ASCII)

            writer.WriteStartElement("logArchive")
            For Each region As FileRegion In snapshot.ArchiveRegions
                writer.WriteStartElement("fileRegion")
                writer.WriteElementString("path", region.Path)
                writer.WriteElementString("length", region.FileLength.ToString())
                writer.WriteElementString("offset", region.Offset.ToString())
                Using dataStream As Stream = region.GetStream()
                    Dim data(dataStream.Length - 1) As Byte
                    dataStream.Read(data, 0, data.Length)
                    writer.WriteElementString("data", Convert.ToBase64String(data))
                End Using
                writer.WriteEndElement()
            Next region
            writer.WriteEndElement()
            writer.Close()
            logStore.SetArchiveTail(snapshot.LastSequenceNumber)

        End Sub
        Private Shared Sub RestoreFromXML(ByVal fileName As String)
            Using reader As New XmlTextReader(fileName)
                reader.ReadStartElement("logArchive")
                Do While reader.IsStartElement()
                    Dim path = reader.ReadElementString("path")
                    Dim length = Int64.Parse(reader.ReadElementString("length"))
                    Dim offset = Int64.Parse(reader.ReadElementString("offset"))
                    Dim dataString = reader.ReadElementString("data")
                    Dim data() = Convert.FromBase64String(dataString)
                    Dim fileStream As FileStream
                    fileStream = New FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)
                    Using fileStream
                        fileStream.SetLength(length)
                        fileStream.Position = offset
                        fileStream.Write(data, 0, data.Length)
                    End Using
                Loop
                reader.ReadEndElement()
            End Using
        End Sub
    End Class
    '</Snippet0>
End Namespace