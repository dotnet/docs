   void PrintPropertyDescriptions( BindingManagerBase^ b )
   {
      Console::WriteLine( "Printing Property Descriptions" );
      PropertyDescriptorCollection^ ps = b->GetItemProperties();
      for ( int i = 0; i < ps->Count; i++ )
      {
         Console::WriteLine( "\t{0}\t{1}", ps[ i ]->Name, ps[ i ]->PropertyType );

      }
   }
