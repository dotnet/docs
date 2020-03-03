' <Snippet1>
Option Strict
Option Explicit

Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        
        Dim myNewLog As New EventLog()
        myNewLog.Log = "MyCustomLog"
        
        AddHandler myNewLog.EntryWritten, AddressOf MyOnEntryWritten
        myNewLog.EnableRaisingEvents = True
        
        
        Console.WriteLine("Press 'q' to quit.")
        ' Wait for the EntryWrittenEvent or a quit command.
        While Char.ToLower(Convert.ToChar(Console.Read()))<>"q"
            ' Wait.
        End While 
    End Sub
    
    Public Shared Sub MyOnEntryWritten(source As Object, e As EntryWrittenEventArgs)
        Console.WriteLine(("Written: " + e.Entry.Message))
    End Sub
End Class
' </Snippet1>