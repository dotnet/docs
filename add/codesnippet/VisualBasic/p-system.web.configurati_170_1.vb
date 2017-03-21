        ' Get the current PageParserFilterType property value.
        Console.WriteLine( _
            "Current PageParserFilterType value: '{0}'", _
            pagesSection.PageParserFilterType)

        ' Set the PageParserFilterType property to
        ' "MyNameSpace.AllowOnlySafeControls".
        pagesSection.PageParserFilterType = _
            "MyNameSpace.AllowOnlySafeControls"