   // Create a new ToolboxItemCollection using a ToolboxItem array.
   array<ToolboxItem^>^temp0 = {gcnew ToolboxItem( System::Windows::Forms::Label::typeid ),gcnew ToolboxItem( System::Windows::Forms::TextBox::typeid )};
   ToolboxItemCollection^ collection = gcnew ToolboxItemCollection( temp0 );