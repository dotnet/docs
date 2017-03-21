' Create the XsltSettings object with script enabled.
Dim settings As New XsltSettings(False, True)
        
' Create the XslCompiledTransform object and load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("sort.xsl", settings, New XmlUrlResolver())