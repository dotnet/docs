   public ref class MyDataGrid: public DataGrid
   {
   protected:

      // Override the OnMouseDown event to select the whole row
      // when the user clicks anywhere on a row.
      virtual void OnMouseDown( MouseEventArgs^ e ) override
      {
         
         // Get the HitTestInfo to return the row and pass
         // that value to the IsSelected property of the DataGrid.
         DataGrid::HitTestInfo ^ hit = this->HitTest( e->X, e->Y );
         if ( hit->Row < 0 )
                  return;

         if ( this->IsSelected( hit->Row ) )
                  UnSelect( hit->Row );
         else
                  Select(hit->Row);
      }
   };