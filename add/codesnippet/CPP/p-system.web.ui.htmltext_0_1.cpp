      // Write the opening tag of a Font element.
      writer->WriteBeginTag( "font" );
      
      // Write a Color style attribute to the opening tag
      // of the Font element and set its value to red.
      writer->WriteAttribute( "color", "red" );
      
      // Write the closing character for the opening tag of
      // the Font element.
      writer->Write( '>' );
      
      // Use the InnerWriter property to create a TextWriter
      // object that will write the content found between
      // the opening and closing tags of the Font element.
      // Message is a string property of the control that
      // overrides the Render method.
      TextWriter^ innerTextWriter = writer->InnerWriter;
      innerTextWriter->Write( String::Concat( Message, "<br> The time on the server : ", System::DateTime::Now.ToLongTimeString() ) );
      
      // Write the closing tag of the Font element.
      writer->WriteEndTag( "font" );
   }
