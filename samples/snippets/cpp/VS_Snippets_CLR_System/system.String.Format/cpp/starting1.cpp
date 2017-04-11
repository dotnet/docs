using namespace System;



ref class Example
{
   public:
      static void Snippet31()
      {
         // <Snippet31>
         String^ s = String::Format("At {0}, the temperature is {1}°C.",
                                    DateTime::Now, 20.4);
         // Output similar to: 'At 4/10/2015 9:29:41 AM, the temperature is 20.4°C.'
         // </Snippet31>
         Console::WriteLine(s);
      }
      
      static void Snippet32()
      {
         // <Snippet32>
         String^ s = String::Format("It is now {0:d} at {0:t}",
                                    DateTime::Now);
         // Output similar to: 'It is now 4/10/2015 at 10:04 AM'
         // </Snippet32>
         Console::WriteLine(s);
      }

      static void Snippet33()
      {
       // <Snippet33>
       array<int>^ years = { 2013, 2014, 2015 };
       array<int>^ population = { 1025632, 1105967, 1148203 };
       String^ s = String::Format("{0,6} {1,15}\n\n", "Year", "Population");
       for(int index = 0; index < years->Length; index++)
          s += String::Format("{0,6} {1,15:N0}\n",
                              years[index], population[index]);
       // Result:
       //      Year      Population
       //
       //      2013       1,025,632
       //      2014       1,105,967
       //      2015       1,148,203
       // </Snippet33>
       Console::WriteLine(s);
      }
      
      static void Snippet34()
      {
          // <Snippet34>
          array<int>^ years = { 2013, 2014, 2015 };
          array<int>^ population = { 1025632, 1105967, 1148203 };
          String^ s = String::Format("{0,-10} {1,-10}\n\n", "Year", "Population");
          for(int index = 0; index < years->Length; index++)
             s += String::Format("{0,-10} {1,-10:N0}\n",
                                years[index], population[index]);
          // Result:
          //    Year       Population
          //
          //    2013       1,025,632
          //    2014       1,105,967
          //    2015       1,148,203
          // </Snippet34>
          Console::WriteLine("\n{0}", s);
      }
};

void main()
{
   // <Snippet30>
   Decimal temp = (Decimal)20.4;
   String^ s = String::Format("The temperature is {0}°C.", temp);
   Console::WriteLine(s);
   // Displays 'The temperature is 20.4°C.'
   // </Snippet30>

   Example::Snippet31();
   Example::Snippet32();
   Example::Snippet33();
   Example::Snippet34();
}
