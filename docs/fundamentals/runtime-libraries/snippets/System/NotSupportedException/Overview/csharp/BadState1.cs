// <Snippet1>
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class Example
{
    public static async Task Main()
    {
        Encoding enc = Encoding.Unicode;
        String value = "This is a string to persist.";
        Byte[] bytes = enc.GetBytes(value);

        FileStream fs = new FileStream(@".\TestFile.dat",
                                       FileMode.Open,
                                       FileAccess.Read);
        Task t = fs.WriteAsync(enc.GetPreamble(), 0, enc.GetPreamble().Length);
        Task t2 = t.ContinueWith((a) => fs.WriteAsync(bytes, 0, bytes.Length));
        await t2;
        fs.Close();
    }
}
// The example displays the following output:
//    Unhandled Exception: System.NotSupportedException: Stream does not support writing.
//       at System.IO.Stream.BeginWriteInternal(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state
//    , Boolean serializeAsynchronously)
//       at System.IO.FileStream.BeginWrite(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object sta
//    teObject)
//       at System.IO.Stream.<>c.<BeginEndWriteAsync>b__53_0(Stream stream, ReadWriteParameters args, AsyncCallback callback,
//    Object state)
//       at System.Threading.Tasks.TaskFactory`1.FromAsyncTrim[TInstance,TArgs](TInstance thisRef, TArgs args, Func`5 beginMet
//    hod, Func`3 endMethod)
//       at System.IO.Stream.BeginEndWriteAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at System.IO.FileStream.WriteAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
//       at System.IO.Stream.WriteAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at Example.Main()
// </Snippet1>
