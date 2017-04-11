// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

/* Three classes are included here. Each one will
be used to create three XmlSerializer objects. */

public class Instrument
{
   public string InstrumentName;
}

public class Player
{
   public string PlayerName;
}

public class Piece
{
   public string PieceName;
}
 
public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.GetSerializers();
   }

   public void GetSerializers()
   {
      // Create an array of types.
      Type[]types = new Type[3];
      types[0] = typeof(Instrument);
      types[1] = typeof(Player);
      types[2] = typeof(Piece);
 
      // Create an array for XmlSerializer objects.
      XmlSerializer[]serializers= new XmlSerializer[3];
      serializers = XmlSerializer.FromTypes(types);
      // Create one Instrument and serialize it.
      Instrument i = new Instrument();
      i.InstrumentName = "Piano";
      // Create a TextWriter to write with.
      TextWriter writer = new StreamWriter("Inst.xml");
      serializers[0].Serialize(writer,i);
      writer.Close();
   }
}

// </Snippet1>
