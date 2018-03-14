using System;

public class Class1 
{
   private static DateTimeOffset dto; 
 
   public Class1()
   {
      dto = DateTimeOffset.Now;
   }

   public DateTime UtcDateTime
   {
      get { return dto.UtcDateTime; }
   }

   public static void Main()
   {
      int retVal;
      DateTime now = DateTime.Now;
      retVal = Comparison(now, 
         new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, new TimeSpan(-4, 0, 0)));
      Class1 thisInst = new Class1();         
      Console.WriteLine(retVal);
      Console.WriteLine(thisInst.Equality(DateTimeOffset.Now));
      Console.WriteLine(thisInst.Equality2(dto));
      Console.WriteLine(thisInst.Equality3());
      Console.WriteLine(thisInst.GreaterThan());
   }

   private static int Comparison(DateTimeOffset first, DateTimeOffset second)
   {
      // <Snippet1>
      return DateTime.Compare(first.UtcDateTime, second.UtcDateTime);
      // </Snippet1>
   }

   private bool Equality(DateTimeOffset other) 
   {
      // <Snippet2>
      return this.UtcDateTime == other.UtcDateTime;
      // </Snippet2>
   }
   
   private bool Equality2(object obj)
   {
      // <Snippet3>
      return this.UtcDateTime == ((DateTimeOffset) obj).UtcDateTime;
      // </Snippet3>   
   }

   private bool Equality3()
   {
      DateTimeOffset first = DateTimeOffset.Now;
      DateTimeOffset second = DateTimeOffset.Now;
      // <Snippet4>
      return first.UtcDateTime == second.UtcDateTime;
      // </Snippet4>   
   }

   private bool GreaterThan()
   {
      DateTimeOffset right = DateTimeOffset.Now;
      DateTimeOffset left = DateTimeOffset.Now;
      // <Snippet5>
      return left.UtcDateTime > right.UtcDateTime;
      // </Snippet5>   
      // <Snippet6>
      return left.UtcDateTime >= right.UtcDateTime;
      // </Snippet6>   
      // <Snippet7>
      return left.UtcDateTime != right.UtcDateTime;
      // </Snippet7>   
      // <Snippet8>
      return left.UtcDateTime < right.UtcDateTime;
      // </Snippet8>   
      // <Snippet9>
      return left.UtcDateTime <= right.UtcDateTime;
      // </Snippet9>   
   }
}
