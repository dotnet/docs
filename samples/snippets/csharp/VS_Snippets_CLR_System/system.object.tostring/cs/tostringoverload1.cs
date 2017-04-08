// <Snippet4>
using System;

public class Automobile
{
   private int _doors;
   private String _cylinders;
   private int _year;
   private String _model;

   public Automobile(String model, int year , int doors,
                     String cylinders)
   {
      _model = model;
      _year = year;
      _doors = doors;
      _cylinders = cylinders;
   }

   public int Doors
   { get { return _doors; } }

   public String Model
   { get { return _model; } }

   public int Year
   { get { return _year; } }

   public String Cylinders
   { get { return _cylinders; } }

   public override String ToString()
   {
      return ToString("G");
   }

   public String ToString(String fmt)
   {
      if (String.IsNullOrEmpty(fmt))
         fmt = "G";

      switch (fmt.ToUpperInvariant())
      {
         case "G":
            return String.Format("{0} {1}", _year, _model);
         case "D":
            return String.Format("{0} {1}, {2} dr.",
                                 _year, _model, _doors);
         case "C":
            return String.Format("{0} {1}, {2}",
                                 _year, _model, _cylinders);
         case "A":
            return String.Format("{0} {1}, {2} dr. {3}",
                                 _year, _model, _doors, _cylinders);
         default:
            String msg = String.Format("'{0}' is an invalid format string",
                                       fmt);
            throw new ArgumentException(msg);
      }
   }
}

public class Example
{
   public static void Main()
   {
      var auto = new Automobile("Lynx", 2016, 4, "V8");
      Console.WriteLine(auto.ToString());
      Console.WriteLine(auto.ToString("A"));
   }
}
// The example displays the following output:
//       2016 Lynx
//       2016 Lynx, 4 dr. V8
// </Snippet4>
