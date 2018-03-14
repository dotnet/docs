// <Snippet4>
using System;
using System.IO;
using System.Resources;

public class Example
{
   public static void Main()
   {
      // Get the image as an array of bytes.
      FileStream byteStream = new FileStream("AppIcon.jpg", FileMode.Open);
      Byte[] bytes = new Byte[(int) byteStream.Length];
      byteStream.Read(bytes, 0, (int) byteStream.Length);
      
      // Create the resource file.
      using (ResourceWriter rw = new ResourceWriter(@".\UIImages.resources")) {
         rw.AddResource("AppIcon", byteStream);
         // Add any other resources.
      }
   }
}
// </Snippet4>