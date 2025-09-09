Imports System

Public Class DocumentProcessor
    ' Standard .NET event using EventHandler
    Public Event DocumentProcessed As EventHandler
    
    ' Custom event with different signature
    Public Event StatusChanged As Action(Of String)
    
    ' Handlers with different signatures
    
    ' Exact match for EventHandler - no warning
    Private Sub OnDocumentProcessed_Exact(sender As Object, e As EventArgs)
        Console.WriteLine("Document processed (exact signature)")
    End Sub
    
    ' Simplified handler - causes BC42328 with EventHandler
    Private Sub OnDocumentProcessed_Simple()
        Console.WriteLine("Document processed (simple)")
    End Sub
    
    ' Handler for custom event - exact match
    Private Sub OnStatusChanged_Exact(message As String)
        Console.WriteLine($"Status: {message}")
    End Sub
    
    ' Handler with ignored parameters - causes BC42328 with custom event
    Private Sub OnStatusChanged_Simple()
        Console.WriteLine("Status changed")
    End Sub
    
    Public Sub DemonstrateWarnings()
        Console.WriteLine("Setting up event handlers...")
        
        ' These work without warnings (exact matches)
        AddHandler DocumentProcessed, AddressOf OnDocumentProcessed_Exact
        AddHandler StatusChanged, AddressOf OnStatusChanged_Exact
        
        ' These generate BC42328 warnings (relaxed conversions)
        AddHandler DocumentProcessed, AddressOf OnDocumentProcessed_Simple
        AddHandler StatusChanged, AddressOf OnStatusChanged_Simple
        
        ' Fire the events
        RaiseEvent DocumentProcessed(Me, EventArgs.Empty)
        RaiseEvent StatusChanged("Processing complete")
    End Sub
    
    Public Sub DemonstrateSolutions()
        Console.WriteLine("Using solutions to avoid warnings...")
        
        ' Solution 1: Assign to variable first
        Dim handler1 As EventHandler = AddressOf OnDocumentProcessed_Simple
        AddHandler DocumentProcessed, handler1
        
        ' Solution 2: Use lambda expression
        AddHandler DocumentProcessed, Sub(s, e) OnDocumentProcessed_Simple()
        
        ' Solution 3: Direct assignment to delegate variable
        Dim handler2 As Action(Of String) = AddressOf OnStatusChanged_Simple
        AddHandler StatusChanged, handler2
        
        ' Fire the events
        RaiseEvent DocumentProcessed(Me, EventArgs.Empty)
        RaiseEvent StatusChanged("All solutions work")
    End Sub
End Class

Module Program
    Sub Main()
        Dim processor As New DocumentProcessor()
        
        Console.WriteLine("=== Demonstrating BC42328 Warning ===")
        processor.DemonstrateWarnings()
        
        Console.WriteLine()
        Console.WriteLine("=== Demonstrating Solutions ===")
        processor.DemonstrateSolutions()
        
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module