//<snippet1>
using System;
using System.IO;
using System.Runtime;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

namespace StreamWriterSample
{
    public class Logger 
    {		
        //</snippet1>
        //Constructors
        public Logger() 
        {
            BeginWrite();
        }
        public Logger(string logFile) 
        {
            BeginWrite(logFile);
        }
        //Destructor
        ~Logger() 
        {
            EndWrite();
        }
		
        //<snippet2> 
        public void CreateTextFile(string fileName, string textToAdd) 
        {
            string logFile = DateTime.Now.ToShortDateString()
                .Replace(@"/",@"-").Replace(@"\",@"-") + ".log";
			
            FileStream fs = new FileStream(fileName,
                FileMode.CreateNew, FileAccess.Write, FileShare.None);
			
            StreamWriter swFromFile = new StreamWriter(logFile);
            swFromFile.Write(textToAdd);
            swFromFile.Flush();
            swFromFile.Close();

            StreamWriter swFromFileStream = new StreamWriter(fs);
            swFromFileStream.Write(textToAdd);
            swFromFileStream.Flush();
            swFromFileStream.Close();

            StreamWriter swFromFileStreamDefaultEnc = 
                new System.IO.StreamWriter(fs, 
                System.Text.Encoding.Default);
            swFromFileStreamDefaultEnc.Write(textToAdd);
            swFromFileStreamDefaultEnc.Flush();
            swFromFileStreamDefaultEnc.Close();

            StreamWriter swFromFileTrue = 
                new StreamWriter(fileName,true);
            swFromFileTrue.Write(textToAdd);
            swFromFileTrue.Flush();
            swFromFileTrue.Close();
			
            StreamWriter swFromFileTrueUTF8Buffer = 
                new StreamWriter(fileName, 
                true, System.Text.Encoding.UTF8,512);
            swFromFileTrueUTF8Buffer.Write(textToAdd);
            swFromFileTrueUTF8Buffer.Flush();
            swFromFileTrueUTF8Buffer.Close();

            StreamWriter swFromFileTrueUTF8 = 
                new StreamWriter(fileName, true,
                System.Text.Encoding.UTF8);
            swFromFileTrueUTF8.Write(textToAdd);
            swFromFileTrueUTF8.Flush();
            swFromFileTrueUTF8.Close();

            StreamWriter swFromFileStreamUTF8Buffer = 
                new StreamWriter(fs, System.Text.Encoding.UTF8, 512);
            swFromFileStreamUTF8Buffer.Write(textToAdd);
            swFromFileStreamUTF8Buffer.Flush();
            swFromFileStreamUTF8Buffer.Close();
        }
        //</snippet2> 

        //<snippet3> 
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.Infrastructure)]
        private void BeginWrite(string logFile) 
        {
            //</snippet3> 
            //<snippet4>
            StreamWriter sw = new StreamWriter(logFile,true);
            //</snippet4>
            //<snippet5> 
            // Gets or sets a value indicating whether the StreamWriter
            // will flush its buffer to the underlying stream after every 
            // call to StreamWriter.Write.
            sw.AutoFlush = true;							 
            //</snippet5>
            //<snippet6> 
            if(sw.Equals(StreamWriter.Null)) 
            {
                sw.WriteLine("The store can be written to, but not read from.");
            }
            //</snippet6>
            //<snippet7> 
            sw.Write(char.Parse(" "));
            //</snippet7>
            //<snippet8> 
            string hello = "Hellow World!";
            char[] buffer = hello.ToCharArray();
            sw.Write(buffer);
            //</snippet8>
            //<snippet9> 
            string helloWorld = "Hellow World!";
            // writes out "low World"
            sw.Write(helloWorld);
            //</snippet9>
            //<snippet10> 
            sw.WriteLine("---Begin Log Entry---");
            //</snippet10>
            //<snippet11> 
            // Write out the current text encoding
            sw.WriteLine("Encoding: {0}",
                sw.Encoding.ToString());
            //</snippet11>
            //<snippet12> 
            // Display the Format Provider
            sw.WriteLine("Format Provider: {0} ",
                sw.FormatProvider.ToString());
            //</snippet12>
            //<snippet13> 
            // Set the characters you would like to designate a new line
            sw.NewLine = "\r\n";
            //</snippet13>
            //<snippet14> 
            ILease obj = (ILease)sw.InitializeLifetimeService();
            if(obj != null) 
            {
                sw.WriteLine("Object initialized lease " +
                    "time remaining: {0}.",
                    obj.CurrentLeaseTime.ToString()
                    );
            }
            //</snippet14>
            //<snippet15> 
            ILease lease = (ILease)sw.GetLifetimeService();
            if(lease != null) 
            {
                sw.WriteLine("Object lease time remaining: {0}.",
                    lease.CurrentLeaseTime.ToString()
                    );
            }
            //</snippet15>

            //<snippet16> 
            // update underlying file
            sw.Flush();
            //</snippet16>
            //<snippet17> 
            // close the file by closing the writer
            sw.Close();
            //</snippet17>
            //<snippet18> 
        }
        //</snippet18> 
        private void BeginWrite() 
        {
            BeginWrite(DateTime.Now.ToShortDateString()
                .Replace(@"/",@"-").Replace(@"\",@"-") + ".log");
        }

        private void EndWrite(string logFile) 
        {
            StreamWriter sw = new StreamWriter(logFile,true);

            // Set the file pointer to the end of file.
            sw.BaseStream.Seek(0, SeekOrigin.End);       
            // Write text to the file.
            sw.WriteLine("---End Log Entry---\r\n");
            // Update the underlying file.
            sw.Flush();
            // Close the file by closing the writer.
            sw.Close();
        }

        private void EndWrite() 
        {
            EndWrite(DateTime.Now.ToShortDateString()
                .Replace(@"/",@"-").Replace(@"\",@"-") + ".log");
        }
        //<snippet19> 
    }
}
//</snippet19>
public class EntryPoint 
{
    static void Main() 
    {
        StreamWriterSample.Logger l = new StreamWriterSample.Logger();
    }
}
