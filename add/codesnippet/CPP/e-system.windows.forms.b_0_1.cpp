   void Current_Changed( Object^ sender, EventArgs^ /*e*/ )
   {
      BindingManagerBase^ bm = dynamic_cast<BindingManagerBase^>(sender);
      
      /* Check the type of the Current object. If it is not a 
              DataRowView, exit the method. */
      if ( bm->Current->GetType() != DataRowView::typeid )
            return;

      // Otherwise, print the value of the column named "CustName".
      DataRowView^ drv = dynamic_cast<DataRowView^>(bm->Current);
      Console::Write( "CurrentChanged): " );
      Console::Write( drv[ "CustName" ] );
      Console::WriteLine();
   }