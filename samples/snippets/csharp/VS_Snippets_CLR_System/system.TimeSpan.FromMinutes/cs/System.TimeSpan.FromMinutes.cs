using System;

public class Class1
{
   public static void Main()
   {
      Class1 cl1 = new Class1();
      cl1.InstantiateMinutes();
      cl1.InstantiateDays();
      cl1.InstantiateHours();
      cl1.InstantiateMilliseconds();
      cl1.InstantiateSeconds();
   }

   private void InstantiateMinutes()
   {
      // <Snippet1>
      // The following throws an OverflowException at runtime
      TimeSpan maxSpan = TimeSpan.FromMinutes(TimeSpan.MaxValue.TotalMinutes);
      // </Snippet1>
   }

   private void InstantiateDays()
   {   
      // <Snippet2>
      // The following throws an OverflowException at runtime
      TimeSpan maxSpan = TimeSpan.FromDays(TimeSpan.MaxValue.TotalDays);
      // </Snippet2>
   }
   
   private void InstantiateHours()
   {
      // <Snippet3>
      // The following throws an OverflowException at runtime
      TimeSpan maxSpan = TimeSpan.FromHours(TimeSpan.MaxValue.TotalHours);
      // </Snippet3>
   }

   private void InstantiateMilliseconds()
   {
      // <Snippet4>
      // The following throws an OverflowException at runtime
      TimeSpan maxSpan = TimeSpan.FromMilliseconds(TimeSpan.MaxValue.TotalMilliseconds);
      // </Snippet4>
   }

   private void InstantiateSeconds()
   {
      // <Snippet5>
      // The following throws an OverflowException at runtime
      TimeSpan maxSpan = TimeSpan.FromSeconds(TimeSpan.MaxValue.TotalSeconds);
      // </Snippet5>
   }
}
