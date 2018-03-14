/**
  *File name: WebEventProvider.cs
  *Purpose: Shows how to build a custom event provider. 
  **/  

// <Snippet1>

using System;
using System.Text;
using System.IO;
using System.Web.Management;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;


namespace SamplesAspNet
{
  // Implements a custom event provider.
    public class SampleEventProvider : 
        System.Web.Management.WebEventProvider
    {

        // The local path of the file where
        // to store event information.
        private string logFilePath;
    
        // The current number of buffered messages 
        private int msgCounter;

        // The max number of messages to buffere.
        private int maxMsgNumber;

        // The message buffer.
        private System.Collections.Generic.Queue
            <WebBaseEvent> msgBuffer = 
            new Queue<WebBaseEvent>();

        // <Snippet2>
        // Initializes the provider.
        public SampleEventProvider(): base()
        {

            // Initialize the local path of the file 
            // that holds event information.
            logFilePath = "C:/test/log.doc";

            // Clear the message buffer.
            msgBuffer.Clear();

            // Initialize the max number of messages
            // to buffer.
            maxMsgNumber = 10;

            // More custom initialization goes here.

        }
        // </Snippet2>


        // <Snippet3>
        // Flush the input buffer if required.
        public override void Flush()
        {
            // Create a string builder to 
            // hold the event information.
            StringBuilder reData = new StringBuilder();

            // Store custom information.
            reData.Append("SampleEventProvider processing." +
                Environment.NewLine);
            reData.Append("Flush done at: {0}" +
                DateTime.Now.TimeOfDay.ToString() +
                Environment.NewLine);
            
            foreach (WebBaseEvent e in msgBuffer)
            {
                // Store event data.
                reData.Append(e.ToString());
            }

            // Store the information in the specified file.
            StoreToFile(reData, logFilePath, FileMode.Append);

            // Reset the message counter.
            msgCounter = 0;
            
            // Clear the buffer.
            msgBuffer.Clear();

        }
        // </Snippet3>

        // <Snippet4>

        // Shutdown the provider.
        public override void Shutdown()
        {
            Flush();
        }
        // </Snippet4>

        // <Snippet5>

        // Process the event that has been raised.
        public override void ProcessEvent(WebBaseEvent raisedEvent)
        { 
            if (msgCounter < maxMsgNumber)
            {
                // Buffer the event information.
                msgBuffer.Enqueue(raisedEvent);
                // Increment the message counter.
                msgCounter += 1;
            }
            else
            {
                // Flush the buffer.
                Flush();
            }
        }

        // </Snippet5>

        // <Snippet6>

        // Store event information in a local file.
        private void StoreToFile(StringBuilder text, 
            string filePath, FileMode mode)
        {
            int writeBlock;
            int startIndex;

            try
            {

                writeBlock = 256;
                startIndex = 0;

                // Open or create the local file 
                // to store the event information.
                FileStream fs = new FileStream(filePath, 
                    mode, FileAccess.Write);

                // Lock the file for writing.
                fs.Lock(startIndex, writeBlock);

                // Create a stream writer
                StreamWriter writer = new StreamWriter(fs);

                // Set the file pointer to the current 
                // position to keep adding data to it. 
                // If you want to rewrite the file use 
                // the following statement instead.
                // writer.BaseStream.Seek (0, SeekOrigin.Begin);
                writer.BaseStream.Seek(0, SeekOrigin.Current);

                //If the file already exists it must not 
                // be write protected otherwise  
                // the following write operation fails silently.
                writer.Write(text.ToString());

                // Update the underlying file
                writer.Flush();

                // Unlock the file for other processes.
                fs.Unlock(startIndex, writeBlock);

                // Close the stream writer and the underlying file     
                writer.Close();

                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception(
                    "SampleEventProvider.StoreToFile: " 
                    + e.ToString());
            }
        }
        // </Snippet6>

    }

}

// </Snippet1>
