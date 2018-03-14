' <Snippet1>
Class MyGCCollectClass
     Private Const maxGarbage As Integer = 1000

     Shared Sub Main()
         'Put some objects in memory.
         MyGCCollectClass.MakeSomeGarbage()
         Console.WriteLine("Memory used before collection:       {0:N0}", 
                           GC.GetTotalMemory(False))

         'Collect all generations of memory.
         GC.Collect()
         Console.WriteLine("Memory used after full collection:   {0:N0}", 
                           GC.GetTotalMemory(True))
     End Sub

     Shared Sub MakeSomeGarbage()
         Dim vt As Version

         Dim i As Integer
         For i = 0 To maxGarbage - 1
             'Create objects and release them to fill up memory with unused objects.
             vt = New Version()
         Next 
     End Sub
 End Class
' The output from the example resembles the following:
'       Memory used before collection:       79,392
'       Memory used after full collection:   52,640
' </Snippet1>