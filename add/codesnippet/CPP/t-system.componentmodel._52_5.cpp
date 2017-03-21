      for each ( Color c in TypeDescriptor::GetConverter( Color::typeid )->GetStandardValues() )
      {
         Console::WriteLine( TypeDescriptor::GetConverter( c )->ConvertToString( c ) );
      }