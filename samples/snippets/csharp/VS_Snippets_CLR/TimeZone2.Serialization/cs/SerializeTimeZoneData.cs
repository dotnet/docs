// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
// </Snippet2>

[assembly:CLSCompliant(true)]
class TimeZoneSerialization
{
   private const string resxName = "SerializedTimeZones.resx";

   static void Main()
   {
      TimeZoneSerialization tzSerialization = new TimeZoneSerialization();
      tzSerialization.DeserializeTimeZones();
   }

   // <Snippet1>
   TimeZoneSerialization()
   {
      TextWriter writeStream;
      Dictionary<string, string> resources = new Dictionary<string, string>();
      // Determine if .resx file exists
      if (File.Exists(resxName))
      {
         // Open reader
         TextReader readStream = new StreamReader(resxName);
         ResXResourceReader resReader = new ResXResourceReader(readStream);
         foreach (DictionaryEntry item in resReader)
         {
            if (! (((string) item.Key) == "CentralStandardTime" ||
                   ((string) item.Key) == "PalmerStandardTime" ))
               resources.Add((string)item.Key, (string) item.Value);
         }
         readStream.Close();
         // Delete file, since write method creates duplicate xml headers
         File.Delete(resxName);
      }

      // Open stream to write to .resx file
      try
      {
         writeStream = new StreamWriter(resxName, true);
      }
      catch (FileNotFoundException e)
      {
         // Handle failure to find file
         Console.WriteLine($"{e.GetType().Name}: The file {resxName} could not be found.");
         return;
      }

      // Get resource writer
      ResXResourceWriter resWriter = new ResXResourceWriter(writeStream);

      // Add resources from existing file
      foreach (KeyValuePair<string, string> item in resources)
      {
         resWriter.AddResource(item.Key, item.Value);
      }

      // Serialize Central Standard Time
      try
      {
         TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
         resWriter.AddResource(cst.Id.Replace(" ", string.Empty), cst.ToSerializedString());
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The Central Standard Time zone could not be found.");
      }

      // Create time zone for Palmer, Antarctica
      //
      // Define transition times to/from DST
      TimeZoneInfo.TransitionTime startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 4, 0, 0),
                                                                                                 10, 2, DayOfWeek.Sunday);
      TimeZoneInfo.TransitionTime endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 3, 0, 0),
                                                                                               3, 2, DayOfWeek.Sunday);
      // Define adjustment rule
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1999, 10, 1),
                                            DateTime.MaxValue.Date, delta, startTransition, endTransition);
      // Create array for adjustment rules
      TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
      // Define other custom time zone arguments
      string DisplayName = "(GMT-04:00) Antarctica/Palmer Time";
      string standardName = "Palmer Standard Time";
      string daylightName = "Palmer Daylight Time";
      TimeSpan offset = new TimeSpan(-4, 0, 0);
      TimeZoneInfo palmer = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, DisplayName, standardName, daylightName, adjustments);
      resWriter.AddResource(palmer.Id.Replace(" ", String.Empty), palmer.ToSerializedString());

      // Save changes to .resx file
      resWriter.Generate();
      resWriter.Close();
      writeStream.Close();
   }
   // </Snippet1>

   // <Snippet3>
   private void DeserializeTimeZones()
   {
      TimeZoneInfo cst, palmer;
      string timeZoneString;
      ResourceManager resMgr = new ResourceManager("SerializeTimeZoneData.SerializedTimeZones", this.GetType().Assembly);

      // Attempt to retrieve time zone from system
      try
      {
         cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
      }
      catch (TimeZoneNotFoundException)
      {
         // Time zone not in system; retrieve from resource
         timeZoneString = resMgr.GetString("CentralStandardTime");
         if (! String.IsNullOrEmpty(timeZoneString))
         {
            cst = TimeZoneInfo.FromSerializedString(timeZoneString);
         }
         else
         {
            MessageBox.Show("Unable to create Central Standard Time Zone. Application must exit.", "Application Error");
            return;
         }
      }
      // Retrieve custom time zone
      try
      {
         timeZoneString = resMgr.GetString("PalmerStandardTime");
         palmer = TimeZoneInfo.FromSerializedString(timeZoneString);
      }
      catch (MissingManifestResourceException)
      {
         MessageBox.Show("Unable to retrieve the Palmer Standard Time Zone from the resource file. Application must exit.");
         return;
      }
   }
   // </Snippet3>
}
