Module Program
    Sub Main()
        Console.WriteLine($"Installed UI Culture: {My.Computer.Info.InstalledUICulture}")
    End Sub
End Module
' Compilation produces the following output:
'    c:\Projects\ComputerInfo\Program.vb(3,52): error BC30456: 'Computer' is not a member of 'bc30456.My'.
'   [c:\Projects\ComputerInfo\bc30456.vbproj]
