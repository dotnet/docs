// Parse1.cpp : main project file.
// Code example for Int16.Parse(String)

using namespace System;

int main(array<System::String ^> ^args)
{
   // <Snippet1>
   String^ value;
   Int16 number;
      
   value = " 12603 ";
   try
   {
      number = Int16::Parse(value);
      Console::WriteLine("Converted '{0}' to {1}.", value, number);
   }
   catch (FormatException ^e)
   {
      Console::WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                         value);
   }
      
   value = " 16,054";
   try
   {
      number = Int16::Parse(value);
      Console::WriteLine("Converted '{0}' to {1}.", value, number);
   }
   catch (FormatException ^e)
   {
      Console::WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                        value);
   }
                              
   value = " -17264";
   try
   {
      number = Int16::Parse(value);
      Console::WriteLine("Converted '{0}' to {1}.", value, number);
   }
   catch (FormatException ^e)
   {
      Console::WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                         value);
   }
   // The example displays the following output to the console:
   //       Converted ' 12603 ' to 12603.
   //       Unable to convert ' 16,054' to a 16-bit signed integer.
   //       Converted ' -17264' to -17264.      
   // </Snippet1>
   Console::ReadLine(); 
   return 0;
}
