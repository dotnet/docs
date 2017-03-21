using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


public class Example
{
   public static void Main()
   {
      // Bitmap as stream.
      MemoryStream bitmapStream = new MemoryStream();
      Bitmap bmp = new Bitmap(@".\ContactsIcon.jpg");
      bmp.Save(bitmapStream, ImageFormat.Jpeg);
          
      // Define resources to be written.
      using (ResourceWriter rw = new ResourceWriter(@".\ContactResources.resources"))
      {
         rw.AddResource("Title", "Contact List");
         rw.AddResource("NColumns", 5);         
         rw.AddResource("Icon", bitmapStream);         
         rw.AddResource("Header1", "Name");
         rw.AddResource("Header2", "City");
         rw.AddResource("Header3", "State");  
         rw.AddResource("VersionDate", new DateTimeTZI(
                        new DateTime(2012, 5, 18),  
                        TimeZoneInfo.Local));
         rw.AddResource("ClientVersion", true);
         rw.Generate();
      }
   }
}