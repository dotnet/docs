// <Snippet3>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

public class CarDisplayApp : Form
{
   private const string resxFile = @".\CarResources.resx";
   Automobile[] cars;

   public static void Main()
   {
      CarDisplayApp app = new CarDisplayApp();
      Application.Run(app);
   }

   public CarDisplayApp()
   {
      // Instantiate controls.
      PictureBox pictureBox = new PictureBox();
      pictureBox.Location = new Point(10, 10);
      this.Controls.Add(pictureBox);
      DataGridView grid = new DataGridView();
      grid.Location = new Point(10, 60);
      this.Controls.Add(grid);

      // Get resources from .resx file.
      using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
      {
         // Retrieve the string resource for the title.
         this.Text = resxSet.GetString("Title");
         // Retrieve the image.
         Icon image = (Icon) resxSet.GetObject("Information", true);
         if (image != null)
            pictureBox.Image = image.ToBitmap();

         // Retrieve Automobile objects.
         List<Automobile> carList = new List<Automobile>();
         string resName = "EarlyAuto";
         Automobile auto;
         int ctr = 1;
         do {
            auto = (Automobile) resxSet.GetObject(resName + ctr.ToString());
            ctr++;
            if (auto != null)
               carList.Add(auto);
         } while (auto != null);
         cars = carList.ToArray();
         grid.DataSource = cars;
      }
   }
}
// </Snippet3>

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