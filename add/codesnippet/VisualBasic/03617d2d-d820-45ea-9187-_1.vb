    Shared Sub CompileCode(ByVal ccu As CodeCompileUnit, ByVal sourceName As String) 
        Dim provider As CodeDomProvider = Nothing
        Dim sourceFile As New FileInfo(sourceName)
        ' Select the code provider based on the input file extension, either C# or Visual Basic.
        If sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".CS" Then
            provider = New Microsoft.CSharp.CSharpCodeProvider()
        ElseIf sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".VB" Then
            provider = New Microsoft.VisualBasic.VBCodeProvider()
        Else
            Console.WriteLine("Source file must have a .cs or .vb extension")
        End If
        If Not (provider Is Nothing) Then
            Dim options As New CodeGeneratorOptions()
            ' Set code formatting options to your preference. 
            options.BlankLinesBetweenMembers = True
            options.BracingStyle = "C"
            
            Dim sw As New StreamWriter(sourceName)
            provider.GenerateCodeFromCompileUnit(ccu, sw, options)
            sw.Close()
        End If
    
    End Sub