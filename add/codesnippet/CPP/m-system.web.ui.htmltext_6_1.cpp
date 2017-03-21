   // Override the RenderAfterContent method to render
   // the closing tag of a font element if the
   // rendered tag is a label element.

   virtual String^ RenderAfterContent() override
   {
      
      // Check to determine whether the element being rendered
      // is a label element. If so, render the closing tag
      // of the font element; otherwise, call the base method.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         return "</font>";
      }
      else
      {
         return __super::RenderAfterContent();
      }
   }
