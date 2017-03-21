        ' Tests for the presence of a CodeDirective in the 
        ' collection, and retrieves its index if it is found.
        Dim testDirective = New CodeRegionDirective(CodeRegionMode.Start, "Region1")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDirective) Then
            itemIndex = collection.IndexOf(testDirective)
        End If