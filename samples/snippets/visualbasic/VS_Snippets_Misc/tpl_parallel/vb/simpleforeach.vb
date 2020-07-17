'<snippet03>
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Drawing

Module ForEachDemo

    Sub Main()
        ' A simple source for demonstration purposes. Modify this path as necessary.
        Dim files As String() = Directory.GetFiles("C:\Users\Public\Pictures\Sample Pictures", "*.jpg")
        Dim newDir As String = "C:\Users\Public\Pictures\Sample Pictures\Modified"
        Directory.CreateDirectory(newDir)

        Parallel.ForEach(files, Sub(currentFile)
                                    ' The more computational work you do here, the greater 
                                    ' the speedup compared to a sequential foreach loop.
                                    Dim filename As String = Path.GetFileName(currentFile)
                                    Dim bitmap As New Bitmap(currentFile)

                                    bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
                                    bitmap.Save(Path.Combine(newDir, filename))

                                    ' Peek behind the scenes to see how work is parallelized.
                                    ' But be aware: Thread contention for the Console slows down parallel loops!!!

                                    Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}")
                                    'close lambda expression and method invocation
                                End Sub)


        ' Keep the console window open in debug mode.
        Console.WriteLine("Processing complete. Press any key to exit.")
        Console.ReadKey()
    End Sub
End Module
'</snippet03>
