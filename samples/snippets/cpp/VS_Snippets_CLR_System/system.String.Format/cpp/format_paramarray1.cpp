// Format_ParamArray1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet10>
using namespace System;

ref class CityInfo
{
public:
   CityInfo(String^ name, int population, Decimal area, int year)
   {
      this->Name = name;
      this->Population = population;
      this->Area = area;
      this->Year = year;
   }
   
   String^ Name; 
   int Population;
   Decimal Area;
   int Year;
};

ref class Example
{
public:
   static void ShowPopulationData(CityInfo^ city)
   {
      array<Object^>^ args = gcnew array<Object^> { city->Name, city->Year, city->Population, city->Area };
      String^ result = String::Format("{0} in {1}: Population {2:N0}, Area {3:N1} sq. feet", 
                                    args);
      Console::WriteLine(result); 
   }
};

void main()
{
   CityInfo^ nyc2010 = gcnew CityInfo("New York", 8175133, (Decimal) 302.64, 2010);
   Example::ShowPopulationData(nyc2010);
   CityInfo^ sea2010 = gcnew CityInfo("Seattle", 608660, (Decimal) 83.94, 2010);      
   Example::ShowPopulationData(sea2010); 
}
// The example displays the following output:
//       New York in 2010: Population 8,175,133, Area 302.6 sq. feet
//       Seattle in 2010: Population 608,660, Area 83.9 sq. feet
// </Snippet10>