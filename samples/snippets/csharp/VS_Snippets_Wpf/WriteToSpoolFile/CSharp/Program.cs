using System;
using System.Text;
using System.Printing;
using System.IO;


namespace WriteToSpoolFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //<SnippetAddUnnamedJob>
            // Create the printer server and print queue objects
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();

            // Call AddJob
            PrintSystemJobInfo myPrintJob = defaultPrintQueue.AddJob();

            // Write a Byte buffer to the JobStream and close the stream
            Stream myStream = myPrintJob.JobStream;
            Byte[] myByteBuffer = UnicodeEncoding.Unicode.GetBytes("This is a test string for the print job stream.");
            myStream.Write(myByteBuffer, 0, myByteBuffer.Length);
            myStream.Close();
            //</SnippetAddUnnamedJob>

            //<SnippetAddNamedJob>
            // Create the printer server and print queue objects
            LocalPrintServer localPrintServer2 = new LocalPrintServer();
            PrintQueue defaultPrintQueue2 = LocalPrintServer.GetDefaultPrintQueue();

            // Call AddJob 
            PrintSystemJobInfo anotherPrintJob = defaultPrintQueue2.AddJob("MyJob");

            // Read a file into a StreamReader
            StreamReader myStreamReader = new StreamReader("C:\\test.txt");

            // Write a Byte buffer to the JobStream and close the stream
            Stream anotherStream = anotherPrintJob.JobStream;
            Byte[] anotherByteBuffer = UnicodeEncoding.Unicode.GetBytes(myStreamReader.ReadToEnd());
            anotherStream.Write(anotherByteBuffer, 0, anotherByteBuffer.Length);
            anotherStream.Close();
            //</SnippetAddNamedJob>

        }//end Main

    }//end Program class

}// end namespace
