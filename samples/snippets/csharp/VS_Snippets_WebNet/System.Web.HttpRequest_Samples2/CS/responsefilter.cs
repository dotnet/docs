// <snippet2>

using System;
using System.IO;
using System.Text;

namespace Samples.AspNet.CS.Controls
{

   public class UpperCaseFilterStream : Stream
   // This filter changes all characters passed through it to uppercase.
   {
      private Stream strSink;
      private long lngPosition;

      public UpperCaseFilterStream(Stream sink)
      {
          strSink = sink;
      }

      // The following members of Stream must be overriden.
      public override bool CanRead
      {
         get { return true; }
      }

      public override bool CanSeek
      {
         get { return true; }
      }

      public override bool CanWrite
      {
         get { return true; }
      }

      public override long Length
      {
         get { return 0; }
      }

      public override long Position
      {
         get { return lngPosition; }
         set { lngPosition = value; }
      }

      public override long Seek(long offset, System.IO.SeekOrigin direction)
      {
         return strSink.Seek(offset, direction);
      }

      public override void SetLength(long length)
      {
         strSink.SetLength(length);
      }

      public override void Close()
      {
         strSink.Close();
      }

      public override void Flush()
      {
         strSink.Flush();
      }

      public override int Read(byte[] buffer, int offset, int count)
      {
         return strSink.Read(buffer, offset, count);
      }

      // The Write method actually does the filtering.
      public override void Write(byte[] buffer, int offset, int count)
      {
		 byte[] data = new byte[count];
	     Buffer.BlockCopy(buffer, offset, data, 0, count);
		 string inputstring = Encoding.ASCII.GetString(data).ToUpper();
		 data = Encoding.ASCII.GetBytes(inputstring);
	     strSink.Write(data, 0, count);
       
      }
   }
}
// </snippet2>