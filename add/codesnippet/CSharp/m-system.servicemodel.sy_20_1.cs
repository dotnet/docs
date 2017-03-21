            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            Atom10ItemFormatter atomFormatter = item.GetAtom10Formatter();
            XmlWriter writer = XmlWriter.Create("output.xml");
            atomFormatter.WriteTo(writer);
            writer.Close();