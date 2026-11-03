// <Snippet2>
using System;

[assembly: CLSCompliant(true)]

public class Person
{
   private UInt16 personAge = 0;

   public Int16 Age => (Int16)personAge; 
}
// </Snippet2>
