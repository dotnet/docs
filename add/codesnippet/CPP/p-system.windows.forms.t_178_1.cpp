   ToolStripControlHost^ dateTimePickerHost;
   void InitializeDateTimePickerHost()
   {
      // Create a new ToolStripControlHost, passing in a control.
      dateTimePickerHost = gcnew ToolStripControlHost( gcnew DateTimePicker );
      
      // Set the font on the ToolStripControlHost, this will affect the hosted control.
      dateTimePickerHost->Font =
         gcnew System::Drawing::Font( L"Arial",7.0F,FontStyle::Italic );
      
      // Set the Width property, this will also affect the hosted control.
      dateTimePickerHost->Width = 100;
      dateTimePickerHost->DisplayStyle = ToolStripItemDisplayStyle::Text;
      
      // Setting the Text property requires a string that converts to a
      // DateTime type since that is what the hosted control requires.
      dateTimePickerHost->Text = L"12/23/2005";
      
      // Cast the Control property back to the original type to set a
      // type-specific property.
      (dynamic_cast<DateTimePicker^>(dateTimePickerHost->Control))->Format =
         DateTimePickerFormat::Short;
      
      // Add the control host to the ToolStrip.
      toolStrip1->Items->Add( dateTimePickerHost );
   }