
// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

public class Example : IComparer
{
   private const string FILENAME = @".\Regions.dat";

   private struct Region
   {
      internal Region(string id, string name) 
      {
         this.Id = id;
         this.NativeName = name;
      }
      
      public string Id;
      public string NativeName;
      
      public override string ToString()
      {
         return this.NativeName;
      }
   }

   public static void Main()
   {
      bool reindex = false;
      
      Region[] regions;
      SortVersion ver = null;

      // If the data has not been saved, create it.
      if (! File.Exists(FILENAME)) { 
         regions = GenerateData();
         ver = CultureInfo.CurrentCulture.CompareInfo.Version;  
         reindex = true;
      }
      // Retrieve the existing data.
      else {
         regions = RestoreData(out ver);
      }

      // Determine whether the current ordering is valid; if not, reorder.
      if (reindex || ver != CultureInfo.CurrentCulture.CompareInfo.Version) { 
         Array.Sort(regions, new Example());      
         // Save newly reordered data.
         SaveData(regions);
      }
      
      // Continue with application...
   }

   private static Region[] GenerateData()
   {
      List<Region> regions = new List<Region>();

      foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
         if (culture.IsNeutralCulture | culture.Equals(CultureInfo.InvariantCulture))
            continue;
            
         RegionInfo region = new RegionInfo(culture.Name);
         regions.Add(new Region(region.Name, region.NativeName));
      }
      return regions.ToArray();
   }

   private static Region[] RestoreData(out SortVersion ver)
   {
      List<Region> regions = new List<Region>();
      
      BinaryReader rdr = new BinaryReader(File.Open(FILENAME, FileMode.Open));
      
      int sortVer = rdr.ReadInt32();
      Guid sortId = Guid.Parse(rdr.ReadString());
      ver = new SortVersion(sortVer, sortId);
      
      string id, name;
      while (rdr.PeekChar() != -1) {
         id = rdr.ReadString();
         name = rdr.ReadString();
         regions.Add(new Region(id, name));      
      }
      return regions.ToArray();
   }

   private static void SaveData(Region[] regions)
   {
      SortVersion ver = CultureInfo.CurrentCulture.CompareInfo.Version;

      BinaryWriter wrtr = new BinaryWriter(File.Open(FILENAME, FileMode.Create));
      wrtr.Write(ver.FullVersion); 
      wrtr.Write(ver.SortId.ToString()); 
      
      foreach (var region in regions) {
         wrtr.Write(region.Id);
         wrtr.Write(region.NativeName);
      }
      wrtr.Close();
   }

   public int Compare(object o1, object o2)
   {
        // Assume that all casts succeed.
        Region r1 = (Region) o1;
        Region r2 = (Region) o2;
        
        return String.Compare(r1.NativeName, r2.NativeName, 
                              StringComparison.CurrentCulture);        
   }
}
// </Snippet1>
