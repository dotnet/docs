// <Snippet3>
using namespace System;
using namespace System::Globalization;

public ref class ParseInt32
{
public:
   static void Main()
   {
      Convert("12,000", NumberStyles::Float | NumberStyles::AllowThousands, 
              gcnew CultureInfo("en-GB"));
      Convert("12,000", NumberStyles::Float | NumberStyles::AllowThousands,
              gcnew CultureInfo("fr-FR"));
      Convert("12,000", NumberStyles::Float, gcnew CultureInfo("en-US"));

      Convert("12 425,00", NumberStyles::Float | NumberStyles::AllowThousands,
              gcnew CultureInfo("sv-SE"));
      Convert("12,425.00", NumberStyles::Float | NumberStyles::AllowThousands,
              NumberFormatInfo::InvariantInfo);
      Convert("631,900", NumberStyles::Integer | NumberStyles::AllowDecimalPoint, 
              gcnew CultureInfo("fr-FR"));
      Convert("631,900", NumberStyles::Integer | NumberStyles::AllowDecimalPoint,
              gcnew CultureInfo("en-US"));
      Convert("631,900", NumberStyles::Integer | NumberStyles::AllowThousands,
              gcnew CultureInfo("en-US"));
   }

private:
   static void Convert(String^ value, NumberStyles style,
                               IFormatProvider^ provider)
   {
      try
      {
         int number = Int32::Parse(value, style, provider);
         Console::WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException^)
      {
         Console::WriteLine("Unable to convert '{0}'.", value);
      }
      catch (OverflowException^)
      {
         Console::WriteLine("'{0}' is out of range of the Int32 type.", value);   
      }
   }                               
};

int main()
{
    ParseInt32::Main();
}
// This example displays the following output to the console:
//       Converted '12,000' to 12000.
//       Converted '12,000' to 12.
//       Unable to convert '12,000'.
//       Converted '12 425,00' to 12425.
//       Converted '12,425.00' to 12425.
//       '631,900' is out of range of the Int32 type.
//       Unable to convert '631,900'.
//       Converted '631,900' to 631900.
// </Snippet3>
