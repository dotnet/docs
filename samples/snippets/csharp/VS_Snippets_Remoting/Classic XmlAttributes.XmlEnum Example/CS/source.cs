// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Food
{
   public FoodType Type;
}

public enum FoodType
{
   // Subsequent code overrides these enumerations.
   Low,
   High
}


 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("OverrideEnum.xml");
      test.DeserializeObject("OverrideEnum.xml");
   }

   // Return an XmlSerializer used for overriding. 
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      XmlAttributes xAttrs = new XmlAttributes();

      // Add an XmlEnumAttribute for the FoodType.Low enumeration.
      XmlEnumAttribute xEnum = new XmlEnumAttribute();
      xEnum.Name = "Cold";
      xAttrs.XmlEnum = xEnum;
      xOver.Add(typeof(FoodType), "Low", xAttrs);

      // Add an XmlEnumAttribute for the FoodType.High enumeration.
      xAttrs = new XmlAttributes();
      xEnum = new XmlEnumAttribute();
      xEnum.Name = "Hot";
      xAttrs.XmlEnum = xEnum;
      xOver.Add(typeof(FoodType), "High", xAttrs);

      // Create the XmlSerializer, and return it.
      return new XmlSerializer(typeof(Food), xOver);
   }
   
 
   public void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer =  CreateOverrider();
      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the class that will be serialized.
      Food myFood = new Food();

      // Set the object properties.
      myFood.Type = FoodType.High;

      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myFood);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      XmlSerializer mySerializer = CreateOverrider();
      FileStream fs = new FileStream(filename, FileMode.Open);
      Food myFood = (Food) 
      mySerializer.Deserialize(fs);

      Console.WriteLine(myFood.Type);
   }
}
   
// </Snippet1>
