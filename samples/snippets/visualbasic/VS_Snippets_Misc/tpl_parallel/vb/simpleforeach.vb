'<snippet03>
' How to: Write a Simple Parallel.ForEach Loop
' IMPORTANT!!!: Add reference to System.Drawing.dll
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Drawing

Module ForEachDemo

    Sub Main()
        ' A simple source for demonstration purposes. Modify this path as necessary.
        Dim files As String() = System.IO.Directory.GetFiles("C:\Users\Public\Pictures\Sample Pictures", "*.jpg")
        Dim newDir As String = "C:\Users\Public\Pictures\Sample Pictures\Modified"
        System.IO.Directory.CreateDirectory(newDir)

        ' Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
        ' Be sure to add a reference to System.Drawing.dll.
        Parallel.ForEach(files, Sub(currentFile)
                                    ' The more computational work you do here, the greater 
                                    ' the speedup compared to a sequential foreach loop.
                                    Dim filename As String = System.IO.Path.GetFileName(currentFile)
                                    Dim bitmap As New System.Drawing.Bitmap(currentFile)

                                    bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
                                    bitmap.Save(System.IO.Path.Combine(newDir, filename))

                                    ' Peek behind the scenes to see how work is parallelized.
                                    ' But be aware: Thread contention for the Console slows down parallel loops!!!

                                    Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId)
                                    'close lambda expression and method invocation
                                End Sub)


        ' Keep the console window open in debug mode.
        Console.WriteLine("Processing complete. Press any key to exit.")
        Console.ReadKey()
    End Sub
End Module
'</snippet03>