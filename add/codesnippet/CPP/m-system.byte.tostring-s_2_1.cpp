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