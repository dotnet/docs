   System::Windows::Forms::TreeView^ TreeView2;

   // Initialize the TreeView to blend with the form, giving it the 
   // same color as the form and no border.
   void InitializeSelectedTreeView()
   {
      
      // Create a new TreeView control and set the location and size.
      this->TreeView2 = gcnew System::Windows::Forms::TreeView;
      this->TreeView2->Location = System::Drawing::Point( 72, 48 );
      this->TreeView2->Size = System::Drawing::Size( 200, 200 );
      this->TreeView2->BorderStyle = BorderStyle::Fixed3D;
      
      // Set the HideSelection property to false to keep the 
      // selection highlighted when the user leaves the control. 
      this->TreeView1->HideSelection = false;
      
      // Add the nodes.
      array<TreeNode^>^temp0 = {gcnew TreeNode( "Full Color" ),gcnew TreeNode( "Project Wizards" ),gcnew TreeNode( "Visual C# and Visual Basic Support" )};
      array<TreeNode^>^temp1 = {gcnew TreeNode( "Pentium 133 MHz or faster processor " ),gcnew TreeNode( "Windows 98 or later" ),gcnew TreeNode( "100 MB Disk space" )};
      array<TreeNode^>^temp2 = {gcnew TreeNode( "Features",temp0 ),gcnew TreeNode( "System Requirements",temp1 )};
      this->TreeView1->Nodes->AddRange( temp2 );
      
      // Set the tab index and add the TreeView to the form.
      this->TreeView1->TabIndex = 0;
      this->Controls->Add( this->TreeView1 );
   }
