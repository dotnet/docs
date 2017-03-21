   // Override the RenderBeforeTag method to add the
   // opening tag of a Font element before the
   // opening tag of any Label elements rendered by this
   // custom markup writer.
   virtual String^ RenderBeforeTag() override
   {
      // Compare the TagName property value to the
      // String* label to determine whether the element to
      // be rendered is a Label. If it is a Label,
      // the opening tag of the Font element, with a Color
      // style attribute set to red, is added before
      // the Label.
      if ( String::Compare( TagName, "label" ) == 0 )
      {
         return "<font color=\"red\">";
      }
      // If a Label is not being rendered, use
      // the base RenderBeforeTag method.
      else
      {
         return __super::RenderBeforeTag();
      }
   }