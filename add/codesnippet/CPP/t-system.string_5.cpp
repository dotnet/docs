   DateTime^ dateAndTime = gcnew DateTime(2011, 7, 6, 7, 32, 0);
   Double temperature = 68.3;
   String^ result = String::Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                  dateAndTime, temperature);
   Console::WriteLine(result);
   // The example displays the following output: 
   //       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.      