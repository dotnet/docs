private:
   void ChangeColumnCultureInfo()
   {
      /* Create a new CultureInfo Object* using the
        the locale ID for Italy. */
      System::Globalization::CultureInfo^ ItalyCultureInfo = gcnew CultureInfo( 0x0410 );
      
      /* Cast a column that holds numeric values to the
        DataGridTextBoxColumn type, and set the FormatInfo
        property to the new CultureInfo Object*. */
      DataGridTextBoxColumn^ myGridTextBoxColumn =
         dynamic_cast<DataGridTextBoxColumn^>(myDataGrid->TableStyles[ "Orders" ]->
         GridColumnStyles[ "OrderAmount" ]);
      myGridTextBoxColumn->FormatInfo = ItalyCultureInfo;
      myGridTextBoxColumn->Format = "c";
   }