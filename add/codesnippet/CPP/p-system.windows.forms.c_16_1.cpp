private:
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to string type. 
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }

      cevent->Value = ( (Decimal^)(cevent->Value) )->ToString( "c" );
   }

   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to decimal type.
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }

      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }