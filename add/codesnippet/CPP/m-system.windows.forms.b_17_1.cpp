   void BindControls()
   {
      System::Windows::Forms::BindingContext^ bcG1 = gcnew System::Windows::Forms::BindingContext;
      System::Windows::Forms::BindingContext^ bcG2 = gcnew System::Windows::Forms::BindingContext;
      groupBox1->BindingContext = bcG1;
      groupBox2->BindingContext = bcG2;
      textBox1->DataBindings->Add( "Text", ds, "Customers.CustName" );
      textBox2->DataBindings->Add( "Text", ds, "Customers.CustName" );
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      groupBox1->BindingContext[ds, "Customers"]->Position = groupBox1->BindingContext[ds, "Customers"]->Position + 1;
   }

   void Button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      groupBox2->BindingContext[ds, "Customers"]->Position = groupBox2->BindingContext[ds, "Customers"]->Position + 1;
   }
