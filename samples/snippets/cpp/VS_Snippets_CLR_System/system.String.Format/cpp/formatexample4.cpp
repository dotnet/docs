// FormatExample4.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"


// <Snippet6>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
   Dictionary<DateTime, Double>^ temperatureInfo = gcnew Dictionary<DateTime, Double>(); 
   temperatureInfo->Add(DateTime(2010, 6, 1, 14, 0, 0), 87.46);
   temperatureInfo->Add(DateTime(2010, 12, 1, 10, 0, 0), 36.81);
      
   Console::WriteLine("Temperature Information:\n");
   String^ output;   
   for each (KeyValuePair<DateTime, Double>^ item in temperatureInfo)
   {
      output = String::Format("Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F", 
                              item->Key, item->Value);
      Console::WriteLine(output);
   }
}
// The example displays the following output:
//       Temperature Information:
//       
//       Temperature at  2:00 PM on  6/1/2010:  87.5°F
//       Temperature at 10:00 AM on 12/1/2010:  36.8°F
// </Snippet6>

