            Dim strings() As String = {"Hello", "world"}
			Dim bodyWriter As New MyBodyWriter(strings)

			Dim strBuilder As New StringBuilder(10)
			Dim writer As XmlWriter = XmlWriter.Create(strBuilder)
			Dim dictionaryWriter As XmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer)

			bodyWriter.WriteBodyContents(dictionaryWriter)
			dictionaryWriter.Flush()

			Dim bufferedBodyWriter As MyBodyWriter = CType(bodyWriter.CreateBufferedCopy(1024), MyBodyWriter)