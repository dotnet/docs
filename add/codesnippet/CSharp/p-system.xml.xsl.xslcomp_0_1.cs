    // Create the XslCompiledTransform object.
    XslCompiledTransform xslt = new XslCompiledTransform(true);

    // Load the style sheet and enable scripts.
    // Temporary files are created only for style sheets with <msxsl:script> blocks.
    xslt.Load("output.xsl", XsltSettings.TrustedXslt, new XmlUrlResolver());

    // Transform the file.
    xslt.Transform("books.xml", "output.xml");

    // Output names of temporary files.
    foreach (string filename in xslt.TemporaryFiles)
        Console.WriteLine(filename);