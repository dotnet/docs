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
