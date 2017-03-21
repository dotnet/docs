private:
   delegate void MyDelegate(
   Label^ myControl, String^ myArg2 );
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      array<Object^>^myArray = gcnew array<Object^>(2);
      myArray[ 0 ] = gcnew Label;
      myArray[ 1 ] = "Enter a Value";
      myTextBox->BeginInvoke( gcnew MyDelegate( this, &MyForm::DelegateMethod ), myArray );
   }

   void DelegateMethod( Label^ myControl, String^ myCaption )
   {
      myControl->Location = Point(16,16);
      myControl->Size = System::Drawing::Size( 80, 25 );
      myControl->Text = myCaption;
      this->Controls->Add( myControl );
   }

   delegate void InvokeDelegate();