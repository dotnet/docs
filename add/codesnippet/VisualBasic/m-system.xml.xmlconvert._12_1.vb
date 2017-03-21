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
