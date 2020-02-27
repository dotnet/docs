using namespace System;

int main()
{
   // <Snippet1>
   System::DateTime today1 = System::DateTime(
      System::DateTime::Today.Ticks );
   System::DateTime today2 = System::DateTime(
      System::DateTime::Today.Ticks );
   System::DateTime tomorrow = System::DateTime(
      System::DateTime::Today.AddDays( 1 ).Ticks );
   
   // todayEqualsToday gets true.
   bool todayEqualsToday = System::DateTime::Equals( today1, today2 );
   
   // todayEqualsTomorrow gets false.
   bool todayEqualsTomorrow = System::DateTime::Equals( today1, tomorrow );
   // </Snippet1>

   System::Console::WriteLine( todayEqualsToday );
   System::Console::WriteLine( todayEqualsTomorrow );
}
