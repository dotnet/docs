public:
   void InitializeMyToolBar()
   {
      // Create and initialize the ToolBar and ToolBarButton controls.
      toolBar1 = gcnew ToolBar;
      ToolBarButton^ toolBarButton1 = gcnew ToolBarButton;
      ToolBarButton^ toolBarButton2 = gcnew ToolBarButton;
      ToolBarButton^ toolBarButton3 = gcnew ToolBarButton;
      
      // Set the Text properties of the ToolBarButton controls.
      toolBarButton1->Text = "Open";
      toolBarButton2->Text = "Save";
      toolBarButton3->Text = "Print";
      
      // Add the ToolBarButton controls to the ToolBar.
      toolBar1->Buttons->Add( toolBarButton1 );
      toolBar1->Buttons->Add( toolBarButton2 );
      toolBar1->Buttons->Add( toolBarButton3 );
      
      // Add the event-handler delegate.
      toolBar1->ButtonClick += gcnew ToolBarButtonClickEventHandler(
         this, &Form1::toolBar1_ButtonClick );
      
      // Add the ToolBar to the Form.
      Controls->Add( toolBar1 );
   }

private:
   void toolBar1_ButtonClick(
      Object^ sender,
      ToolBarButtonClickEventArgs^ e )
   {
      // Evaluate the Button property to determine which button was clicked.
      switch ( toolBar1->Buttons->IndexOf( e->Button ) )
      {
         case 0:
            openFileDialog1->ShowDialog();
            // Insert code to open the file.
            break;
         case 1:
            saveFileDialog1->ShowDialog();
            // Insert code to save the file.
            break;
         case 2:
            printDialog1->ShowDialog();
            // Insert code to print the file.    
            break;
      }
   }