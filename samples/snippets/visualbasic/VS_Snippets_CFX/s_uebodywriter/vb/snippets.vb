
Imports System
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Xml


Namespace UEBodyWriter
	Friend Class Snippets
		Public Shared Sub Snippet2()
			' <Snippet2>
            Dim strings() As String = {"Hello", "world"}
			Dim bodyWriter As New MyBodyWriter(strings)

			Dim strBuilder As New StringBuilder(10)
			Dim writer As XmlWriter = XmlWriter.Create(strBuilder)
			Dim dictionaryWriter As XmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer)

			bodyWriter.WriteBodyContents(dictionaryWriter)
			dictionaryWriter.Flush()

			Dim bufferedBodyWriter As MyBodyWriter = CType(bodyWriter.CreateBufferedCopy(1024), MyBodyWriter)
			' </Snippet2>
		End Sub
	End Class
End Namespace
