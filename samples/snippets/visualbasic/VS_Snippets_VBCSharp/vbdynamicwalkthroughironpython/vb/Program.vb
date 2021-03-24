'<Snippet1>
Imports Microsoft.Scripting.Hosting
Imports IronPython.Hosting
Imports System.Linq
'</Snippet1>

Module Module1

    Sub Main()
        '<Snippet2>
        ' Set the current directory to the IronPython libraries.
        System.IO.Directory.SetCurrentDirectory(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) &
               "\IronPython 2.7\Lib")

        ' Create an instance of the random.py IronPython library.
        Console.WriteLine("Loading random.py")
        Dim py = Python.CreateRuntime()
        Dim random As Object = py.UseFile("random.py")
        Console.WriteLine("random.py loaded.")
        '</Snippet2>

        '<Snippet3>
        ' Initialize an enumerable set of integers.
        Dim items = Enumerable.Range(1, 7).ToArray()

        ' Randomly shuffle the array of integers by using IronPython.
        For i = 0 To 4
            random.shuffle(items)
            For Each item In items
                Console.WriteLine(item)
            Next
            Console.WriteLine("-------------------")
        Next
        '</Snippet3>
    End Sub

End Module