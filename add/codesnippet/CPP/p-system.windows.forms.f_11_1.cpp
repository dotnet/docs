private:
   void ShowMyDialogBox()
   {
      Form^ myForm = gcnew Form;
      myForm->Text = "My Form";
      myForm->SetBounds( 20, 20, 300, 300 );
      myForm->FormBorderStyle = ::FormBorderStyle::FixedDialog;

      // Display the form with no grip since form is not resizable.
      myForm->SizeGripStyle = ::SizeGripStyle::Hide;
      myForm->MinimizeBox = false;
      myForm->MaximizeBox = false;
      myForm->ShowDialog();
   }