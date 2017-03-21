   NumberStyles style;
   CultureInfo^ culture;
   String^ value;
   Byte number;

   // Parse number with decimals.
   // NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
   style = NumberStyles::Float;     
   culture = CultureInfo::CreateSpecificCulture("fr-FR");
   value = "12,000";

   number = Byte::Parse(value, style, culture);
   Console::WriteLine("Converted '{0}' to {1}.", value, number);

   culture = CultureInfo::CreateSpecificCulture("en-GB");
   try
   {
      number = Byte::Parse(value, style, culture);
      Console::WriteLine("Converted '{0}' to {1}.", value, number);
   }
   catch (FormatException^) {
      Console::WriteLine("Unable to parse '{0}'.", value); }   

   value = "12.000";
   number = Byte::Parse(value, style, culture);
   Console::WriteLine("Converted '{0}' to {1}.", value, number);
   // The example displays the following output to the console:
   //       Converted '12,000' to 12.
   //       Unable to parse '12,000'.
   //       Converted '12.000' to 12.