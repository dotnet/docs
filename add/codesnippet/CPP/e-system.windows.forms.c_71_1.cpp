   // This example demonstrates the use of the ControlAdded and
   // ControlRemoved events. This example assumes that two Button controls
   // are added to the form and connected to the addControl_Click and
   // removeControl_Click event-handler methods.
private:
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Connect the ControlRemoved and ControlAdded event handlers
      // to the event-handler methods.
      // ControlRemoved and ControlAdded are not available at design time.
      this->ControlRemoved += gcnew System::Windows::Forms::ControlEventHandler( this, &Form1::Control_Removed );
      this->ControlAdded += gcnew System::Windows::Forms::ControlEventHandler( this, &Form1::Control_Added );
   }

   void Control_Added( Object^ /*sender*/, System::Windows::Forms::ControlEventArgs^ e )
   {
      MessageBox::Show( String::Format( "The control named {0} has been added to the form.", e->Control->Name ) );
   }

   void Control_Removed( Object^ /*sender*/, System::Windows::Forms::ControlEventArgs^ e )
   {
      MessageBox::Show( String::Format( "The control named {0} has been removed from the form.", e->Control->Name ) );
   }

   // Click event handler for a Button control. Adds a TextBox to the form.
   void addControl_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create a new TextBox control and add it to the form.
      TextBox^ textBox1 = gcnew TextBox;
      textBox1->Size = System::Drawing::Size( 100, 10 );
      textBox1->Location = Point(10,10);

      // Name the control in order to remove it later. The name must be specified
      // if a control is added at run time.
      textBox1->Name = "textBox1";

      // Add the control to the form's control collection.
      this->Controls->Add( textBox1 );
   }

   // Click event handler for a Button control.
   // Removes the previously added TextBox from the form.
   void removeControl_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Loop through all controls in the form's control collection.
      IEnumerator^ myEnum = this->Controls->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Control^ tempCtrl = safe_cast<Control^>(myEnum->Current);
         
         // Determine whether the control is textBox1,
         // and if it is, remove it.
         if ( tempCtrl->Name->Equals( "textBox1" ) )
         {
            this->Controls->Remove( tempCtrl );
         }
      }
   }