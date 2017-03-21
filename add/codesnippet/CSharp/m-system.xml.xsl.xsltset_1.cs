// Create the XsltSettings object with script enabled.
XsltSettings settings = new XsltSettings(false,true);

// Create the XslCompiledTransform object and load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("sort.xsl", settings, new XmlUrlResolver());