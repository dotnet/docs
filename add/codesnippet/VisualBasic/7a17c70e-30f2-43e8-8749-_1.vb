		Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
		   writer.WriteStartElement(textTag)

            For Each str As String In bodySegment
                writer.WriteString(str)
            Next str

			writer.WriteEndElement()
		End Sub