        ' Create the XslCompiledTransform object.
        Dim xslt As New XslCompiledTransform(True)

        ' Load the style sheet and enable scripts.
        ' Temporary files are created only for style sheets with <msxsl:script> blocks.
        xslt.Load("output.xsl", XsltSettings.TrustedXslt, New XmlUrlResolver())

        ' Transform the file.
        xslt.Transform("books.xml", "output.xml")

        ' Output names of temporary files.
        Dim filename As String
        For Each filename In xslt.TemporaryFiles
            Console.WriteLine(filename)
        Next filename