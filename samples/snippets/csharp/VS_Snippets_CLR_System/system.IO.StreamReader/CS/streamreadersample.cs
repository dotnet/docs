//<snippet1>
using System;
using System.IO;

namespace StreamReaderSample
{
    class StreamReaderSample : TextReader 
    {
        //</snippet1> 
        public StreamReaderSample() 
        {
            printInfo();
            usePeek();
            usePosition();
            useNull();
            useReadLine();
            useReadToEnd();
        }

        //All Overloaded Constructors for StreamReader
        //<snippet2> 
        private void getNewStreamReader() 
        {
            //Get a new StreamReader in ASCII format from a
            //file using a buffer and byte order mark detection
            StreamReader srAsciiFromFileFalse512 = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII, false, 512);
            //Get a new StreamReader in ASCII format from a
            //file with byte order mark detection = false
            StreamReader srAsciiFromFileFalse = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII, false);
            //Get a new StreamReader in ASCII format from a file 
            StreamReader srAsciiFromFile = 
                new StreamReader("C:\\Temp\\Test.txt",
                System.Text.Encoding.ASCII);
            //Get a new StreamReader from a
            //file with byte order mark detection = false
            StreamReader srFromFileFalse = 
                new StreamReader("C:\\Temp\\Test.txt", false);
            //Get a new StreamReader from a file
            StreamReader srFromFile = 
                new StreamReader("C:\\Temp\\Test.txt");
            //Get a new StreamReader in ASCII format from a
            //FileStream with byte order mark detection = false and a buffer
            StreamReader srAsciiFromStreamFalse512 = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII, false, 512);
            //Get a new StreamReader in ASCII format from a
            //FileStream with byte order mark detection = false
            StreamReader srAsciiFromStreamFalse = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII, false);
            //Get a new StreamReader in ASCII format from a FileStream
            StreamReader srAsciiFromStream = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            //Get a new StreamReader from a
            //FileStream with byte order mark detection = false
            StreamReader srFromStreamFalse = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"), 
                false);
            //Get a new StreamReader from a FileStream
            StreamReader srFromStream = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"));
        }
        //</snippet2>
        //<snippet3> 
        private void printInfo() 
        {
            //</snippet3>
            //<snippet4>  
            StreamReader srEncoding = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            Console.WriteLine("Encoding: {0}", 
                srEncoding.CurrentEncoding.EncodingName);
            srEncoding.Close();
            //</snippet4> 
        }

        private void usePeek() 
        {
            //<snippet5> 
            StreamReader srPeek = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            // set the file pointer to the beginning
            srPeek.BaseStream.Seek(0, SeekOrigin.Begin);
            // cycle while there is a next char
            while (srPeek.Peek() > -1) 
            {
                Console.Write(srPeek.ReadLine());
            }
            // close the reader and the file
            srPeek.Close();
            //</snippet5>
        }

        private void usePosition() 
        {
            //<snippet6> 
            StreamReader srRead = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            // set the file pointer to the beginning
            srRead.BaseStream.Seek(0, SeekOrigin.Begin);
            srRead.BaseStream.Position = 0;
            while (srRead.BaseStream.Position < srRead.BaseStream.Length) 
            {
                char[] buffer = new char[1];
                srRead.Read(buffer, 0, 1);
                Console.Write(buffer[0].ToString());
                srRead.BaseStream.Position++;
            }
            srRead.DiscardBufferedData();
            srRead.Close();
            //</snippet6>
        }
		
        private void useNull() 
        {
            //<snippet7> 
            StreamReader srNull = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            if(!srNull.Equals(StreamReader.Null)) 
            {
                srNull.BaseStream.Seek(0, SeekOrigin.Begin);
                Console.WriteLine(srNull.ReadToEnd());
            }
            srNull.Close();
            //</snippet7>
        }
        private void useReadLine() 
        {
            //<snippet8> 
            StreamReader srReadLine = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            srReadLine.BaseStream.Seek(0, SeekOrigin.Begin);
            while (srReadLine.Peek() > -1) 
            {
                Console.WriteLine(srReadLine.ReadLine());
            }
            srReadLine.Close();
            //</snippet8>	
        }
        private void useReadToEnd() 
        {
            //<snippet9> 
            StreamReader srReadToEnd = new StreamReader(
                (System.IO.Stream)File.OpenRead("C:\\Temp\\Test.txt"),
                System.Text.Encoding.ASCII);
            srReadToEnd.BaseStream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(srReadToEnd.ReadToEnd());
            srReadToEnd.Close();
            //</snippet9>
            //<snippet10> 
        }
        //</snippet10>
        //<snippet11> 
    }
}
//</snippet11>
class Class1
{
    static void Main(string[] args)
    {
        StreamReaderSample.StreamReaderSample srs = new StreamReaderSample.StreamReaderSample();
    }
}