   // Override the RenderBeginTag method to check whether
   // the tagKey parameter is set to a <label> element
   // or a <font> element.   
   virtual void RenderBeginTag( HtmlTextWriterTag tagKey ) override
   {
      // If the tagKey parameter is set to a <label> element
      // but a color attribute is not defined on the element,
      // the AddStyleAttribute method adds a color attribute
      // and sets it to red.
      if ( tagKey == HtmlTextWriterTag::Label )
      {
         if (  !IsStyleAttributeDefined( HtmlTextWriterStyle::Color ) )
         {
            AddStyleAttribute( GetStyleKey( "color" ), "red" );
         }
      }

      // If the tagKey parameter is set to a <font> element
      // but a size attribute is not defined on the element,
      // the AddStyleAttribute method adds a size attribute
      // and sets it to 30 point.
      if ( tagKey == HtmlTextWriterTag::Font )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Size ) )
         {
            AddAttribute( GetAttributeKey( "size" ), "30pt" );
         }
      }

      // Call the base class's RenderBeginTag method
      // to ensure that calling this custom markup writer
      // includes functionality for all other elements.
      __super::RenderBeginTag( tagKey );
   }