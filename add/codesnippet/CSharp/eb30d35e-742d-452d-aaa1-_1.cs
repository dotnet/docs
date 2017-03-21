  using (XmlReader reader = XmlReader.Create("dataFile_2.xml")) {
        reader.ReadToDescendant("item");

        reader.MoveToAttribute("colors");
        string[] colors = (string[]) reader.ReadContentAs(typeof(string[]),null);
        foreach (string color in colors) {
           Console.WriteLine("Colors: {0}", color);
        }             		
  }