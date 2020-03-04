' System.Diagnostics.ProcessModule

' The following program demonstrates the use of 'ProcessModule' class. 
' It creates a notepad, gets the 'MainModule' and all other modules of 
' the process 'notepad.exe', displays some of the properties of each modules.

Imports System.Diagnostics

Class MyProcessModuleClass

    Public Shared Sub Main()
        Try
            ' <Snippet1>
            Using myProcess As New Process()
                ' Get the process start information of notepad.
                Dim myProcessStartInfo As New ProcessStartInfo("notepad.exe")
                ' Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
                myProcess.StartInfo = myProcessStartInfo
                ' Create a notepad.
                myProcess.Start()
                System.Threading.Thread.Sleep(1000)
                Dim myProcessModule As ProcessModule
                ' Get all the modules associated with 'myProcess'.
                Dim myProcessModuleCollection As ProcessModuleCollection = myProcess.Modules
                Console.WriteLine("Properties of the modules  associated with 'notepad' are:")
                ' Display the properties of each of the modules.
                Dim i As Integer
                For i = 0 To myProcessModuleCollection.Count - 1
                    myProcessModule = myProcessModuleCollection(i)
                    Console.WriteLine("The moduleName is " + myProcessModule.ModuleName)
                    Console.WriteLine("The " + myProcessModule.ModuleName.ToString() +
                               "'s base address is: " + myProcessModule.BaseAddress.ToString())
                    Console.WriteLine("The " + myProcessModule.ModuleName.ToString() +
                            "'s Entry point address is: " + myProcessModule.EntryPointAddress.ToString())
                    Console.WriteLine("The " + myProcessModule.ModuleName +
                                            "'s File name is: " + myProcessModule.FileName)
                Next i
                ' Get the main module associated with 'myProcess'.
                myProcessModule = myProcess.MainModule
                ' Display the properties of the main module.
                Console.WriteLine("The process's main moduleName is:  " + myProcessModule.ModuleName)
                Console.WriteLine("The process's main module's base address is: " +
                                        myProcessModule.BaseAddress.ToString())
                Console.WriteLine("The process's main module's Entry point address is: " +
                                        myProcessModule.EntryPointAddress.ToString())
                Console.WriteLine("The process's main module's File name is: " +
                                        myProcessModule.FileName)
                myProcess.CloseMainWindow()
            End Using
            ' </Snippet1>
        Catch e As Exception
            Console.WriteLine($"Exception : {e.Message}")
        End Try
    End Sub
End Class
