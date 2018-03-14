using System;
using System.Xml;

namespace Microsoft.Samples.Xml
{
    class XmlTextWriterWriteChar
    {
        static void Main()
        {
            //<snippet1>
            using (XmlTextWriter writer = new XmlTextWriter(Console.Out))
            {
                writer.WriteStartDocument();

                char[] ch = new char[4];
                ch[0] = 't';
                ch[1] = 'e';
                ch[2] = 'x';
                ch[3] = 't';

                writer.WriteStartElement("WriteCharacters");
                writer.WriteChars(ch, 0, ch.Length);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            //</snippet1>
        }
    }
}
