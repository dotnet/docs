' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim enc As Encoding = Encoding.Unicode
      Dim value As String = "This is a string to persist."
      Dim bytes() As Byte = enc.GetBytes(value)

      Dim fs As New FileStream(".\TestFile.dat", 
                               FileMode.Open,
                               FileAccess.Read)
      Dim t As Task = fs.WriteAsync(enc.GetPreamble(), 0, enc.GetPreamble().Length)
      Dim t2 As Task = t.ContinueWith(Sub(a) fs.WriteAsync(bytes, 0, bytes.Length)) 
      t2.Wait()
      fs.Close()
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.NotSupportedException: Stream does not support writing.
'       at System.IO.Stream.BeginWriteInternal(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state
'    , Boolean serializeAsynchronously)
'       at System.IO.FileStream.BeginWrite(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object sta
'    teObject)
'       at System.IO.Stream.<>c.<BeginEndWriteAsync>b__53_0(Stream stream, ReadWriteParameters args, AsyncCallback callback,
'    Object state)
'       at System.Threading.Tasks.TaskFactory`1.FromAsyncTrim[TInstance,TArgs](TInstance thisRef, TArgs args, Func`5 beginMet
'    hod, Func`3 endMethod)
'       at System.IO.Stream.BeginEndWriteAsync(Byte[] buffer, Int32 offset, Int32 count)
'       at System.IO.FileStream.WriteAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
'       at System.IO.Stream.WriteAsync(Byte[] buffer, Int32 offset, Int32 count)
'       at Example.Main()
' </Snippet1>
