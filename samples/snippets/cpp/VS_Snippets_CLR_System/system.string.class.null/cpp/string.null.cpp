// String.Null.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

using namespace System;
using namespace System::Globalization;

void main()
{
   String^ str = String::Empty;

   // <Snippet1>
   if (str == nullptr || str->Equals(String::Empty))
   // </Snippet1>
      Console::WriteLine("Empty string");

   str = "   ";
   // <Snippet2>
   if (str == nullptr || str->Equals(String::Empty) || str->Trim()->Equals(String::Empty))
   // </Snippet2>
      Console::WriteLine("Empty string");


   Console::ReadLine();
}

public ref class Temperature  : IFormattable
{
   
private:
   double temp;
   
// <Snippet3>
public:
   virtual String^ ToString(String^ format, IFormatProvider^ provider) 
   {
      if (String::IsNullOrEmpty(format)) format = "G";  
      if (provider == nullptr) provider = CultureInfo::CurrentCulture;
      
      switch (Convert::ToUInt16(format->ToUpperInvariant()))
      {
         // Return degrees in Celsius.    
         case 'G':
         case 'C':
            return temp.ToString("F2", provider) + L"°C";
         // Return degrees in Fahrenheit.
         case 'F': 
            return (temp * 9 / 5 + 32).ToString("F2", provider) + L"°F";
         // Return degrees in Kelvin.
         case 'K':   
            return (temp + 273.15).ToString();
         default:
            throw gcnew FormatException(
                  String::Format("The {0} format string is not supported.", 
                                 format));
      }                                   
   }
// </Snippet3>

   Temperature(double temp) : temp(temp) {}
   
   virtual String^ ToString() override
   {
      return this->ToString("G", CultureInfo::CurrentCulture);
   }
   
   String^ ToString(String^ format)
   {
      return this->ToString(format, CultureInfo::CurrentCulture);
   }
};

