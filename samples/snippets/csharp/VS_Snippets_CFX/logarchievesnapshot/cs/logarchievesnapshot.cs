using System;
using System.IO.Log;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Snippets
{
    //<Snippet0>
    class LogBackup
    { 
        static void ArchiveToXML(LogStore logStore, string fileName) 
        {  
            LogArchiveSnapshot snapshot = logStore.CreateLogArchiveSnapshot();
            
            XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.ASCII);
            
            writer.WriteStartElement("logArchive");
            foreach(FileRegion region in snapshot.ArchiveRegions) 
            {
                writer.WriteStartElement("fileRegion"); 
                writer.WriteElementString("path", region.Path); 
                writer.WriteElementString("length", region.FileLength.ToString()); 
                writer.WriteElementString("offset", region.Offset.ToString()); 
                using(Stream dataStream = region.GetStream()) 
                { 
                    byte[] data = new byte[dataStream.Length]; 
                    dataStream.Read(data, 0, data.Length); 
                    writer.WriteElementString("data", Convert.ToBase64String(data)); 
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); 
            writer.Close(); 
            logStore.SetArchiveTail(snapshot.LastSequenceNumber); 
            
        }
        static void RestoreFromXML(string fileName) 
        { 
            using(XmlTextReader reader = new XmlTextReader(fileName)) 
            {
                reader.ReadStartElement("logArchive"); 
                while(reader.IsStartElement()) 
                { 
                    string path = reader.ReadElementString("path"); 
                    long length = Int64.Parse(reader.ReadElementString("length")); 
                    long offset = Int64.Parse(reader.ReadElementString("offset")); 
                    string dataString = reader.ReadElementString("data"); 
                    byte[] data = Convert.FromBase64String(dataString); 
                    FileStream fileStream;
                    using(fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)) 
                    { 
                        fileStream.SetLength(length); 
                        fileStream.Position = offset; fileStream.Write(data, 0, data.Length); 
                    }
                } 
            reader.ReadEndElement(); 
            } 
        } 
    }
    //</Snippet0>
}
