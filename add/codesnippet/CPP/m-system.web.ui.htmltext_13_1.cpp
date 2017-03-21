         // Add style attribute for 'p'(paragraph) element.
         writer->AddStyleAttribute( "font-size", "12pt" );
         writer->AddStyleAttribute( "color", "fuchsia" );
         // Output the 'p' (paragraph) element with the style attributes.
         writer->RenderBeginTag( "p" );
         // Output the 'Message' property contents and the time on the server.
         writer->Write( String::Concat( Message, "<br>",
            "The time on the server: ",
            System::DateTime::Now.ToLongTimeString() ) );
         
         // Close the element.
         writer->RenderEndTag();