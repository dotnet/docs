using System;
using System.Xml;

namespace Microsoft.Samples.Xml
{
    class XmlWriteCharExample
    {
        static void Main()
        {
			//<snippet1>
			using (XmlWriter writer = XmlWriter.Create("WriteChars.xml"))
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
