      // Creates a TextWriter to use as the base output writer.
      System::IO::StringWriter^ baseTextWriter = gcnew System::IO::StringWriter;
      
      // Create an IndentedTextWriter and set the tab string to use 
      // as the indentation string for each indentation level.
      System::CodeDom::Compiler::IndentedTextWriter^ indentWriter = gcnew IndentedTextWriter( baseTextWriter,"    " );
      