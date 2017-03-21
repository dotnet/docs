' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("sort.xsl", XsltSettings.Default, New XmlUrlResolver())