// <Snippet16>
using System;

[assembly: CLSCompliant(true)]

public class Person : person
{
 
}

public class person
{
 
}
// Compilation produces a compiler warning like the following:
//    Naming1.cs(11,14): warning CS3005: Identifier 'person' differing 
//                       only in case is not CLS-compliant
//    Naming1.cs(6,14): (Location of symbol related to previous warning)
// </Snippet16>

// <Snippet17>
public class Size
{
   private double a1;
   private double a2;
   
   public double â„«
   {
       get { return a1; }
       set { a1 = value; }
   }         
         
   public double Ã…
   {
       get { return a2; }
       set { a2 = value; }
   }
}
// Compilation produces a compiler warning like the following:
//    Naming2a.cs(16,18): warning CS3005: Identifier 'Size.Ã…' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(10,18): (Location of symbol related to previous warning)
//    Naming2a.cs(18,8): warning CS3005: Identifier 'Size.Ã….get' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(12,8): (Location of symbol related to previous warning)
//    Naming2a.cs(19,8): warning CS3005: Identifier 'Size.Ã….set' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(13,8): (Location of symbol related to previous warning)
// </Snippet17>

// â„«   Ã…    í©€í¼Š 
public class Example
{
   public static void Main()
   {

   }
}
