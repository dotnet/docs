using System;

namespace MaintainabilityLibrary
{
   class MatchingNames
   {
      int someField;
   
      void SomeMethodOne(int someField) {}
      
      void SomeMethodTwo()
      {
         int someField;
      }
   }
}