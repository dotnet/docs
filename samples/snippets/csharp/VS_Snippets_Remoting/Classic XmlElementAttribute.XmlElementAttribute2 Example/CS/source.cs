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

public class Brass:Instrument{
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
      // To write the file, a TextWriter is required.
      TextWriter writer = new StreamWriter(filename);
      
      XmlAttributeOverrides attrOverrides = 
         new XmlAttributeOverrides();
      XmlAttributes attrs = new XmlAttributes();

      // Creates an XmlElementAttribute that overrides the Instrument type.
      XmlElementAttribute attr = new 
      XmlElementAttribute(typeof(Brass));
      attr.ElementName = "Brass";

      // Adds the element to the collection of elements.
      attrs.XmlElements.Add(attr);
      attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

      // Creates the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      // Creates the object to serialize.
      Orchestra band = new Orchestra();
      
      // Creates an object of the derived type.
      Brass i = new Brass();
      i.Name = "Trumpet";
      i.IsValved = true;
      Instrument[] myInstruments = {i};
      band.Instruments = myInstruments;
      s.Serialize(writer,band);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      XmlAttributeOverrides attrOverrides = 
         new XmlAttributeOverrides();
      XmlAttributes attrs = new XmlAttributes();

      // Creates an XmlElementAttribute that override the Instrument type.
      XmlElementAttribute attr = new 
      XmlElementAttribute(typeof(Brass));
      attr.ElementName = "Brass";

      // Adds the element to the collection of elements.
      attrs.XmlElements.Add(attr);
      attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

      // Creates the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      FileStream fs = new FileStream(filename, FileMode.Open);
      Orchestra band = (Orchestra) s.Deserialize(fs);
      Console.WriteLine("Brass:");

      /* Deserializing differs from serializing. To read the 
         derived-object values, declare an object of the derived 
         type (Brass) and cast the Instrument instance to it. */
      Brass b;
      foreach(Instrument i in band.Instruments) 
      {
         b= (Brass)i;
         Console.WriteLine(
         b.Name + "\n" + 
         b.IsValved);
      }
   }
}

// </Snippet1>
