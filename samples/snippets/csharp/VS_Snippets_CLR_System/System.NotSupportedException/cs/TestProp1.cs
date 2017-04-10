// <Snippet3>
using System;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      String name = @".\TestFile.dat";
      var fs = new FileStream(name, 
                              FileMode.Create,
                              FileAccess.Write);
         Console.WriteLine("Filename: {0}, Encoding: {1}", 
                           name, FileUtilities.GetEncodingType(fs));
   }
}

public class FileUtilities
{
   public enum EncodingType
   { None = 0, Unknown = -1, Utf8 = 1, Utf16 = 2, Utf32 = 3 }
   
   public static EncodingType GetEncodingType(FileStream fs)
   {
      Byte[] bytes = new Byte[4];
      var t = fs.ReadAsync(bytes, 0, 4);
      t.Wait();
      int bytesRead = t.Result;
      if (bytesRead < 2)
         return EncodingType.None;
      
      if (bytesRead >= 3 & (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF))
         return EncodingType.Utf8;
      
      if (bytesRead == 4) { 
         var value = BitConverter.ToUInt32(bytes, 0);
         if (value == 0x0000FEFF | value == 0xFEFF0000)
            return EncodingType.Utf32;
      }
      
      var value16 = BitConverter.ToUInt16(bytes, 0);
      if (value16 == (ushort)0xFEFF | value16 == (ushort)0xFFFE) 
         return EncodingType.Utf16;
      
      return EncodingType.Unknown;
   }
}
// The example displays the following output:
//    Unhandled Exception: System.NotSupportedException: Stream does not support reading.
//       at System.IO.Stream.BeginReadInternal(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state,
//     Boolean serializeAsynchronously)
//       at System.IO.FileStream.BeginRead(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object stat
//    eObject)
//       at System.IO.Stream.<>c.<BeginEndReadAsync>b__43_0(Stream stream, ReadWriteParameters args, AsyncCallback callback, O
//    bject state)
//       at System.Threading.Tasks.TaskFactory`1.FromAsyncTrim[TInstance,TArgs](TInstance thisRef, TArgs args, Func`5 beginMet
//    hod, Func`3 endMethod)
//       at System.IO.Stream.BeginEndReadAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at System.IO.FileStream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
//       at System.IO.Stream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at FileUtilities.GetEncodingType(FileStream fs)
//       at Example.Main()
// </Snippet3>

