using System;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace UEBodyWriter
{
    class MyBodyWriter : BodyWriter
    {
        const string textTag = "text";
        string[] bodySegment;
   
        public MyBodyWriter(string[] strData) : base(true)
        {
            int length = strData.Length;
            
            this.bodySegment = new string[length];
            for (int i = 0; i < length; i++)
            {
                this.bodySegment[i] = strData[i];
            }
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
           writer.WriteStartElement(textTag);

           foreach (string str in bodySegment)
           {
               writer.WriteString(str);
           }
 
            writer.WriteEndElement();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = {"Hello", "world"};
            MyBodyWriter bw = new MyBodyWriter(strings);

            StringBuilder strBuilder = new StringBuilder(10);
            XmlWriter writer = XmlWriter.Create(strBuilder);
            XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);

            bw.WriteBodyContents(dictionaryWriter);
            dictionaryWriter.Flush();
        }
    }
}