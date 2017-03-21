            // Creates a TextWriter to use as the base output writer.
            System.IO.StringWriter baseTextWriter = new System.IO.StringWriter();            

            // Create an IndentedTextWriter and set the tab string to use 
            // as the indentation string for each indentation level.
            System.CodeDom.Compiler.IndentedTextWriter indentWriter = new IndentedTextWriter(baseTextWriter, "    ");           