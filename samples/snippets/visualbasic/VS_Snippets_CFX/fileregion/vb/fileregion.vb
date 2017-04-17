Imports System.IO.Log
Imports System.IO
Imports System.Xml
'<snippet0>
Friend Class LogBackup
	Private Shared Sub ArchiveToXML(ByVal logStore As LogStore, ByVal fileName As String)


		Dim snapshot As LogArchiveSnapshot = logStore.CreateLogArchiveSnapshot()
			Dim writer As New XmlTextWriter(fileName, System.Text.Encoding.ASCII)
			writer.WriteStartElement("logArchive")

        For Each region As FileRegion In snapshot.ArchiveRegions
            With writer
                .WriteStartElement("fileRegion")
                .WriteElementString("path", region.Path)
                .WriteElementString("length", region.FileLength.ToString())
                .WriteElementString("offset", region.Offset.ToString())
            End With

            Using dataStream As Stream = region.GetStream()
                Dim data(dataStream.Length - 1) As Byte
                dataStream.Read(data, 0, data.Length)

                writer.WriteElementString("data", System.Convert.ToBase64String(data))
            End Using

            writer.WriteEndElement()
        Next region

			writer.Close()
			logStore.SetArchiveTail(snapshot.LastSequenceNumber)
	End Sub

	Private Shared Sub RestoreFromXML(ByVal fileName As String)
		Using reader As New XmlTextReader(fileName)
			reader.ReadStartElement("logArchive")
			Do While reader.IsStartElement()
				Dim path As String
				Dim length As Long
				Dim offset As Long
				path = reader.ReadElementString("path")
				length = System.Int64.Parse(reader.ReadElementString("length"))
				offset = System.Int64.Parse(reader.ReadElementString("offset"))
                Dim dataString = reader.ReadElementString("data")
                Dim data() = System.Convert.FromBase64String(dataString)
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
'</snippet0>