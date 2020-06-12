// <Snippet1>
using System;
using System.Drawing;
using System.Resources;

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

public class Example
{
   public static void Main()
   {
      // Instantiate an Automobile object.
      Automobile car1 = new Automobile("Ford", "Model N", 1906, 0, 4);
      Automobile car2 = new Automobile("Ford", "Model T", 1909, 2, 4);
      // Define a resource file named CarResources.resx.
      using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
      {
         resx.AddResource("Title", "Classic American Cars");
         resx.AddResource("HeaderString1", "Make");
         resx.AddResource("HeaderString2", "Model");
         resx.AddResource("HeaderString3", "Year");
         resx.AddResource("HeaderString4", "Doors");
         resx.AddResource("HeaderString5", "Cylinders");
         resx.AddResource("Information", SystemIcons.Information);
         resx.AddResource("EarlyAuto1", car1);
         resx.AddResource("EarlyAuto2", car2);
      }
   }
}
// </Snippet1>
