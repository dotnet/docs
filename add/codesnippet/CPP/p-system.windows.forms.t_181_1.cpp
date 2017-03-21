   void AddToolBar()
   {
      
      // Add a toolbar and set some of its properties.
      toolBar1 = gcnew ToolBar;
      toolBar1->Appearance = System::Windows::Forms::ToolBarAppearance::Flat;
      toolBar1->BorderStyle = System::Windows::Forms::BorderStyle::None;
      toolBar1->Buttons->Add( this->toolBarButton1 );
      toolBar1->ButtonSize = System::Drawing::Size( 24, 24 );
      toolBar1->Divider = true;
      toolBar1->DropDownArrows = true;
      toolBar1->ImageList = this->imageList1;
      toolBar1->ShowToolTips = true;
      toolBar1->Size = System::Drawing::Size( 292, 25 );
      toolBar1->TabIndex = 0;
      toolBar1->TextAlign = System::Windows::Forms::ToolBarTextAlign::Right;
      toolBar1->Wrappable = false;
      
      // Add handlers for the ButtonClick and ButtonDropDown events.
      toolBar1->ButtonDropDown += gcnew ToolBarButtonClickEventHandler( this, &MyToolBar::toolBar1_ButtonDropDown );
      toolBar1->ButtonClick += gcnew ToolBarButtonClickEventHandler( this, &MyToolBar::toolBar1_ButtonClicked );
      
      // Add the toolbar to the form.
      this->Controls->Add( toolBar1 );
   }