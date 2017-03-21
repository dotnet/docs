            CodeSnippetStatement snippet1 = new CodeSnippetStatement();
            snippet1.Value = "            Console.WriteLine(field1);";

            CodeRegionDirective regionStart = new CodeRegionDirective(CodeRegionMode.End, "");
            regionStart.RegionText = "Snippet Region";
            regionStart.RegionMode = CodeRegionMode.Start;
            snippet1.StartDirectives.Add(regionStart);
            snippet1.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));