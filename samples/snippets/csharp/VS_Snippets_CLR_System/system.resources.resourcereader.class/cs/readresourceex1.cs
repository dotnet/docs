// <Snippet6>
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;

public class Example
{
   public static void Main()
   {
      ResourceReader rdr = new ResourceReader(@".\ContactResources.resources");  
      IDictionaryEnumerator dict = rdr.GetEnumerator();
      while (dict.MoveNext()) {
         Console.WriteLine("Resource Name: {0}", dict.Key);
         try {
            Console.WriteLine("   Value: {0}", dict.Value);
         }
         catch (FileNotFoundException) {
            Console.WriteLine("   Exception: A file cannot be found.");
            DisplayResourceInfo(rdr, (string) dict.Key, false);
         }
         catch (FormatException) {
            Console.WriteLine("   Exception: Corrupted data.");
            DisplayResourceInfo(rdr, (string) dict.Key, true);
         }
         catch (TypeLoadException) {
            Console.WriteLine("   Exception: Cannot load the data type.");
            DisplayResourceInfo(rdr, (string) dict.Key, false);   
         }
      } 
   }

   private static void DisplayResourceInfo(ResourceReader rr, 
                                   string key, bool loaded)
   {                                
      string dataType = null;
      byte[] data = null;
      rr.GetResourceData(key, out dataType, out data);
            
      // Display the data type.
      Console.WriteLine("   Data Type: {0}", dataType);
      // Display the bytes that form the available data.      
      Console.Write("   Data: ");
      int lines = 0;
      foreach (var dataItem in data) {
         lines++;
         Console.Write("{0:X2} ", dataItem);
         if (lines % 25 == 0)
            Console.Write("\n         ");
      }
      Console.WriteLine();
      // Try to recreate current state of  data.
      // Do: Bitmap, DateTimeTZI
      switch (dataType) 
      {  
         // Handle internally serialized string data (ResourceTypeCode members).
         case "ResourceTypeCode.String":
            BinaryReader reader = new BinaryReader(new MemoryStream(data));
            string binData = reader.ReadString();
            Console.WriteLine("   Recreated Value: {0}", binData);
            break;
         case "ResourceTypeCode.Int32":
            Console.WriteLine("   Recreated Value: {0}", 
                              BitConverter.ToInt32(data, 0));
            break;
         case "ResourceTypeCode.Boolean":
            Console.WriteLine("   Recreated Value: {0}", 
                              BitConverter.ToBoolean(data, 0));
            break;
         // .jpeg image stored as a stream.
         case "ResourceTypeCode.Stream":  
            const int OFFSET = 4;
            int size = BitConverter.ToInt32(data, 0);
            Bitmap value1 = new Bitmap(new MemoryStream(data, OFFSET, size));
            Console.WriteLine("   Recreated Value: {0}", value1); 
            break;
         // Our only other type is DateTimeTZI.
         default:
            // No point in deserializing data if the type is unavailable.
            if (dataType.Contains("DateTimeTZI") && loaded) { 
               BinaryFormatter binFmt = new BinaryFormatter();
               object value2 = binFmt.Deserialize(new MemoryStream(data));
               Console.WriteLine("   Recreated Value: {0}", value2);
            }    
            break;
      }
      Console.WriteLine();
   }
}
// </Snippet6>
