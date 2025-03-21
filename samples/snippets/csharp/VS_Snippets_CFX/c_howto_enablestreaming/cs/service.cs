
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet1>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IStreamingSample
    {
        [OperationContract]
        Stream GetStream(string data);
        [OperationContract]
        bool UploadStream(Stream stream);
        [OperationContract]
        Stream EchoStream(Stream stream);
        [OperationContract]
        Stream GetReversedStream();
    }
    //</snippet1>

    // Service class which implements the service contract
    public class StreamingService : IStreamingSample
    {
        //<snippet4>
        public Stream GetStream(string data)
        {
            //this file path assumes the image is in
            // the Service folder and the service is executing
            // in service/bin
            string filePath = Path.Combine(
                System.Environment.CurrentDirectory,
                ".\\..\\image.jpg");
            //open the file, this could throw an exception
            //(e.g. if the file is not found)
            //having includeExceptionDetailInFaults="True" in config
            // would cause this exception to be returned to the client
            try
            {
                FileStream imageFile = File.OpenRead(filePath);
                return imageFile;
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    String.Format("An exception was thrown while trying to open file {0}", filePath));
                Console.WriteLine("Exception is: ");
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
        //</snippet4>

        public bool UploadStream(Stream stream)
        {
            //this implementation places the uploaded file
            //in the current directory and calls it "uploadedfile"
            //with no file extension
            string filePath = Path.Combine(
                System.Environment.CurrentDirectory,
                "uploadedfile");
            try
            {
                Console.WriteLine($"Saving to file {filePath}");
                FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write);
                //read from the input stream in 4K chunks
                //and save to output stream
                const int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = stream.Read(buffer, 0, bufferLen)) > 0)
                {
                    Console.Write(".");
                    outstream.Write(buffer, 0, count);
                }
                outstream.Close();
                stream.Close();
                Console.WriteLine();
                Console.WriteLine($"File {filePath} saved");

                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    String.Format("An exception was thrown while opening or writing to file {0}", filePath));
                Console.WriteLine("Exception is: ");
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public Stream EchoStream(Stream stream)
        {
            //this implementation places the uploaded file
            //in the current directory and calls it "echofile"
            //with no file extension
            string filePath = Path.Combine(
                System.Environment.CurrentDirectory,
                "echofile");
            try
            {
                FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write);
                //copy the input stream to the output file
                this.CopyStream(stream, outstream);
                outstream.Close();
                stream.Close();

                //now open the file for reading
                //and return the stream
                FileStream echoFile = File.OpenRead(filePath);
                return echoFile;
            }
            catch (IOException ex)
            {
                Console.WriteLine(
                    String.Format("An exception was thrown while opening or writing to file {0}", filePath));
                Console.WriteLine("Exception is: ");
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public Stream GetReversedStream()
        {
            //this file path assumes the image is in
            // the Service folder and the service is executing
            // in Service/bin
            string filePath = Path.Combine(
                System.Environment.CurrentDirectory,
                ".\\..\\image.jpg");

            ReverseStream stream = new ReverseStream(filePath);
            return stream;
        }

        void CopyStream(Stream instream, Stream outstream)
        {
            //read from the input stream in 4K chunks
            //and save to output stream
            const int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int count = 0;
            while ((count = instream.Read(buffer, 0, bufferLen)) > 0)
            {
                outstream.Write(buffer, 0, count);
            }
        }
    }
    //<snippet2>
    class ReverseStream : Stream
    {

        FileStream inStream;
        internal ReverseStream(string filePath)
        {
            //opens the file and places a StreamReader around it
            inStream = File.OpenRead(filePath);
        }
        public override bool CanRead
        {
            get { return inStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            throw new Exception("This stream does not support writing.");
        }

        public override long Length
        {
            get { throw new Exception("This stream does not support the Length property."); }
        }

        public override long Position
        {
            get
            {
                return inStream.Position;
            }
            set
            {
                throw new Exception("This stream does not support setting the Position property.");
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int countRead = inStream.Read(buffer, offset, count);
            ReverseBuffer(buffer, offset, countRead);
            return countRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new Exception("This stream does not support seeking.");
        }

        public override void SetLength(long value)
        {
            throw new Exception("This stream does not support setting the Length.");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("This stream does not support writing.");
        }
        public override void Close()
        {
            inStream.Close();
            base.Close();
        }
        protected override void Dispose(bool disposing)
        {
            inStream.Dispose();
            base.Dispose(disposing);
        }
        void ReverseBuffer(byte[] buffer, int offset, int count)
        {

            int i, j;

            for (i = offset, j = offset + count - 1; i < j; i++, j--)
            {
                byte currenti = buffer[i];
                buffer[i] = buffer[j];
                buffer[j] = currenti;
            }
        }
    }
    //</snippet2>
}
