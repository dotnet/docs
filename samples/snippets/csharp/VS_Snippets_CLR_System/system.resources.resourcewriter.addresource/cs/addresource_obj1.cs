// <Snippet1>
using System;
using System.Resources;

public class Example
{
   public static void Main()
   {
      DonorColumns columns = new DonorColumns("Emplyee #", "Name", 
                                              "Total Amount", "Last Donation Date",
                                              "Last Donation Amount");
      ResourceWriter resFile = new ResourceWriter(@".\UIResources.resources");
      resFile.AddResource("Title", "Corporate Gold Star Donors");
      resFile.AddResource("NColumns", 5);
      resFile.AddResource("AppDate", new DateTime(2011, 5, 28));
      resFile.AddResource("AppVersion", new Version(1, 0, 217));
      resFile.AddResource("HRVersion", true);
      resFile.Generate();
      resFile.Close();               
   }
}

// Class to hold potentially localized column names.
[Serializable] public class DonorColumns
{
   readonly string ID;
   readonly string Name;
   readonly string Total;
   readonly string Last;
   readonly string Amt;

   public DonorColumns(string id, string name, string total, 
                  string last, string amt)
   {                  
      this.ID = id;
      this.Name = name;
      this.Total = total;
      this.Last = last;
      this.Amt = amt;                        
   }   
}
// </Snippet1>
