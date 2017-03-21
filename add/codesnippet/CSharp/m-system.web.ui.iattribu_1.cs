      // Implement the GetAttribute method for the control. When
      // this method is called from a page, the values for the control's
      // properties can be displayed in the page.
      public String GetAttribute(String name)
      {
         return (String)ViewState[name];
      }