private:
   void AddEventHandler()
   {
      textBox1->BindingContextChanged += gcnew EventHandler(
         this, &Form1::BindingContext_Changed );
   }

   void BindingContext_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Console::WriteLine( "BindingContext changed" );
   }