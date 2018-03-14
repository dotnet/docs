' <Snippet1>


Imports System
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Xml

Namespace UEBodyWriter
	Friend Class MyBodyWriter
		Inherits BodyWriter
		Private Const textTag As String = "text"
		Private bodySegment() As String

		Public Sub New(ByVal strData() As String)
			MyBase.New(True)
            Dim length = strData.Length

			Me.bodySegment = New String(length - 1){}
            For i = 0 To length - 1
                Me.bodySegment(i) = strData(i)
            Next i
		End Sub

		' <Snippet3>
		Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
		   writer.WriteStartElement(textTag)

            For Each str As String In bodySegment
                writer.WriteString(str)
            Next str

			writer.WriteEndElement()
		End Sub
		' </Snippet3>
	End Class

    Module Module1
        Sub Main(ByVal args() As String)
            ' <Snippet4>
            Dim strings() As String = {"Hello", "world"}
            Dim bw As New MyBodyWriter(strings)

            Dim strBuilder As New StringBuilder(10)
            Dim writer = XmlWriter.Create(strBuilder)
            Dim dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer)

            bw.WriteBodyContents(dictionaryWriter)
            dictionaryWriter.Flush()
            ' </Snippet4>
        End Sub
    End Module
End Namespace
' </Snippet1>