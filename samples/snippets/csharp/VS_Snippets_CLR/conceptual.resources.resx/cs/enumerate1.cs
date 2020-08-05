// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;

public class Example
{
   public static void Main()
   {
      string resxFile = @".\CarResources.resx";
      List<Automobile> autos = new List<Automobile>();
      SortedList headers = new SortedList();

      using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
      {
         foreach (DictionaryEntry entry in resxReader) {
            if (((string) entry.Key).StartsWith("EarlyAuto"))
               autos.Add((Automobile) entry.Value);
            else if (((string) entry.Key).StartsWith("Header"))
               headers.Add((string) entry.Key, (string) entry.Value);
         }
      }
      string[] headerColumns = new string[headers.Count];
      headers.GetValueList().CopyTo(headerColumns, 0);
      Console.WriteLine("{0,-8} {1,-10} {2,-4}   {3,-5}   {4,-9}\n",
                        headerColumns);
      foreach (var auto in autos)
         Console.WriteLine("{0,-8} {1,-10} {2,4}   {3,5}   {4,9}",
                           auto.Make, auto.Model, auto.Year,
                           auto.Doors, auto.Cylinders);
   }
}
// The example displays the following output:
//       Make     Model      Year   Doors   Cylinders
//
//       Ford     Model N    1906       0           4
//       Ford     Model T    1909       2           4
// </Snippet2>

[Serializable()] public class Automobile
{
   private string carMake;
   private string carModel;
   private int carYear;
   private int carDoors;
   private int carCylinders;

   public Automobile(string make, string model, int year) :
                     this(make, model, year, 0, 0)
   { }

   public Automobile(string make, string model, int year,
                     int doors, int cylinders)
   {
      this.carMake = make;
      this.carModel = model;
      this.carYear = year;
      this.carDoors = doors;
      this.carCylinders = cylinders;
   }

   public string Make {
      get { return this.carMake; }
   }

   public string Model {
      get {return this.carModel; }
   }

   public int Year {
      get { return this.carYear; }
   }

   public int Doors {
      get { return this.carDoors; }
   }

   public int Cylinders {
      get { return this.carCylinders; }
   }
}