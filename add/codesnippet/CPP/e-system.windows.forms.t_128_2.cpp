private:
   // Handle the After_Select event.
   void TreeView1_AfterSelect( System::Object^ /*sender*/, System::Windows::Forms::TreeViewEventArgs^ e )
   {
      
      // Vary the response depending on which TreeViewAction
      // triggered the event. 
      switch ( (e->Action) )
      {
         case TreeViewAction::ByKeyboard:
            MessageBox::Show( "You like the keyboard!" );
            break;

         case TreeViewAction::ByMouse:
            MessageBox::Show( "You like the mouse!" );
            break;
      }
   }