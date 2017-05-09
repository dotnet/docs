// FormatExample2.cpp : Defines the entry point for the console application.
//

// #include "stdafx.h"

// <Snippet2>
using namespace System;

ref class CustomerFormatter : IFormatProvider, ICustomFormatter
{
public:
   virtual Object^ GetFormat(Type^ formatType) 
   {
      if (formatType == ICustomFormatter::typeid)        
         return this; 
      else 
         return nullptr; 
   }
   
   virtual String^ Format(String^ format, 
	               Object^ arg, 
	               IFormatProvider^ formatProvider) 
   {                       
      if (! this->Equals(formatProvider))
      {
         return nullptr;
      }
      else
      {
         if (String::IsNullOrEmpty(format)) 
            format = "G";
         
         String^ customerString = arg->ToString();
         if (customerString->Length < 8)
            customerString = customerString->PadLeft(8, '0');
         
         format = format->ToUpper();
         if (format == L"G") 
               return customerString->Substring(0, 1) + "-" +
                                     customerString->Substring(1, 5) + "-" +
                                     customerString->Substring(6);
         else if (format == L"S")                          
               return customerString->Substring(0, 1) + "/" +
                                     customerString->Substring(1, 5) + "/" +
                                     customerString->Substring(6);
         else if (format == L"P")
               return customerString->Substring(0, 1) + "." +
                                     customerString->Substring(1, 5) + "." +
                                     customerString->Substring(6);
         else
               throw gcnew FormatException( 
                         String::Format("The '{0}' format specifier is not supported.", format));
         }
    }   
};

void main()
{
   int acctNumber = 79203159;
   Console::WriteLine(String::Format(gcnew CustomerFormatter, "{0}", acctNumber));
   Console::WriteLine(String::Format(gcnew CustomerFormatter, "{0:G}", acctNumber));
   Console::WriteLine(String::Format(gcnew CustomerFormatter, "{0:S}", acctNumber));
   Console::WriteLine(String::Format(gcnew CustomerFormatter, "{0:P}", acctNumber));
   try {
      Console::WriteLine(String::Format(gcnew CustomerFormatter, "{0:X}", acctNumber));
   }
   catch (FormatException^ e) {
      Console::WriteLine(e->Message);
   }
}
// The example displays the following output:
//       7-92031-59
//       7-92031-59
//       7/92031/59
//       7.92031.59
//       The 'X' format specifier is not supported.
// </Snippet2>
