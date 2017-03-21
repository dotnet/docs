            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            XmlWriter writer = XmlWriter.Create("outfile.xml");
            item.SaveAsAtom10(writer);
            writer.Close();