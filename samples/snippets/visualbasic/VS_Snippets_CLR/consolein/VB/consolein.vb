'<snippet1>
Imports System
Imports System.IO

Class InTest
    
    Public Shared Sub Main()
        Dim tIn As TextReader = Console.In
        Dim tOut As TextWriter = Console.Out
        
        
        tOut.WriteLine("Hola Mundo!")
        tOut.Write("What is your name: ")
        Dim name As [String] = tIn.ReadLine()
        
        tOut.WriteLine("Buenos Dias, {0}!", name)
    End Sub 'Main
End Class 'InTest
'</snippet1>