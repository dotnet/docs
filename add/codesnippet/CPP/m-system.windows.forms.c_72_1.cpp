   void button3_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         BindingManagerBase^ myBindingManager1 = BindingContext[ myDataSet, "Customers" ];
         myBindingManager1->SuspendBinding();
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Source );
         MessageBox::Show( ex->Message );
      }
   }