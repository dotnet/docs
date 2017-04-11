// Parse3.cpp : main project file.

using namespace System;
using namespace System::Globalization;

int main(array<System::String ^> ^args)
{
      // <Snippet3>
      String^ value;
      Int16 number;
      NumberStyles style;
      
      // Parse string using "." as the thousands separator 
      // and " " as the decimal separator.
      value = "19 694,00";
      style = NumberStyles::AllowDecimalPoint | NumberStyles::AllowThousands;
      CultureInfo^ provider = gcnew CultureInfo("fr-FR");
      
      number = Int16::Parse(value, style, provider);
      Console::WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '19 694,00' converted to 19694.

      try
      {
         number = Int16::Parse(value, style, CultureInfo::InvariantCulture);
         Console::WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException ^e)
      {
         Console::WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '19 694,00'.
      
      // Parse string using "$" as the currency symbol for en_GB and
      // en-US cultures.
      value = "$6,032.00";
      style = NumberStyles::Number | NumberStyles::AllowCurrencySymbol;
      provider = gcnew CultureInfo("en-GB");
      
      try
      {
         number = Int16::Parse(value, style, CultureInfo::InvariantCulture);
         Console::WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException ^e)
      {
         Console::WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '$6,032.00'.
                              
      provider = gcnew CultureInfo("en-US");
      number = Int16::Parse(value, style, provider);
      Console::WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '$6,032.00' converted to 6032.      
      // </Snippet3>
    Console::ReadLine();
    return 0;
}
