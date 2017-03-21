   // Override the FilterAttributes method to check whether 
   // <label> and <anchor> elements contain specific attributes. 
   virtual void FilterAttributes() override
   {
      // If the <label> element is rendered and a style
      // attribute is not defined, add a style attribute 
      // and set its value to blue.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Style ) )
         {
            AddAttribute( "style", EncodeAttributeValue( "color:blue", true ) );
            Write( NewLine );
            Indent = 3;
            OutputTabs();
         }
      }

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

      // Call the FilterAttributes method of the base class.
      __super::FilterAttributes();
   }