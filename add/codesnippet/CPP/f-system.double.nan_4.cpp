   Double zero = 0;
   
   // This condition will return false.
   if ( (0 / zero) == Double::NaN )
   {
      Console::WriteLine( "0 / 0 can be tested with Double::NaN." );
   }
   else
   {
      Console::WriteLine( "0 / 0 cannot be tested with Double::NaN; use Double::IsNan() instead." );
   }