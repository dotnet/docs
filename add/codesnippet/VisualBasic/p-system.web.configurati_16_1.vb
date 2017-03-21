        ' Get all current TagMappings in the collection.
        Dim k As Int32
        For k = 1 To pagesSection.TagMapping.Count
          Console.WriteLine("TagMapping {0}:", i)
          Console.WriteLine("  TagTypeName = '{0}'", _
           pagesSection.TagMapping(k).TagType)
          Console.WriteLine("  MappedTagTypeName = '{0}'", _
           pagesSection.TagMapping(k).MappedTagType)
        Next