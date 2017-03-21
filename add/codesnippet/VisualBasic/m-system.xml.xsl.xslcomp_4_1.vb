' Create a reader that contains the style sheet.
Dim reader As XmlReader = XmlReader.Create("titles.xsl")
reader.ReadToDescendant("xsl:stylesheet")
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load(reader)