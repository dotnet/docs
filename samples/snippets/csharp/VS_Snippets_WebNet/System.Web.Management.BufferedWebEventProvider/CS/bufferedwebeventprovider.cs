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


 namespace Samples.AspNet.Management
 {
    // Implements a custom event provider.
    public class SampleBufferedWebEventProvider :
        BufferedWebEventProvider
    {

        // The local path of the file where
        // to store event information.
        private string logFilePath = string.Empty;

        // Holds custom information.
        private StringBuilder customInfo;

        private FileStream fs;

        private string providerName, 
            buffer, bufferModality;

        // <Snippet8>
        public SampleBufferedWebEventProvider()
        {
            // Perform local initializations.

            // Path of local file where to store 
            // event info.
            // Assure that the path works for you and
            // that the right permissions are set.
            logFilePath = "C:/test/log.doc";
            
            // Instantiate buffer to contain 
            // local data.
            customInfo = new StringBuilder();

        }

        // </Snippet8>

        // <Snippet9>
        public override void  Flush()
        {
            customInfo.AppendLine("Perform custom flush");
            StoreToFile(customInfo, logFilePath, FileMode.Append);
        }
        // </Snippet9>


        // <Snippet2>
        // Initializes the provider.
        public override void Initialize(string name,
         NameValueCollection config)
        {
            base.Initialize(name, config);

            // Get the configuration information.
            providerName = name;
            buffer = SampleUseBuffering.ToString();
            bufferModality = SampleBufferMode;

            customInfo.AppendLine(string.Format(
                "Provider name: {0}", providerName));
            customInfo.AppendLine(string.Format(
                "Buffering: {0}", buffer));
            customInfo.AppendLine(string.Format(
                "Buffering modality: {0}", bufferModality));

        }
        // </Snippet2>

        // <Snippet3>
        public bool SampleUseBuffering
        {
            get { return UseBuffering; }
        }
        // </Snippet3>

        // <Snippet4>
        public string SampleBufferMode
        {
            get { return BufferMode; }
        }
        // </Snippet4>

        // <Snippet5>

        // Processes the incoming events.
        // This method performs custom processing and, 
        // if buffering is enabled, it calls the 
        // base.ProcessEvent to buffer the event
        // information.
        public override void ProcessEvent(
            WebBaseEvent eventRaised)
        {

            if (UseBuffering)
                // Buffering enabled, call the 
                // base event to buffer event information.
                base.ProcessEvent(eventRaised);
            else
            {
                // Buffering disabled, store the 
                // current event now.
                customInfo.AppendLine(
                    "*** Buffering disabled ***");
                customInfo.AppendLine(
                    eventRaised.ToString());
                // Store the information in the specified file.
                StoreToFile(customInfo, 
                    logFilePath, FileMode.Append);
            }
        }
        // </Snippet5>

        //<Snippet11>
        private WebBaseEventCollection GetEvents(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.Events;
        }

        //</Snippet11>

        //<Snippet12>
        private int GetEventsDiscardedSinceLastNotification(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.EventsDiscardedSinceLastNotification;
        }

        //</Snippet12>

        //<Snippet13>
        private int GetEventsInBuffer(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.EventsInBuffer;
        }

        //</Snippet13>

        //<Snippet14>
        private DateTime GetLastNotificationTime(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.LastNotificationUtc;
        }

        //</Snippet14>
        
        //<Snippet15>
        private int GetNotificationSequence(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.NotificationSequence;
        }

        //</Snippet15>

        //<Snippet16>
        private EventNotificationType GetNotificationType(
            WebEventBufferFlushInfo flushInfo)
        {
            return flushInfo.NotificationType;
        }

        //</Snippet16>

        // <Snippet6>

        // Processes the messages that have been buffered.
        // It is called by the ASP.NET when the flushing of 
        // the buffer is required.
        public override void ProcessEventFlush(
            WebEventBufferFlushInfo flushInfo)
        {

            // Customize event information to be sent to 
            // the Windows Event Viewer Application Log.
            customInfo.AppendLine(
                "SampleEventLogWebEventProvider buffer flush.");

            customInfo.AppendLine(
                string.Format("NotificationType: {0}",
                GetNotificationType(flushInfo)));

            customInfo.AppendLine(
                string.Format("EventsInBuffer: {0}",
                GetEventsInBuffer(flushInfo)));

            customInfo.AppendLine(
                string.Format(
                "EventsDiscardedSinceLastNotification: {0}",
                GetEventsDiscardedSinceLastNotification(flushInfo)));

           
            // Read each buffered event and send it to the
            // Application Log.
            foreach (WebBaseEvent eventRaised in flushInfo.Events)
                customInfo.AppendLine(eventRaised.ToString());

            // Store the information in the specified file.
            StoreToFile(customInfo, logFilePath, FileMode.Append);
        }
        // </Snippet6>

        // <Snippet7>
        // Performs standard shutdown.
        public override void Shutdown()
        {
            // Here you need the code that performs
            // those tasks required before shutting 
            // down the provider.

            // Flush the buffer, if needed.
            Flush();
            
        }
        // </Snippet7>

        // <Snippet10>
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
                fs = new FileStream(filePath,
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
                // Use this for debugging.
                // Never dispaly it!
                string ex = e.ToString();
                throw new Exception(
                    "[SampleEventProvider] StoreToFile: exception." );
            }
        }
        // </Snippet10>

    }

}

// </Snippet1>
