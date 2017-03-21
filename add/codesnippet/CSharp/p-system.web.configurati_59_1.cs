        // Get all current TagMappings in the collection.
        for (int i = 0; i < pagesSection.TagMapping.Count; i++)
        {
          Console.WriteLine("TagMapping {0}:", i);
          Console.WriteLine("  TagTypeName = '{0}'",
              pagesSection.TagMapping[i].TagType);
          Console.WriteLine("  MappedTagTypeName = '{0}'",
              pagesSection.TagMapping[i].MappedTagType);
        }

        // Add a TagMapInfo object using a constructor.
        pagesSection.TagMapping.Add(
            new System.Web.Configuration.TagMapInfo(
            "MyNameSpace.MyControl", "MyNameSpace.MyOtherControl"));