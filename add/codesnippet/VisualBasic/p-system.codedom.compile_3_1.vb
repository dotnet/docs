        ' Create a TextWriter to use as the base output writer.
        Dim baseTextWriter As New System.IO.StringWriter
      
        ' Create an IndentedTextWriter and set the tab string to use 
        ' as the indentation string for each indentation level.
        Dim indentWriter = New IndentedTextWriter(baseTextWriter, "    ")