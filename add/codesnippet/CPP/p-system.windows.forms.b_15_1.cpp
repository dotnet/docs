   void PrintBindingInfo()
   {
      BindingsCollection^ bc = text1->DataBindings;
      for ( int i = 0; i < bc->Count; i++ )
         Console::WriteLine( bc[ i ]->BindingMemberInfo.BindingMember );
   }
