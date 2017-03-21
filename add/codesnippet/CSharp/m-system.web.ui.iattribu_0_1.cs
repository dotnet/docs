      // Implement the SetAttribute method for the control. When
      // this method is called from a page, the control's properties
      // are set to values defined in the page.
      public void SetAttribute(String name, String value1)
      {
         ViewState[name] = value1;
      }