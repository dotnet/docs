// Parse4.cpp : main project file.

using namespace System;
using namespace System::Globalization;

int main(array<System::String ^> ^args)
{
      // <Snippet4>      
      String^ stringToConvert;
      Int16 number;
      
      stringToConvert = " 214 ";
      try
      {
         number = Int16::Parse(stringToConvert, CultureInfo::InvariantCulture);
         Console::WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException ^e)
      {
         Console::WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException ^e)
      {
         Console::WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " + 214";                     
      try
      {
         number = Int16::Parse(stringToConvert, CultureInfo::InvariantCulture);
         Console::WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException ^e)
      {
         Console::WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException ^e)
      {
         Console::WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " +214 "; 
      try
      {
         number = Int16::Parse(stringToConvert, CultureInfo::InvariantCulture);
         Console::WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException ^e)
      {
         Console::WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException ^e)
      {
         Console::WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      // The example displays the following output to the console:
      //       Converted ' 214 ' to 214.
      //       Unable to parse ' + 214'.
      //       Converted ' +214 ' to 214.
      // </Snippet4>
      Console::ReadLine();
      return 0;
}
