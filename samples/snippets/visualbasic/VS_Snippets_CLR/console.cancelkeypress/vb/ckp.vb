' <Snippet1>
Class Sample
    Public Shared Sub Main() 
        Dim cki As ConsoleKeyInfo
        
        Console.Clear()
        
        ' Establish an event handler to process key press events.
        AddHandler Console.CancelKeyPress, AddressOf myHandler

        While True
            Console.Write("Press any key, or 'X' to quit, or ")
            Console.WriteLine("CTRL+C to interrupt the read operation:")
            
            ' Start a console read operation. Do not display the input.
            cki = Console.ReadKey(True)
            
            ' Announce the name of the key that was pressed .
            Console.WriteLine("  Key pressed: {0}" & vbCrLf, cki.Key)
            
            ' Exit if the user pressed the 'X' key.
            If cki.Key = ConsoleKey.X Then Exit While
        End While
    End Sub

    Protected Shared Sub myHandler(ByVal sender As Object, _
                                   ByVal args As ConsoleCancelEventArgs) 
        Console.WriteLine(vbCrLf & "The read operation has been interrupted.")
        
        Console.WriteLine("  Key pressed: {0}", args.SpecialKey)
        
        Console.WriteLine("  Cancel property: {0}", args.Cancel)
        
        ' Set the Cancel property to true to prevent the process from terminating.
        Console.WriteLine("Setting the Cancel property to true...")
        args.Cancel = True
        
        ' Announce the new value of the Cancel property.
        Console.WriteLine("  Cancel property: {0}", args.Cancel)
        Console.WriteLine("The read operation will resume..." & vbCrLf)
    End Sub
End Class
' The example diplays output similar to the following:
'    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
'     Key pressed: J
'    
'    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
'     Key pressed: Enter
'    
'    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
'    
'    The read operation has been interrupted.
'     Key pressed: ControlC
'     Cancel property: False
'    Setting the Cancel property to true...
'     Cancel property: True
'    The read operation will resume...
'    
'     Key pressed: Q
'    
'    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
'     Key pressed: X
' </Snippet1>