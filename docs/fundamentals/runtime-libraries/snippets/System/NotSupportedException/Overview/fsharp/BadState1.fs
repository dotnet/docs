module BadState

// <Snippet1>
open System.IO
open System.Text

let main = task {
    let enc = Encoding.Unicode
    let value = "This is a string to persist."
    let bytes  = enc.GetBytes value

    let fs = new FileStream(@".\TestFile.dat", FileMode.Open, FileAccess.Read)
    let t = fs.WriteAsync(enc.GetPreamble(), 0, enc.GetPreamble().Length)
    let t2 = t.ContinueWith(fun a -> fs.WriteAsync(bytes, 0, bytes.Length))
    let! _ = t2
    fs.Close()
}
main.Wait()

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
//       at <StartupCode:fs>.main()
// </Snippet1>