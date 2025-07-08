Imports System.IO
Imports System.Reflection

Public Module Example2

    Public Sub Main(args() As String)
        Console.WriteLine($"Current directory is '{Environment.CurrentDirectory}'")
        Console.WriteLine("Setting current directory to 'C:\'")
        Directory.SetCurrentDirectory("C:\")

        Dim filePath As String = Path.GetFullPath("D:\FY2018")
        Console.WriteLine($"'D:\\FY2018' resolves to {filePath}")
        filePath = Path.GetFullPath("D:FY2018")
        Console.WriteLine($"'D:FY2018' resolves to {filePath}")

        Console.WriteLine("Setting current directory to 'D:\\Docs'")
        Directory.SetCurrentDirectory("D:\Docs")

        filePath = Path.GetFullPath("D:\FY2018")
        Console.WriteLine($"'D:\\FY2018' resolves to {filePath}")
        filePath = Path.GetFullPath("D:FY2018")

        ' This will be "D:\Docs\FY2018" as it happens to match the drive of the current directory
        Console.WriteLine($"'D:FY2018' resolves to {filePath}")

        Console.WriteLine("Setting current directory to 'C:\\'")
        Directory.SetCurrentDirectory("C:\")

        filePath = Path.GetFullPath("D:\FY2018")
        Console.WriteLine($"'D:\\FY2018' resolves to {filePath}")

        ' This will be either "D:\FY2018" or "D:\FY2018\FY2018" in the subprocess. In the sub process,
        ' the command prompt set the current directory before launch of our application, which
        ' sets a hidden environment variable that is considered.
        filePath = Path.GetFullPath("D:FY2018")
        Console.WriteLine($"'D:FY2018' resolves to {filePath}")

        If args.Length < 1 Then
            Console.WriteLine("Launching again, after setting current directory to D:\FY2018")
            Dim currentExe As New Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute)
            Dim commandLine As String = $"/C cd D:\FY2018 & ""{currentExe.LocalPath}"" stop"
            Dim psi As New ProcessStartInfo("cmd", commandLine)
            Process.Start(psi).WaitForExit()

            Console.WriteLine("Sub process returned:")
            filePath = Path.GetFullPath("D:\FY2018")
            Console.WriteLine($"'D:\\FY2018' resolves to {filePath}")
            filePath = Path.GetFullPath("D:FY2018")
            Console.WriteLine($"'D:FY2018' resolves to {filePath}")
        End If
        Console.WriteLine("Press any key to continue... ")
        Console.ReadKey()
    End Sub
End Module
' The example displays the following output:
'      Current directory is 'C:\Programs\file-paths'
'      Setting current directory to 'C:\'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to d:\FY2018
'      Setting current directory to 'D:\Docs'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to D:\Docs\FY2018
'      Setting current directory to 'C:\'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to d:\FY2018
'      Launching again, after setting current directory to D:\FY2018
'      Sub process returned:
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to d:\FY2018
' The subprocess displays the following output:
'      Current directory is 'C:\'
'      Setting current directory to 'C:\'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to D:\FY2018\FY2018
'      Setting current directory to 'D:\Docs'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to D:\Docs\FY2018
'      Setting current directory to 'C:\'
'      'D:\FY2018' resolves to D:\FY2018
'      'D:FY2018' resolves to D:\FY2018\FY2018
