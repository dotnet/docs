public:
   property MyPropertyEnum MyProperty 
   {
      void set( MyPropertyEnum value )
      {
         // Checks to see if the value passed is valid.
         if ( !TypeDescriptor::GetConverter( MyPropertyEnum::typeid )->IsValid( value ) )
         {
            throw gcnew ArgumentException;
         }
         // The value is valid. Insert code to set the property.
      }
   }