        ' Get all current Controls in the collection.
        Dim j As Int32
        For j = 0 To pagesSection.Controls.Count - 1
          Console.WriteLine("Control {0}:", j)
          Console.WriteLine("  TagPrefix = '{0}' ", _
           pagesSection.Controls(j).TagPrefix)
          Console.WriteLine("  TagName = '{0}' ", _
           pagesSection.Controls(j).TagName)
          Console.WriteLine("  Source = '{0}' ", _
           pagesSection.Controls(j).Source)
          Console.WriteLine("  Namespace = '{0}' ", _
           pagesSection.Controls(j).Namespace)
          Console.WriteLine("  Assembly = '{0}' ", _
           pagesSection.Controls(j).Assembly)
        Next

        ' Create a new TagPrefixInfo object.
        Dim tagPrefixInfo As System.Web.Configuration.TagPrefixInfo = _
         New System.Web.Configuration.TagPrefixInfo("MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", "MyControl.ascx")

        ' Execute the Add Method.
        pagesSection.Controls.Add(tagPrefixInfo)

        ' Add a TagPrefixInfo object using a constructor.
        pagesSection.Controls.Add( _
         New System.Web.Configuration.TagPrefixInfo( _
         "MyCtrl", "MyNameSpace", "MyAssembly", "MyControl", _
         "MyControl.ascx"))