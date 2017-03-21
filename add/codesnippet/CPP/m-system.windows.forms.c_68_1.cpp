private:
   void Invoke_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myTextBox->BeginInvoke( gcnew InvokeDelegate( this, &MyForm::InvokeMethod ) );
   }

   void InvokeMethod()
   {
      myTextBox->Text = "Executed the given delegate";
   }