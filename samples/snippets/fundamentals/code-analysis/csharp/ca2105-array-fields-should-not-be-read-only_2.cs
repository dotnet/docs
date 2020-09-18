using System;
using SecurityRulesLibrary;

namespace TestSecRulesLibrary
{
   public class TestArrayReadOnlyRule
   {
      [STAThread]
      public static void Main() 
      {
         MyClassWithReadOnlyArrayField dataHolder = 
            new MyClassWithReadOnlyArrayField();

         // Get references to the library's readonly arrays.
         int[] theGrades = dataHolder.grades;
         int[] thePrivateGrades = dataHolder.GetPrivateGrades();
         int[] theSecureGrades = dataHolder.GetSecurePrivateGrades();

         Console.WriteLine(
            "Before tampering: {0}", dataHolder.ToString());

         // Overwrite the contents of the "readonly" array. 
         theGrades[1]= 555;
         thePrivateGrades[1]= 555;
         theSecureGrades[1]= 555;
         Console.WriteLine(
            "After tampering: {0}",dataHolder.ToString());
      }
   }
}