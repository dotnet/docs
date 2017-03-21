public:
   void InitializeMyToolBar()
   {
      // Create and initialize the ToolBarButton controls and ToolBar.
      ToolBar^ toolBar1 = gcnew ToolBar;
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
      
      // Add the ToolBar to the Form.
      Controls->Add( toolBar1 );
   }