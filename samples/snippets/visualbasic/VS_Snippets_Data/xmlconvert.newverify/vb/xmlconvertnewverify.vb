Imports System.Xml

Module Module1

    Sub Main()

        '<snippet5>
        Dim writer5 As XmlTextWriter = New XmlTextWriter("outFile.xml", Nothing)
        Dim illegalWhiteSpaceChar As Char = "_"

        Try
            ' Write the root element.
            writer5.WriteStartElement("root")
            writer5.WriteStartElement("legalElement")
            ' Throw an exception due illegal white space character.
            writer5.WriteString("ValueText" + _
                XmlConvert.VerifyWhitespace("   " + illegalWhiteSpaceChar))

            writer5.WriteEndElement()

            ' Write the end tag for the root element.
            writer5.WriteEndElement()

            writer5.Close()

        Catch e As XmlException
            Console.WriteLine(e.Message)
            writer5.Close()
        End Try

        '</snippet5>

        '<snippet4>
        Dim writer4 As XmlTextWriter = New XmlTextWriter("outFile.xml", Nothing)
        Dim illegalPubIdChar As Char = "^"

        Try
            ' Throw exception for illegal public id character.
            writer4.WriteDocType("testPublic", _
                    XmlConvert.VerifyPublicId("pubId" + illegalPubIdChar), _
                    Nothing, Nothing)
            ' Write the root element.
            writer4.WriteStartElement("root")

            writer4.WriteStartElement("legalElement")

            writer4.WriteString("ValueText")
            writer4.WriteEndElement()

            ' Write the end tag for the root element.
            writer4.WriteEndElement()

            writer4.Close()

        Catch e As XmlException
            Console.WriteLine(e.Message)
            writer4.Close()
        End Try

        '</snippet4>

        '<snippet3>
        Dim writer3 As XmlTextWriter = New XmlTextWriter("outFile.xml", Nothing)
        Dim illegalChar As Char = ChrW(CInt("&hFFFE"))
        Dim charsToVerify As String = "Test String "

        Try
            ' Write the root element.
            writer3.WriteStartElement("root")

            ' Throw an exception for name that contains illegal character.
            writer3.WriteStartElement( _
                XmlConvert.VerifyXmlChars(charsToVerify + illegalChar))

            writer3.WriteString("ValueText")
            writer3.WriteEndElement()

            ' Write the end tag for the root element.
            writer3.WriteEndElement()

            writer3.Close()


        Catch e As XmlException

            Console.WriteLine(e.Message)
            writer3.Close()
        End Try

        '</snippet3>

        '<snippet2>
        Dim writer2 As XmlTextWriter = New XmlTextWriter("outFile.xml", Nothing)
        Dim illegalNMToken As String = "item^name"

        Try
            ' Write the root element.
            writer2.WriteStartElement("root")

            ' Throw an exception for name that contains illegal token.
            writer2.WriteStartElement( _
                XmlConvert.VerifyNMTOKEN(illegalNMToken))

            writer2.WriteString("ValueText")
            writer2.WriteEndElement()

            ' Write the end tag for the root element.
            writer2.WriteEndElement()

            writer2.Close()


        Catch e As XmlException

            Console.WriteLine(e.Message)
            writer2.Close()
        End Try

        '</snippet2>

        '<snippet1>
        Dim writer As XmlTextWriter = New XmlTextWriter("outFile.xml", Nothing)
        Dim illegalNCName As String = "item:name"

        Try
            ' Write the root element.
            writer.WriteStartElement("root")

            ' Throw an exception due name that contains colon.
            writer.WriteStartElement( _
                XmlConvert.VerifyNCName(illegalNCName))

            writer.WriteString("ValueText")
            writer.WriteEndElement()

            ' Write the end tag for the root element.
            writer.WriteEndElement()

            writer.Close()


        Catch e As XmlException

            Console.WriteLine(e.Message)
            writer.Close()
        End Try

        '</snippet1>
    End Sub

End Module
