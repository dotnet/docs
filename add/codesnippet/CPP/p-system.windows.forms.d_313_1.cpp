private:
   void dataGrid1_MouseDown( Object^ /*sender*/,
      System::Windows::Forms::MouseEventArgs^ e )
   {
      String^ newLine = "\n";
      Console::WriteLine( newLine );
      System::Windows::Forms::DataGrid::HitTestInfo^ myHitTest;
      // Use the DataGrid control's HitTest method with the x and y properties.
      myHitTest = dataGrid1->HitTest( e->X, e->Y );
      Console::WriteLine( "Column {0}", myHitTest->Column );
      Console::WriteLine( "Row {0}", myHitTest->Row );
   }