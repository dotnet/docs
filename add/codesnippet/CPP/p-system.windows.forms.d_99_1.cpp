   // The specified IDesigner implements IUIService.
   System::Drawing::Font^ GetFont( IDesigner^ designer )
   {
      System::Drawing::Font^ hostfont;
      
      // Gets the dialog box font from the host environment.
      hostfont = dynamic_cast<System::Drawing::Font^>(dynamic_cast<IUIService^>(designer)->Styles[ "DialogFont" ]);
      return hostfont;
   }