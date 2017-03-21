      // Create a parent control.
      System::Windows::Forms::Control^ c = gcnew System::Windows::Forms::Control;
      c->CreateControl();
      
      // Launch the Url Builder using the specified control
      // parent, initial URL, empty relative base URL path,
      // window caption, filter String* and URLBuilderOptions value.
      UrlBuilder::BuildUrl( this->Component, c, "http://www.example.com", "Select a URL", "", UrlBuilderOptions::None );
      