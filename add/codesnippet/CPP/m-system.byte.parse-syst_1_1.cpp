   String^ value;
   NumberStyles style;
   Byte number;

   // Parse value with no styles allowed.
   style = NumberStyles::None;
   value = " 241 ";
   try
   {
      number = Byte::Parse(value, style);
      Console::WriteLine("Converted '{0}' to {1}.", value, number);
   }
   catch (FormatException^) {
      Console::WriteLine("Unable to parse '{0}'.", value); }   

   // Parse value with trailing sign.
   style = NumberStyles::Integer | NumberStyles::AllowTrailingSign;
   value = " 163+";
   number = Byte::Parse(value, style);
   Console::WriteLine("Converted '{0}' to {1}.", value, number);

   // Parse value with leading sign.
   value = "   +253  ";
   number = Byte::Parse(value, style);
   Console::WriteLine("Converted '{0}' to {1}.", value, number);
   // This example displays the following output to the console:
   //       Unable to parse ' 241 '.
   //       Converted ' 163+' to 163.
   //       Converted '   +253  ' to 253.