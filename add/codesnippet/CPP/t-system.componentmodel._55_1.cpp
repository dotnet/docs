         String^ strM = "1,2,3,4";
         System::Drawing::Printing::Margins^ m = gcnew System::Drawing::Printing::Margins( 1,2,3,4 );
         Console::WriteLine( TypeDescriptor::GetConverter( strM )->CanConvertTo( System::Drawing::Printing::Margins::typeid ) );
         Console::WriteLine( TypeDescriptor::GetConverter( m )->ConvertToString( m ) );