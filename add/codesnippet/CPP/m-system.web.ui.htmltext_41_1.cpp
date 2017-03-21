      // If an <anchor> element is rendered and an href
      // attribute has not been defined, call the AddAttribute
      // method to add an href attribute
      // and set it to http://www.cohowinery.com.
      // Use the EncodeUrl method to convert any spaces to %20.
      if ( TagKey == HtmlTextWriterTag::A )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Href ) )
         {
            AddAttribute( "href", EncodeUrl( "http://www.cohowinery.com" ) );
         }
      }