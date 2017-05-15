// Byte.ToString.cpp : main project file.

using namespace System;
using namespace System::Globalization;

void main()
{
   // <Snippet3>
   array<Byte>^ bytes = gcnew array<Byte> {0, 1, 14, 168, 255};
   array<CultureInfo^>^ providers = {gcnew CultureInfo("en-us"), 
                                     gcnew CultureInfo("fr-fr"), 
                                     gcnew CultureInfo("de-de"), 
                                     gcnew CultureInfo("es-es")};
   for each (Byte byteValue in bytes)
   {
      for each (CultureInfo^ provider in providers)
         Console::Write("{0,3} ({1})      ", 
                       byteValue.ToString(provider), provider->Name);

      Console::WriteLine();                                        
   }
   // The example displays the following output to the console:
   //      0 (en-US)        0 (fr-FR)        0 (de-DE)        0 (es-ES)
   //      1 (en-US)        1 (fr-FR)        1 (de-DE)        1 (es-ES)
   //     14 (en-US)       14 (fr-FR)       14 (de-DE)       14 (es-ES)
   //    168 (en-US)      168 (fr-FR)      168 (de-DE)      168 (es-ES)
   //    255 (en-US)      255 (fr-FR)      255 (de-DE)      255 (es-ES)            
   // </Snippet3>
}
