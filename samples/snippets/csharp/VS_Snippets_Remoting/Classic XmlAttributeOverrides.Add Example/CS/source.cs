// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

/* This is the class that will be overridden. The XmlIncludeAttribute 
tells the XmlSerializer that the overriding type exists. */

[XmlInclude(typeof(Band))]
public class Orchestra
{
   public Instrument[] Instruments;
}   

// This is the overriding class.
public class Band:Orchestra
{
   public string BandName;
}

public class Instrument
{
   public string Name;
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
      /* Each object that is being overridden requires 
      an XmlAttributes object. */
      XmlAttributes attrs = new XmlAttributes();

      // An XmlRootAttribute allows overriding the Orchestra class.
      XmlRootAttribute xmlRoot = new XmlRootAttribute();

      // Set the object to the XmlAttribute.XmlRoot property.
      attrs.XmlRoot = xmlRoot;

      // Create an XmlAttributeOverrides object.
      XmlAttributeOverrides attrOverrides = 
      new XmlAttributeOverrides();

      // Add the XmlAttributes to the XmlAttributeOverrrides.
      attrOverrides.Add(typeof(Orchestra), attrs);

      // Create the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create the object using the derived class.
      Band band = new Band();
      band.BandName = "NewBand";

      // Create an Instrument.
      Instrument i = new Instrument();
      i.Name = "Trumpet";
      Instrument[] myInstruments = {i};
      band.Instruments = myInstruments;

      // Serialize the object.
      s.Serialize(writer,band);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      XmlAttributes attrs = new XmlAttributes();
      XmlRootAttribute attr = new XmlRootAttribute();
      attrs.XmlRoot = attr;
      XmlAttributeOverrides attrOverrides = 
         new XmlAttributeOverrides();

      attrOverrides.Add(typeof(Orchestra), "Instruments", attrs);

      XmlSerializer s = 
      new XmlSerializer(typeof(Orchestra), attrOverrides);

      FileStream fs = new FileStream(filename, FileMode.Open);

      // Deserialize the Band object.
      Band band = (Band) s.Deserialize(fs);
      Console.WriteLine("Brass:");

      foreach(Instrument i in band.Instruments) 
      {
         Console.WriteLine(i.Name);
      }
   }
}

// </Snippet1>
