private:
   void RegisterEventHandler()
   {
      myButton1->SizeChanged += gcnew EventHandler( this, &MyForm::MyButton1_SizeChanged );
   }

   void MyButton2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Set the scale for the control to the value provided.
      float scale = (float)myNumericUpDown1->Value;
      myButton1->Scale( scale );
   }

   void MyButton1_SizeChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "The size of the 'Button' control has changed" );
   }