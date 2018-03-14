// <Snippet25>
using System;

[assembly: CLSCompliant(true)]

public class Group
{
   private string[] members;
   
   public Group(params string[] memberList)
   {
      members = memberList;
   }
   
   public override string ToString() 
   {
      return String.Join(", ", members);
   }
}



public class Example
{
   public static void Main()
   {
      Group gp = new Group("Matthew", "Mark", "Luke", "John");
      Console.WriteLine(gp.ToString());    
   }
}
// The example displays the following output:
//        Matthew, Mark, Luke, John
// </Snippet25>
