        ' Override the OutputTabs method to set the tab to
        ' the number of spaces defined by the Indent variable.   
        Protected Overrides Sub OutputTabs()
            ' Output the DefaultTabString for the number
            ' of times specified in the Indent property.
            Dim i As Integer
            For i = 0 To Indent - 1
                Write(DefaultTabString)
            Next i
            MyBase.OutputTabs()
        End Sub