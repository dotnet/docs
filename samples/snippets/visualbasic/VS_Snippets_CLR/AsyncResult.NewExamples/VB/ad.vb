' <Snippet1>
Imports System
Imports System.Threading
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Contexts
Imports System.Runtime.Remoting.Messaging


' <Snippet2>
' Context-bound type with the Synchronization context attribute.
<Synchronization()> Public Class SampleSynchronized
   Inherits ContextBoundObject
   
   ' A method that does some work, and returns the square of the given number.
   Public Function Square(i As Integer) As Integer
      
      Console.Write("The hash of the thread executing ")
      Console.WriteLine("SampleSynchronized.Square is: {0}", Thread.CurrentThread.GetHashCode())
      Return i * i
   End Function 

End Class 
' </Snippet2>

' The async delegate used to call a method with this signature asynchronously.
Delegate Function SampSyncSqrDelegate(i As Integer) As Integer


Public Class AsyncResultSample
   
   ' <Snippet4>
   ' Asynchronous Callback method.
   Public Shared Sub MyCallback(ar As IAsyncResult)
      ' Obtains the last parameter of the delegate call.
      Dim value As Integer = Convert.ToInt32(ar.AsyncState)
      
      ' Obtains return value from the delegate call using EndInvoke.
      Dim aResult As AsyncResult = CType(ar, AsyncResult)
      Dim temp As SampSyncSqrDelegate = CType(aResult.AsyncDelegate, SampSyncSqrDelegate)
      Dim result As Integer = temp.EndInvoke(ar)
      
      Console.Write("Simple.SomeMethod (AsyncCallback): Result of ")
      Console.WriteLine("{0} in SampleSynchronized.Square is {1} ", value, result)
   End Sub 
   ' </Snippet4>

   Public Shared Sub Main()
      
      Dim result As Integer
      Dim param As Integer
      
      ' <Snippet6>
      ' Creates an instance of a context-bound type SampleSynchronized.
      Dim sampSyncObj As New SampleSynchronized()
      
      ' Checks whether the object is a proxy, since it is context-bound.
      If RemotingServices.IsTransparentProxy(sampSyncObj) Then
         Console.WriteLine("sampSyncObj is a proxy.")
      Else
         Console.WriteLine("sampSyncObj is NOT a proxy.")
      End If 
      ' </Snippet6>

      ' <Snippet7>
      param = 10
      
      Console.WriteLine("")
      Console.WriteLine("Making a synchronous call on the context-bound object:")
      
      result = sampSyncObj.Square(param)
      Console.Write("The result of calling sampSyncObj.Square with ")
      Console.WriteLine("{0} is {1}.", param, result)
      Console.WriteLine("")     
      ' </Snippet7>

      ' <Snippet8>
      Dim sampleDelegate As New SampSyncSqrDelegate(AddressOf sampSyncObj.Square)
      param = 8
      
      Console.WriteLine("Making a single asynchronous call on the context-bound object:")
      
      Dim ar1 As IAsyncResult = sampleDelegate.BeginInvoke(param, New AsyncCallback(AddressOf AsyncResultSample.MyCallback), param)
      
      Console.WriteLine("Waiting for the asynchronous call to complete...")
      Dim wh As WaitHandle = ar1.AsyncWaitHandle
      wh.WaitOne()

      wh.Close()
      
      Console.WriteLine("")
      Console.WriteLine("Waiting for the AsyncCallback to complete...")
      ' Note that normally, a callback and a wait handle would not 
      ' both be used on the same asynchronous call. Callbacks are
      ' useful in cases where the original thread does not need to
      ' be synchronized with the result of the call, and in that
      ' scenario they provide a place to call EndInvoke. Sleep is
      ' used here because the callback is on a ThreadPool thread.
      ' ThreadPool threads are background threads, and will not keep
      ' a process running when the main thread ends.
      Thread.Sleep(1000)
      ' </Snippet8>
   End Sub 
End Class 

' This example produces output similar to the following:
'
'sampSyncObj is a proxy.
'
'Making a synchronous call on the context-bound object:
'The hash of the thread executing SampleSynchronized.Square is: 1
'The result of calling sampSyncObj.Square with 10 is 100.
'
'Making a single asynchronous call on the context-bound object:
'Waiting for the asynchronous call to complete...
'The hash of the thread executing SampleSynchronized.Square is: 6
'
'Waiting for the AsyncCallback to complete...
'Simple.SomeMethod (AsyncCallback): Result of 8 in SampleSynchronized.Square is 64
' </Snippet1>