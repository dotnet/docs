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