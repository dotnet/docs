// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("sort.xsl", XsltSettings.Default, new XmlUrlResolver());