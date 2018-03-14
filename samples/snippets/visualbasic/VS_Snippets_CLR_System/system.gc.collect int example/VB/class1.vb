'<snippet1>
Imports System

Namespace GCCollectInt_Example
    Class MyGCCollectClass
        Private maxGarbage As Long = 10000

        Public Shared Sub Main()
            Dim myGCCol As New MyGCCollectClass

            'Determine the maximum number of generations the system
            'garbage collector currently supports.
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration)

            myGCCol.MakeSomeGarbage()

            'Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol))

            'Determine the best available approximation of the number 
            'of bytes currently allocated in managed memory.
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(False))

            'Perform a collection of generation 0 only.
            GC.Collect(0)

            'Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol))

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(False))

            'Perform a collection of all generations up to and including 2.
            GC.Collect(2)

            'Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol))
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(False))
            Console.Read()

        End Sub


        Sub MakeSomeGarbage()
            Dim vt As Version

            Dim i As Integer
            For i = 0 To maxGarbage - 1
                'Create objects and release them to fill up memory
                'with unused objects.
                vt = New Version
            Next i
        End Sub
    End Class
End Namespace
'</snippet1>