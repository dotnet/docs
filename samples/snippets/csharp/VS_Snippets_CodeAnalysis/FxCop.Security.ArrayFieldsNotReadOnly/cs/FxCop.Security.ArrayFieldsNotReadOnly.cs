//<Snippet1>
using System;

namespace SecurityRulesLibrary
{
   public class MyClassWithReadOnlyArrayField
   {
      public readonly int[] grades = {90, 90, 90};
      private readonly int[] privateGrades = {90, 90, 90};
      private readonly int[] securePrivateGrades = {90, 90, 90};

      // Making the array private does not protect it because it is passed to others.
      public int[] GetPrivateGrades()
      {
         return privateGrades;
      }
      //This method secures the array by cloning it.
      public int[] GetSecurePrivateGrades()
      {
            return (int[])securePrivateGrades.Clone();
      }

      public override string ToString() 
      {
         return String.Format("Grades: {0}, {1}, {2} Private Grades: {3}, {4}, {5}  Secure Grades, {6}, {7}, {8}", 
            grades[0], grades[1], grades[2], privateGrades[0], privateGrades[1], privateGrades[2], securePrivateGrades[0], securePrivateGrades[1], securePrivateGrades[2]);
      }     
   }
}
   
//</Snippet1>
