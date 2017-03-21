public static void WriteXml( XmlDocument doc )
 {
    XmlTextWriter writer = new XmlTextWriter(Console.Out);
    writer.Formatting = Formatting.Indented;
    doc.WriteContentTo( writer );
    writer.Flush();
    Console.WriteLine();
 }