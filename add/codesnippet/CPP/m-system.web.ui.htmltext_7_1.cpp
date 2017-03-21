   // Override the RenderAfterTag method to add the
   // closing tag of the Font element after the
   // closing tag of a Label element has been rendered.
   virtual String^ RenderAfterTag() override
   {
      // Compare the TagName property value to the
      // String* label to determine whether the element to
      // be rendered is a Label. If it is a Label,
      // the closing tag of a Font element is rendered
      // after the closing tag of the Label element.
      if ( String::Compare( TagName, "label" ) == 0 )
      {
         return "</font>";
      }
      // If a Label is not being rendered, use
      // the base RenderAfterTag method.
      else
      {
         return __super::RenderAfterTag();
      }
   }