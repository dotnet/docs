   // Initialize a single-panel status bar.  This is done
   // by setting the Text property and setting ShowPanels to False.
private:
   void InitializeSimpleStatusBar()
   {
      
      // Declare the StatusBar control
      StatusBar^ simpleStatusBar = gcnew StatusBar;
      
      // Set the ShowPanels property to False.
      simpleStatusBar->ShowPanels = false;
      
      // Set the text.
      simpleStatusBar->Text = "This is a single-panel status bar";
      
      // Set the width and anchor the StatusBar
      simpleStatusBar->Width = 200;
      simpleStatusBar->Anchor = AnchorStyles::Top;
      
      // Add the StatusBar to the form.
      this->Controls->Add( simpleStatusBar );
   }