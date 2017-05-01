// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Orchestra
{
   public Instrument[] Instruments;
}   

public class Instrument
{
   public string Name;
}

public class Brass:Instrument
{
   public bool IsValved;
}

public class Run
{
    public static void Main()
    {
       Run test = new Run();
       test.SerializeObject("Override.xml");
       test.DeserializeObject("Override.xml");
    }

    public void SerializeObject(string filename)
    {
      /* Each overridden field, property, or type requires 
      an XmlAttributes object. */
      XmlAttributes attrs = new XmlAttributes();

      /* Create an XmlElementAttribute to override the 
      field that returns Instrument objects. The overridden field
      returns Brass objects instead. */
      XmlElementAttribute attr = new XmlElementAttribute();
      attr.ElementName = "Brass";
      attr.Type = typeof(Brass);

      // Add the element to the collection of elements.
      attrs.XmlElements.Add(attr);

      // Create the XmlAttributeOverrides object.
      XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();

      /* Add the type of the class that contains the overridden 
      member and the XmlAttributes to override it with to the 
      XmlAttributeOverrides object. */
      attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

      // Create the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create the object that will be serialized.
      Orchestra band = new Orchestra();
      
      // Create an object of the derived type.
      Brass i = new Brass();
      i.Name = "Trumpet";
      i.IsValved = true;
      Instrument[] myInstruments = {i};
      band.Instruments = myInstruments;

      // Serialize the object.
      s.Serialize(writer,band);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      XmlAttributeOverrides attrOverrides = 
         new XmlAttributeOverrides();
      XmlAttributes attrs = new XmlAttributes();

      // Create an XmlElementAttribute to override the Instrument.
      XmlElementAttribute attr = new XmlElementAttribute();
      attr.ElementName = "Brass";
      attr.Type = typeof(Brass);

      // Add the element to the collection of elements.
      attrs.XmlElements.Add(attr);

      attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

      // Create the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      FileStream fs = new FileStream(filename, FileMode.Open);
      Orchestra band = (Orchestra) s.Deserialize(fs);
      Console.WriteLine("Brass:");

      /* The difference between deserializing the overridden 
      XML document and serializing it is this: To read the derived 
      object values, you must declare an object of the derived type 
      (Brass), and cast the Instrument instance to it. */
      Brass b;
      foreach(Instrument i in band.Instruments) 
      {
         b = (Brass)i;
         Console.WriteLine(
         b.Name + "\n" + 
         b.IsValved);
      }
   }
}

// </Snippet1>
