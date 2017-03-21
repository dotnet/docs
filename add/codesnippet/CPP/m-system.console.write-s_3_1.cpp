int main()
{
   array<String^>^lineInputArr = {"1   2.2   hello	TRUE","2   5.22   bye	FALSE","3   6.38   see ya'	TRUE"};
   for ( Int32 i = 0; i < 3; i++ )
   {
      String^ lineInput = lineInputArr->GetValue( i )->ToString();
      String^ aChar =  "\t";
      array<String^>^fields = lineInput->Split( aChar->ToCharArray() );
      Boolean isFirstField = true;
      for ( Int32 i = 0; i < fields->Length; i++ )
      {
         if ( isFirstField )
                  isFirstField = false;
         else
                  Console::Write( "," );
         
         // If the field represents a boolean, replace with a numeric representation.
         try
         {
            Console::Write( Convert::ToByte( Convert::ToBoolean( fields[ i ] ) ) );
         }
         catch ( FormatException^ ) 
         {
            Console::Write( fields[ i ] );
         }


      }
      Console::WriteLine();

   }
}
