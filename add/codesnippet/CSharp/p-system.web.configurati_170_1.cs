        // Get the current PageParserFilterType property value.
        Console.WriteLine(
            "Current PageParserFilterType value: '{0}'",
            pagesSection.PageParserFilterType);

        // Set the PageParserFilterType property to
        // "MyNameSpace.AllowOnlySafeControls".
        pagesSection.PageParserFilterType =
            "MyNameSpace.AllowOnlySafeControls";