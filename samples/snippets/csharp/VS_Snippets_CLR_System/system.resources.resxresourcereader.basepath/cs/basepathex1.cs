// <Snippet1>
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Resources;

public class Example
{
   public static void Main()
   {
      CreateXMLResourceFile();
      
      // Read the resources in the XML resource file.
      ResXResourceReader resx = new ResXResourceReader("DogBreeds.resx"); 
      Console.WriteLine("Default Base Path: '{0}'", resx.BasePath);
      resx.BasePath = @"C:\Data\";
      Console.WriteLine("Current Base Path: '{0}'\n", resx.BasePath); 
      resx.UseResXDataNodes = true;

      IDictionaryEnumerator dict = resx.GetEnumerator();
      AssemblyName[] assemblyNames = { new AssemblyName(typeof(Bitmap).Assembly.FullName) };
      while (dict.MoveNext()) {
         ResXDataNode node = (ResXDataNode) dict.Value;
         if (node.FileRef != null) {
            object image = node.GetValue(assemblyNames);
            Console.WriteLine("{0}: {1} from {2}", dict.Key, 
                              image.GetType().Name, node.FileRef.FileName);
         }
         else {
            Console.WriteLine("{0}: {1}", node.Name, node.GetValue((ITypeResolutionService) null));
         }   
      }   
   }

   private static void CreateXMLResourceFile()
   {
      // Define an array of ResXFileRef objects for images.
      String typeName = String.Format("{0}, {1}", typeof(Bitmap).FullName, 
                                      typeof(Bitmap).Assembly.FullName);
      ResXFileRef[] imageRefs =
         { new ResXFileRef(@"images\Akita.jpg", typeName),
           new ResXFileRef(@"images\Dalmatian.jpg", typeName),
           new ResXFileRef(@"images\Husky.jpg", typeName),
           new ResXFileRef(@"images\GreatPyrenees.jpg", typeName),
           new ResXFileRef(@"images\Malamute.jpg", typeName),
           new ResXFileRef(@"images\newfoundland.jpg", typeName),
           new ResXFileRef(@"images\Rottweiler.jpg", typeName) 
         };
      
      using (ResXResourceWriter resx = new ResXResourceWriter(@".\DogBreeds.resx")) {
         // Add each ResXFileRef object to the resource file.
         foreach (var imageRef in imageRefs) {
            // Form resource name from name of image.
            String name = imageRef.FileName;
            name = name.Substring(name.IndexOf(@"\") + 1);
            name = name.Substring(0, name.IndexOf("."));
            ResXDataNode node = new ResXDataNode(name, imageRef); 
            resx.AddResource(node);
         }
         resx.AddResource("CreatedBy", typeof(Example).Assembly.FullName);
      }   
   }
}
// The example displays the following output:
//    Default Base Path: ''
//    Current Base Path: 'C:\Data\'
//    
//    Akita: Bitmap from C:\Data\images\Akita.jpg
//    Dalmatian: Bitmap from C:\Data\images\Dalmatian.jpg
//    Husky: Bitmap from C:\Data\images\Husky.jpg
//    GreatPyrenees: Bitmap from C:\Data\images\GreatPyrenees.jpg
//    Malamute: Bitmap from C:\Data\images\Malamute.jpg
//    newfoundland: Bitmap from C:\Data\images\newfoundland.jpg
//    Rottweiler: Bitmap from C:\Data\images\Rottweiler.jpg
//    CreatedBy: BasePathEx1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// </Snippet1> 