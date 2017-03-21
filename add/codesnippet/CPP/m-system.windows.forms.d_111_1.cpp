private:
   void dataGrid1_CurrentCellChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Rectangle rect;
      rect = dataGrid1->GetCurrentCellBounds();
      Console::WriteLine( rect );
   }