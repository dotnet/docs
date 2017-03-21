        Dim snippet1 As New CodeSnippetStatement()
        snippet1.Value = "            Console.WriteLine(field1)"

        Dim regionStart As New CodeRegionDirective(CodeRegionMode.End, "")
        regionStart.RegionText = "Snippet Region"
        regionStart.RegionMode = CodeRegionMode.Start
        snippet1.StartDirectives.Add(regionStart)
        snippet1.EndDirectives.Add(New CodeRegionDirective(CodeRegionMode.End, String.Empty))