private:
   void ShowInTaskBarEx()
   {
      Form^ myForm = gcnew Form;
      myForm->Text = "My Form";
      myForm->SetBounds( 10, 10, 200, 200 );
      myForm->FormBorderStyle = ::FormBorderStyle::FixedDialog;
      myForm->MinimizeBox = false;
      myForm->MaximizeBox = false;

      // Do not allow form to be displayed in taskbar.
      myForm->ShowInTaskbar = false;
      myForm->ShowDialog();
   }