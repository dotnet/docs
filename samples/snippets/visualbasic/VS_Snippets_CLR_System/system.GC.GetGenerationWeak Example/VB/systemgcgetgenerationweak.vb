'<snippet1>
Imports System

Namespace GCGetGenerationWeakExample

   Class MyGCCollectClass
      Private maxGarbage As Long = 1000

      Public Shared Sub Main()
         ' Create a strong reference to an object.
         Dim myGCCol As New MyGCCollectClass

         ' Put some objects in memory.
         myGCCol.MakeSomeGarbage()

         ' Get the generation of managed memory where myGCCol is stored.
         Console.WriteLine("The object is in generation: {0}", _
                            GC.GetGeneration(myGCCol))

         ' Perform a full garbage collection.
         ' Because there is a strong reference to myGCCol, it will
         ' not be garbage collected.
         GC.Collect()

         ' Get the generation of managed memory where myGCCol is stored.
         Console.WriteLine("The object is in generation: {0}", _
                            GC.GetGeneration(myGCCol))

         ' Create a WeakReference to myGCCol.
         Dim wkref As New WeakReference(myGCCol)
         ' Remove the strong reference to myGCCol.
         myGCCol = Nothing

         ' Get the generation of managed memory where wkref is stored.
         Console.WriteLine("The WeakReference to the object is in generation: {0}", _
                           GC.GetGeneration(wkref))

         ' Perform another full garbage collection.
         ' A WeakReference will not survive a garbage collection.
         GC.Collect()

         ' Try to get the generation of managed memory where wkref is stored.
         ' Because it has been collected, an exception will be thrown.
         Try
            Console.WriteLine("The WeakReference to the object is in generation: {0}", _
                               GC.GetGeneration(wkref))
            Console.Read()
         Catch e As Exception
            Console.WriteLine("The WeakReference to the object " & _
                              "has been garbage collected: '{0}'", e)
            Console.Read()
         End Try
      End Sub


      Sub MakeSomeGarbage()
         Dim vt As Version

         Dim i As Integer
         For i = 0 To maxGarbage - 1
            ' Create objects and release them to fill up memory
            ' with unused objects.
            vt = New Version
         Next i
      End Sub
   End Class
End Namespace
'</snippet1>