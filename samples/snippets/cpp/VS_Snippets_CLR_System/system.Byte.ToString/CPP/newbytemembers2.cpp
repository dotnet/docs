// Byte.ToString2.cpp : main project file.

using namespace System;
using namespace System::Globalization;

// Byte.ToString()
void Byte1()
{
   // <Snippet2>
   array<Byte>^ bytes = gcnew array<Byte> {0, 1, 14, 168, 255};
   for each (Byte byteValue in bytes)
      Console::WriteLine(byteValue);
   // The example displays the following output to the console if the current
   // culture is en-US:
   //       0
   //       1
   //       14
   //       168
   //       255
   // </Snippet2>
}

// Byte.ToString(String)
void Byte2()
{
   // <Snippet4>
   array<String^>^ formats = gcnew array<String^> {"C3", "D4", "e1", "E2", "F1", "G", "N1", 
                                                   "P0", "X4", "0000.0000"};
   Byte number = 240;
   for each (String^ format in formats)
      Console::WriteLine("'{0}' format specifier: {1}", 
                        format, number.ToString(format));

   // The example displays the following output to the console if the
   // current culture is en-us:
   //       'C3' format specifier: $240.000
   //       'D4' format specifier: 0240
   //       'e1' format specifier: 2.4e+002
   //       'E2' format specifier: 2.40E+002
   //       'F1' format specifier: 240.0
   //       'G' format specifier: 240
   //       'N1' format specifier: 240.0
   //       'P0' format specifier: 24,000 %
   //       'X4' format specifier: 00F0
   //       '0000.0000' format specifier: 0240.0000           
   // </Snippet4>
}

// ToString(String, IFormatProvider)
void Byte3()
{
   // <Snippet5>
   Byte byteValue = 250;
   array<CultureInfo^>^ providers = gcnew array<CultureInfo^> { gcnew CultureInfo("en-us"), 
                                                                gcnew CultureInfo("fr-fr"), 
                                                                gcnew CultureInfo("es-es"), 
                                                                gcnew CultureInfo("de-de")}; 

   for each (CultureInfo^ provider in providers) 
      Console::WriteLine("{0} ({1})", 
                        byteValue.ToString("N2", provider), provider->Name);
   // The example displays the following output to the console:
   //       250.00 (en-US)
   //       250,00 (fr-FR)
   //       250,00 (es-ES)
   //       250,00 (de-DE)  
   // </Snippet5>    
}

void main()
{
   Byte1();
   Console::WriteLine();
   Byte2();
   Console::WriteLine();
   Byte3();
   Console::WriteLine();
   Console::ReadLine();
}
