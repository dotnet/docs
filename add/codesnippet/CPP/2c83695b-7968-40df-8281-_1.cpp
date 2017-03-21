public:
   void AddMyButton()
   {
      ToolBarButton^ toolBarButton1 = gcnew ToolBarButton;
      toolBarButton1->Text = "Print";
      
      // Add the new toolbar button to the toolbar.
      toolBar1->Buttons->Add( toolBarButton1 );
   }