// <Snippet2>
using System;

public class Person
{
   public String Name { get; set; }
   public DateTime BirthDate  { get; set; }
   public Double Height { get; set; }
   public Double Weight { get; set; }
   public Char Gender { get; set; }
   public String Remarks { get; set; }
   
   public object[] GetDescription() 
   {
      return new object[] { Name, Gender, Height, Weight, BirthDate};
   }
}

public class Example
{
   public static void Main()
   {
      var p1 = new Person() { Name = "John", Gender = 'M',
                              BirthDate = new DateTime(1992, 5, 10), 
                              Height = 73.5, Weight = 207 };
      p1.Remarks = "Client since 1/3/2012";
      Console.Write("{0}: {1}, born {2:d}  Height {3} inches, Weight {4} lbs  ", 
                    p1.Name, p1.Gender, p1.BirthDate, p1.Height, p1.Weight);
      if (String.IsNullOrEmpty(p1.Remarks))
         Console.WriteLine();
      else
         Console.WriteLine("{1}Remarks: {0}", p1.Remarks,
                           Console.CursorLeft + p1.Remarks.Length + 10 > Console.WindowWidth ?
                              "\n   " : "");
   }
}
// The example displays the following output:
//    John: M, born 5/10/1992  Height 73.5 inches, Weight 207 lbs  Remarks: Client since 1/3/2012
// </Snippet2>

