        Dim item As New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now)

        Dim atomItemFormatter As New Atom10ItemFormatter(item)
        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        atomItemFormatter.WriteTo(atomWriter)
        atomWriter.Close()