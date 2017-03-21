   protected:
      // This method override returns an type array containing the type of 
      // each component editor page to display.
      virtual array<Type^>^ GetComponentEditorPages() override
      {
         array<Type^>^temp0 = {ExampleComponentEditorPage::typeid,ExampleComponentEditorPage::typeid};
         return temp0;
      }