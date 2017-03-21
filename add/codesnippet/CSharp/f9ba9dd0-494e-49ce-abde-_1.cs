            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            Atom10ItemFormatter atomItemFormatter = new Atom10ItemFormatter(item);
            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            atomItemFormatter.WriteTo(atomWriter);
            atomWriter.Close();