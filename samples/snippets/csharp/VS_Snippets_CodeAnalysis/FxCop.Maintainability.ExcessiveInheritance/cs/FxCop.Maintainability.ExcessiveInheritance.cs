//<Snippet1>
using System;

namespace MaintainabilityLibrary
{
   class BaseClass {}
   class FirstDerivedClass : BaseClass {}
   class SecondDerivedClass : FirstDerivedClass {}
   class ThirdDerivedClass : SecondDerivedClass {}
   class FourthDerivedClass : ThirdDerivedClass {}

   // This class violates the rule.
   class FifthDerivedClass : FourthDerivedClass {}
}
//</Snippet1>
