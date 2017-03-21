         // The sample first constructs a CultureInfo variable using the Greek culture - 'el'.
         System::Globalization::CultureInfo^ myCulture = gcnew System::Globalization::CultureInfo( "el" );
         String^ myCString = "Russian";
         Console::WriteLine( TypeDescriptor::GetConverter( myCulture )->ConvertTo( myCulture, String::typeid ) );
         // The following line will output 'ru' based on the string being converted.
         Console::WriteLine( TypeDescriptor::GetConverter( myCulture )->ConvertFrom( myCString ) );